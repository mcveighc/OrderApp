import { Component, OnInit } from '@angular/core';
import { OrderItemService } from 'src/app/services/order-item.service';
import { OrderItem } from '../../models';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  basketCount: number

  constructor(private readonly orderItemsService: OrderItemService) { }

  ngOnInit(): void {
    this.orderItemsService.items$.subscribe(items => {
      this.basketCount = !items.length ? 0 : this.getBasketCount(items);
    });
  }

  private getBasketCount(items: OrderItem[]) {
    return items.map(i => i.quantity).reduce((prev, curr) => prev + curr);
  }

}
