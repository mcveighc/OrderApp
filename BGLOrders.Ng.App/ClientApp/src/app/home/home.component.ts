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

  ngOnInit(): void {
    this.subscribeToItems();
  }

  private subscribeToItems() {
    this.itemService.getItems().subscribe(items => {
      this.itemCatalog = items;
    });
  }
}
