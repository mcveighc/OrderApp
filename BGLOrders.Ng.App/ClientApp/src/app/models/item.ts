export interface OrderItem extends Item {
  quantity: number
}

export interface Item {
  id: number
  name: string,
  description: string,
  price: number,
}

export enum ItemState {
  InStock = 0,
  OutOfStock = 1,
  Decomissioned = 2
}
