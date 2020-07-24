import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './core/nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { OrderComponent } from './orders/order/order.component'
import { ItemListComponent } from './items/item-list/item-list.component';
import { OrderListComponent } from './orders/order-list/order-list.component';
import { ItemComponent } from './items/item/item.component';
import { ToastrModule } from 'ngx-toastr';
import { EditOrderComponent } from './orders/edit-order/edit-order.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    OrderListComponent,
    ItemListComponent,
    OrderComponent,
    ItemComponent,
    OrderListComponent,
    EditOrderComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'order-list', component: OrderListComponent },
      { path: 'order', component: OrderComponent},
    ]),
    NoopAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
