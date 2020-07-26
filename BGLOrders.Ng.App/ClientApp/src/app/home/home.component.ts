import { Component, Input, OnInit } from '@angular/core';
import { Item } from '../models';
import { ItemsService } from '../services/items.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  public itemCatalog: Item[];

  constructor(private readonly itemService: ItemsService) { }

  async ngOnInit() {
    this.itemCatalog = await this.itemService.getItems();
  }

}
