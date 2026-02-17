import { Money } from "./money.js";

export class Customer {
  constructor(id, name, state) { this.id = id; this.name = name; this.state = state; }
}

export class DiscountPolicy {
  discount(subtotal) { return subtotal.amount > 100 ? subtotal.mul(0.05) : new Money(0, subtotal.currency); }
}

export class ShippingPolicy {
  shipping(items, subtotal) {
    const hasShippable = items.some((i) => i.isShippable);
    if (!hasShippable) return new Money(0, subtotal.currency);
    return subtotal.amount > 75 ? new Money(0, subtotal.currency) : new Money(9.95, subtotal.currency);
  }
}

export class TaxPolicy {
  tax(customer, taxable) { return customer.state === "PA" ? taxable.mul(0.06) : new Money(0, taxable.currency); }
}
