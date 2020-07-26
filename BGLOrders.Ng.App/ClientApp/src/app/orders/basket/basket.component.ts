import { Component, OnInit } from '@angular/core';
import { OrderItem } from 'src/app/models';
import { OrderItemService } from 'src/app/services/order-item.service';
import { ToastService } from 'src/app/services/toast.service';
import { OrderService } from 'src/app/services/order.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {

  public orderTotal: number
  public items: OrderItem[];

  constructor(
    private readonly orderService: OrderService,
    private readonly orderItemService: OrderItemService,
    private readonly toastService: ToastService,
    private readonly router: Router) { }

  ngOnInit() {
    this.subscribleToItems();
  }

  private subscribleToItems() {
    this.orderItemService.items$.subscribe(items => {
      this.items = items;
      this.updateTotal();
    });
  }

  public async submitOrder() {
    const orderComplete = await this.orderService.createOrder(this.items);

    if (orderComplete) {
      this.orderItemService.orderCreated();
      this.router.navigate(['./order-list'])
    } else {
      this.toastService.showError('Unable to place order.');
    }
  }

  //public async updateOrder() {
  //  const updateComplete = await this.orderService.updateOrder(this.order);
  //  if(updateComplete) {
  //    // Show toast
  //  }
  //}

  private updateTotal() {
    this.orderTotal = this.orderItemService.getOrderTotal();
  }
}
