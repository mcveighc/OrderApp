import { Injectable, Inject } from "@angular/core";
import { Order, Item, OrderItem } from "../models";
import { Observable, BehaviorSubject } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
@Injectable({
  providedIn: "root",
})
export class OrderService {

  private orders: Order[] = [];
  private orderChangesBehaviourSubject = new BehaviorSubject<Order[]>(this.orders);

  public get orders$(): Observable<Order[]> {
    return this.orderChangesBehaviourSubject.asObservable();
  }

  constructor(
    private readonly httpClient: HttpClient,
    @Inject("BASE_URL") private readonly baseUrl: string,
  ) {
  }

  public async initOrders() {
    const uri = this.getEndpointUri();
    const orders = await this.httpClient.get<Order[]>(uri).toPromise();

    this.orders = orders;
    this.orderChangesBehaviourSubject.next(orders);
  }

  public getOrderById(id: number): Observable<Order> {
    const uri = this.getEndpointUri();
    const fullUri = [uri, id].join("/");

    return this.httpClient.get<Order>(fullUri);
  }

  public async createOrder(orderItems: OrderItem[]): Promise<boolean> {
    const order = this.getOrder(orderItems);
    const requestBody = JSON.stringify(order);

    const uri = this.getEndpointUri();
    const headerOptions = new HttpHeaders({ 'Content-Type': 'application/json' });
    const orderCreated = await this.httpClient.post<boolean>(uri, requestBody, {
      headers: headerOptions
    }).toPromise();

    if (orderCreated) {
      this.initOrders();
    }

    return orderCreated;
  }

  public updateOrder(order: Order): Observable<void> {
    const uri = [this.getEndpointUri(), order.id].join('/');
    const headerOptions = new HttpHeaders({ 'Content-Type': 'application/json' });

    return void this.httpClient.put(uri, order, { headers: headerOptions });
  }

  public async cancelOrder(orderId: number): Promise<boolean> {
    const uri = [this.getEndpointUri(), orderId].join('/');
    const headerOptions = new HttpHeaders({ 'Content-Type': 'application/json' });

    const orderDeleted = await this.httpClient.delete<boolean>(uri, { headers: headerOptions }).toPromise();

    if (orderDeleted) {
      this.initOrders();
    }

    return orderDeleted;
  }

  private getOrder(orderItems: OrderItem[]): Partial<Order> {
    const order = {
      createdDate: new Date().toISOString(),
      total: orderItems.map(oi => oi.price).reduce((prev, curr) => prev + curr, 0),
      items: orderItems
    } as Partial<Order>;

    return order;
  }

  private getEndpointUri(): string {
    return [this.baseUrl, "orders"].join("/");
  }
}
