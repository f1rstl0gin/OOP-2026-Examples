import { Money } from "./money.js";
import { ProductLine, ServiceLine } from "./lineItems.js";
import { Customer, DiscountPolicy, ShippingPolicy, TaxPolicy } from "./policies.js";

export class InvoiceCalculator {
  constructor(discountPolicy = new DiscountPolicy(), shippingPolicy = new ShippingPolicy(), taxPolicy = new TaxPolicy()) {
    this.discountPolicy = discountPolicy;
    this.shippingPolicy = shippingPolicy;
    this.taxPolicy = taxPolicy;
  }

  totals(customer, items) {
    let subtotal = new Money(0);
    for (const item of items) subtotal = subtotal.add(item.extendedPrice());

    const discount = this.discountPolicy.discount(subtotal);
    const shipping = this.shippingPolicy.shipping(items, subtotal);

    const taxable = subtotal.sub(discount).add(shipping);
    const tax = this.taxPolicy.tax(customer, taxable);
    const total = taxable.add(tax);

    return { subtotal, discount, shipping, tax, total };
  }
}

export function buildInvoiceAfter() {
  const customer = new Customer("CUST-100", "Acme Co.", "PA");
  const items = [
    new ProductLine("WIDGET", 3, new Money(19.99)),
    new ServiceLine("Install", 2.5, new Money(65.0)),
  ];

  const calc = new InvoiceCalculator();
  const t = calc.totals(customer, items);

  return [
    `Customer: ${customer.id} - ${customer.name} (${customer.state})`,
    `Subtotal: ${t.subtotal.fmt()}`,
    `Discount: -${t.discount.fmt()}`,
    `Shipping: ${t.shipping.fmt()}`,
    `Tax: ${t.tax.fmt()}`,
    `TOTAL: ${t.total.fmt()}`,
  ].join("\n");
}
