export class LineItem {
  extendedPrice() { throw new Error("Not implemented"); }
  get isShippable() { throw new Error("Not implemented"); }
}

export class ProductLine extends LineItem {
  constructor(sku, qty, unitPrice) {
    super();
    this.sku = sku; this.qty = qty; this.unitPrice = unitPrice;
  }
  extendedPrice() { return this.unitPrice.mul(this.qty); }
  get isShippable() { return true; }
}

export class ServiceLine extends LineItem {
  constructor(name, hours, rate) {
    super();
    this.name = name; this.hours = hours; this.rate = rate;
  }
  extendedPrice() { return this.rate.mul(this.hours); }
  get isShippable() { return false; }
}
