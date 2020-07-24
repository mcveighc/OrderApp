import { Component, OnInit, Input } from "@angular/core";
import { Order } from "src/app/models";
import { OrderService } from "src/app/services/order.service";

@Component({
  selector: "app-order-list",
  templateUrl: "./order-list.component.html",
  styleUrls: ["./order-list.component.css"],
})
export class OrderListComponent implements OnInit {
  public orders: Order[];

  constructor(private readonly orderService: OrderService) { }

  ngOnInit() {
    this.subscribeToOrderChanges();
  }

  public async cancelOrder(orderId: number) {
    const success = await this.orderService.cancelOrder(orderId);
    if (success) {
     // Toast here
    }
  }

  private subscribeToOrderChanges() {
    this.orderService.orders$.subscribe(orders => {
      this.orders = orders;
    });
  }

}
