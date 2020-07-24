import { Component, OnInit, Input } from '@angular/core';
import { Item } from 'src/app/models';
import { ToastrService, IndividualConfig } from 'ngx-toastr';
import { OrderService } from 'src/app/services/order.service';
import { OrderItemService } from 'src/app/services/order-item.service';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {

  @Input() item: Item;
  @Input() showAddBtn: boolean
  @Input() showRemoveBtn: boolean

  constructor(private readonly orderItemService: OrderItemService,
    private readonly toastService: ToastrService) { }

  ngOnInit() {
  }

  public addToCart() {
    this.orderItemService.addOrderItem(this.item);
    this.toastService.success(`Added ${this.item.name} to your order.`, '', this.getDefaultToastConfig());
  }

  public removeFromCart() {
    this.orderItemService.removeOrderItem(this.item);
    this.toastService.success(`Removed ${this.item.name} from your order.`, '', this.getDefaultToastConfig())
  }

  private getDefaultToastConfig(): Partial<IndividualConfig> {
    return {
      positionClass: 'toast-bottom-center',
      timeOut: 2000,
      closeButton: true
    }
  }

}
