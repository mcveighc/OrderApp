import { Component, OnInit, Input } from '@angular/core';
import { Item, OrderItem, Order } from '../../models';
import { OrderService } from 'src/app/services/order.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { OrderItemService } from '../../services/order-item.service';
import { ToastService } from '../../services/toast.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {
  ngOnInit(): void {
  }

}
