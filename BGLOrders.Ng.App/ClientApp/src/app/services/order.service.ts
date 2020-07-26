import { Injectable, Inject } from "@angular/core";
import { Order, OrderItem } from "../models";
import { Observable, BehaviorSubject, of, from } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { OrderItemService } from "./order-item.service";
import { ServiceClientBase } from "./service-client-base";

@Injectable({
  providedIn: "root",
})
export class OrderService extends ServiceClientBase {

  private orders: Order[] = [];
  private orderChangesBehaviourSubject = new BehaviorSubject<Order[]>(this.orders);

  public get orders$(): Observable<Order[]> {
    return this.orderChangesBehaviourSubject.asObservable();
  }

  constructor(
    private readonly orderItemService: OrderItemService,
    @Inject(HttpClient) httpClient: HttpClient,
    @Inject("BASE_URL") baseUrl: string,
  ) {
    super(httpClient, baseUrl, "orders");
  }

  public async getOrders(): Promise<Order[]> {
    const orders = await super.get<Order[]>();

    this.orders = orders;
    this.orderChangesBehaviourSubject.next(orders);

    return orders;
  }

  public async getOrderById(id: number): Promise<Order> {
    const order = await super.get<Order>(id.toString());
    return order;
  }

  public async createOrder(orderItems: OrderItem[]): Promise<boolean> {
    const order = this.getOrder(orderItems);

    const orderCreated = await super.post<boolean>(order);
    if (orderCreated) {
      await this.getOrders();
    }

    return orderCreated;
  }

  public updateOrder(order: Order): Observable<void> {
    // TODO : Implement update
    return void of();
  }

  public async cancelOrder(orderId: number): Promise<boolean> {
    const orderDeleted = await super.delete<boolean>(orderId.toString());

    if (orderDeleted) {
      const orderIndex = this.orders.findIndex(o => o.id === orderId);
      this.orders.splice(orderIndex, 1);

      this.orderChangesBehaviourSubject.next(this.orders);
    }

    return orderDeleted;
  }

  private getOrder(orderItems: OrderItem[]): Partial<Order> {
    const order = {
      createdDate: new Date().toISOString(),
      total: this.orderItemService.getOrderTotal(),
      items: orderItems
    } as Partial<Order>;

    return order;
  }
}
