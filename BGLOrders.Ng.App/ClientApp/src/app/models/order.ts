import { Item } from ".";
import { OrderItem } from "./item";

export interface Order {
  id: number,
  createdDate: string,
  total: number
  items: OrderItem[]
}
