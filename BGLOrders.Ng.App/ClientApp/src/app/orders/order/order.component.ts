import { Component, OnInit, Input } from '@angular/core';
import { Item, OrderItem, Order } from '../../models';
import { OrderService } from 'src/app/services/order.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { OrderItemService } from '../../services/order-item.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  public items: OrderItem[];

  constructor(
    private readonly orderService: OrderService,
    private readonly orderItemService: OrderItemService,
    private readonly router: Router) { }

  ngOnInit() {
    this.subscribleToItems();
  }

  private subscribleToItems() {
    this.orderItemService.items$.subscribe(items => {
      this.items = items;
    });
  }

  public async submitOrder() {
    const orderComplete = await this.orderService.createOrder(this.items);
    if (orderComplete) {
      this.orderItemService.orderCreated();
      this.router.navigate(['./order-list'])
    } else {
      // Show error toast
    }
  }

  //public async updateOrder() {
  //  const updateComplete = await this.orderService.updateOrder(this.order);
  //  if(updateComplete) {
  //    // Show toast
  //  }
  //}
}
