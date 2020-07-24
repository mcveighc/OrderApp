import { OrderItem } from "./item";

export type ItemId = number;
export type ItemQuantity = number;

export type OrderItems = Map<ItemId, OrderItem>
