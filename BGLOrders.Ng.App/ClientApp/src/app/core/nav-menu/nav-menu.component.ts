import { Component, OnInit } from '@angular/core';
import { OrderItemService } from 'src/app/services/order-item.service';

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
      this.basketCount = items.length;
    });
  }

}
