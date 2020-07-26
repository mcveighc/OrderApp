import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, BehaviorSubject } from "rxjs";
import { Item } from "../models";
import { ServiceClientBase } from "./service-client-base";

@Injectable({
  providedIn: "root",
})
export class ItemsService extends ServiceClientBase {

  private items: Item[] = [];
  private itemsSubject = new BehaviorSubject<Item[]>([]);

  public get items$(): Observable<Item[]> {
    return this.itemsSubject.asObservable();
  }

  constructor(
    httpClient: HttpClient,
    @Inject("BASE_URL") baseUrl: string
  ) {
    super(httpClient, baseUrl, "items");
  }

  public async getItems(): Promise<Item[]> {
    const items = await super.get<Item[]>();

    this.items = items;
    this.itemsSubject.next(items);

    return items;
  }

  public async editItem(item: Item): Promise<Boolean> {
    const itemUpdated = await super.put<boolean>(item);
    if (!itemUpdated) return false;

    const itemIndex = this.items.findIndex((i) => i.id === item.id);
    if (itemIndex === -1) return false;

    this.items[itemIndex] = item;
    this.itemsSubject.next(this.items);

    return true;
  }

  public async addItem(newItem: Item): Promise<boolean> {
    const itemAdded = await super.post<boolean>(newItem);

    if (itemAdded) {
      this.items.push(newItem);
      this.itemsSubject.next(this.items);
    }
    return itemAdded;
  }

  public async deleteItem(itemId: number): Promise<Boolean> {
    const itemDeleted = await super.delete<boolean>(itemId.toString());

    // If we were unable to delete the item return
    if (!itemDeleted) return false;

    // Attempt to find the item in the items colletion
    const itemIndex = this.items.findIndex((i) => i.id === itemId);
    if (itemIndex === -1) return false;

    // We have found the item so remove it and let any listeners know
    this.items.splice(itemIndex, 1);
    this.itemsSubject.next(this.items);

    return true;
  }

  public hasItems(): Boolean {
    return this.items && this.items.length > 0;
  }
}
