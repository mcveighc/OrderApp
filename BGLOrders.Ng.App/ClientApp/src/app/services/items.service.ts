import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable, of } from "rxjs";
import { Item } from "../models";

@Injectable({
  providedIn: "root",
})
export class ItemsService {
  constructor(
    private httpClient: HttpClient,
    @Inject("BASE_URL") private readonly baseUrl: string
  ) {}

  public getItems(): Observable<Item[]> {
    const endpoint = [this.baseUrl, 'items'].join('/');
    return this.httpClient.get<Item[]>(endpoint);
  }
}
