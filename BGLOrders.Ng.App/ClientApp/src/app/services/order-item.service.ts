import { Injectable, Inject } from "@angular/core";
import { Observable, BehaviorSubject } from "rxjs";
import { Item, OrderItem } from "../models";

@Injectable({
  providedIn: "root",
})
export class OrderItemService {
  private items: OrderItem[] = [];

  private itemsBehaviourSubject = new BehaviorSubject<OrderItem[]>(this.items);

  public get items$(): Observable<OrderItem[]> {
    return this.itemsBehaviourSubject.asObservable();
  }

  public addOrderItem(item: Item) {
    // We nderstand if we have that item already in our order.
    // If we don't create a new order item. If we do then just increment the quanitity
    const itemIndex = this.items.findIndex(i => i.id === item.id);
    if (itemIndex === -1) {
      const orderItem = this.getOrderItem(item);
      this.items.push(orderItem);
    } else {
      const item = this.items[itemIndex];
      item.quantity++;
    }

    this.itemsBehaviourSubject.next(this.items);
  }

  public removeOrderItem(item: Item) {
    const itemIndex = this.items.findIndex((i) => i.id === item.id);
    if (itemIndex !== -1) {
      this.items.splice(itemIndex, 1);
    }
    this.itemsBehaviourSubject.next(this.items);
  }

  public orderCreated() {
    this.items = [];
    this.itemsBehaviourSubject.next(this.items);
  }

  private getOrderItem(item: Item): OrderItem {
    return {
      ...item,
      quantity: 1,
    } as OrderItem;
  }
}
