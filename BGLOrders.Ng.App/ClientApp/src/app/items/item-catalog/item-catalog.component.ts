import { Component, OnInit } from "@angular/core";
import { ItemsService } from "src/app/services/items.service";
import { Item } from "src/app/models";
import { ToastService } from "src/app/services/toast.service";
import { MatDialog } from "@angular/material/dialog";
import { ItemDialogComponent } from "../edit-item-dialog/edit-item-dialog.component";
import { switchMap } from "rxjs/operators";
import { EditOrderComponent } from "../../orders/edit-order/edit-order.component";

@Component({
  selector: "app-item-catalog",
  templateUrl: "./item-catalog.component.html",
  styleUrls: ["./item-catalog.component.css"],
})
export class ItemCatalogComponent implements OnInit {
  public items: Item[];
  constructor(
    private readonly itemService: ItemsService,
    private readonly toastService: ToastService,
    private readonly dialog: MatDialog
  ) { }

  async ngOnInit() {
    this.subscribeToItemChanges();

    if(!this.itemService.hasItems()) {
      this.itemService.getItems()
    }
  }

  public subscribeToItemChanges() {
    this.itemService.items$.subscribe((items) => {
      this.items = items;
    });
  }

  public async addItem() {
    const addItemDialog = this.dialog.open(ItemDialogComponent, { data: {} });

    addItemDialog.afterClosed().pipe(
      switchMap((newItem: Item) => {
        return this.itemService.addItem(newItem);
      })
    ).subscribe(itemUpdated => {
      if (itemUpdated) {
        this.toastService.showSuccess("Item added successfully");
      }
    },
      err => {
        this.toastService.showError(`Coud not add item ${err}`);
      });
  }

  public async editItem(item) {
    const itemForEdit: Item = {
      ...item
    };
    const editItemDialog = this.dialog.open(ItemDialogComponent, { data: itemForEdit });

    editItemDialog.afterClosed().pipe(
      switchMap((editedItem: Item) => {
        return this.itemService.editItem(editedItem)
      })
    ).subscribe(itemUpdated => {
      if (itemUpdated) {
        this.toastService.showSuccess("Item updated successfully");
      }
    },
      err => {
        this.toastService.showError(`Coud not update item ${err}`);
    });
  }

  public async deleteItem(itemId: number) {
    const itemDeleted = await this.itemService.deleteItem(itemId);
    if (itemDeleted) {
      this.toastService.showSuccess("Item deleted successfully");
    }
  }
}
