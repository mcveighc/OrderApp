import { Component, OnInit, Input } from '@angular/core';
import { Item, OrderItem } from '../../models';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css']
})
export class ItemListComponent {

  @Input() showQuantities: boolean
  @Input() enableRemove: boolean
  @Input() enableAdd: boolean;
  @Input() items: Item[] | OrderItem[];

  constructor() { }
}
