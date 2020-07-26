import { Component, OnInit, Input } from "@angular/core";
import { Order } from "src/app/models";
import { OrderService } from "src/app/services/order.service";
import { ToastService } from "../../services/toast.service";

@Component({
  selector: "app-order-list",
  templateUrl: "./order-list.component.html",
  styleUrls: ["./order-list.component.css"],
})
export class OrderListComponent implements OnInit {
  public orders: Order[];

  constructor(
    private readonly orderService: OrderService,
    private readonly toastService: ToastService,
  ) { }

  ngOnInit() {
    this.getOrders();
    this.subscribeToOrderChanges();
  }

  public async cancelOrder(orderId: number) {
    const success = await this.orderService.cancelOrder(orderId);
    if (success) {
     this.toastService.showSuccess(`Order ${orderId} cancelled.`)
    }
  }

  private async getOrders() {
    this.orders = await this.orderService.getOrders();
  }

  private subscribeToOrderChanges() {
    this.orderService.orders$.subscribe(orders => this.orders = orders);
  }
}
