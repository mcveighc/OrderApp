import { Component, OnInit, Input } from '@angular/core';
import { Item } from '../../models';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css']
})
export class ItemListComponent {

  @Input() enableRemove: boolean
  @Input() enableAdd: boolean;
  @Input() items: Item[];

  constructor() { }
}
