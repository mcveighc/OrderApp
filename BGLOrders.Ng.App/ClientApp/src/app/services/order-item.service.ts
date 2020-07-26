import { Injectable, Inject } from "@angular/core";
import { Observable, BehaviorSubject } from "rxjs";
import { Item, OrderItem } from "../models";

@Injectable({
  providedIn: "root",
})
export class OrderItemService {
  private orderItems: OrderItem[] = [];

  private itemsBehaviourSubject = new BehaviorSubject<OrderItem[]>(
    this.orderItems
  );

  public get items$(): Observable<OrderItem[]> {
    return this.itemsBehaviourSubject.asObservable();
  }

  public addOrderItem(item: Item) {
    // We nderstand if we have that item already in our order.
    // If we don't create a new order item. If we do then just increment the quanitity
    const itemIndex = this.orderItems.findIndex((i) => i.id === item.id);
    if (itemIndex === -1) {
      const orderItem = this.getOrderItem(item);
      this.orderItems.push(orderItem);
    } else {
      const item = this.orderItems[itemIndex];
      item.quantity++;
    }

    this.itemsBehaviourSubject.next(this.orderItems);
  }

  public removeOrderItem(item: Item) {
    const itemIndex = this.orderItems.findIndex((i) => i.id === item.id);
    if (itemIndex !== -1) {
      this.orderItems.splice(itemIndex, 1);
    }
    this.itemsBehaviourSubject.next(this.orderItems);
  }

  public orderCreated() {
    this.orderItems = [];
    this.itemsBehaviourSubject.next(this.orderItems);
  }

  // Calculate the order total at the time of purchase
  public getOrderTotal(): number {
    return this.orderItems
      .map((i) => i.price * i.quantity)
      .reduce((curr, prev) => curr + prev);
  }

  private getOrderItem(item: Item): OrderItem {
    return {
      ...item,
      quantity: 1,
    } as OrderItem;
  }
}
