// BEFORE REFACTOR (procedural), intentionally messy.
export function buildInvoiceBefore() {
  const customer = { id: "CUST-100", name: "Acme Co.", state: "PA" };

  const lines = [
    { type: "product", sku: "WIDGET", qty: 3, unitPrice: 19.99 },
    { type: "service", name: "Install", hours: 2.5, rate: 65.0 },
  ];

  let subtotal = 0;
  for (const line of lines) {
    if (line.type === "product") subtotal += line.qty * line.unitPrice;
    if (line.type === "service") subtotal += line.hours * line.rate;
  }

  const discount = subtotal > 100 ? 0.05 * subtotal : 0;
  const hasProduct = lines.some((l) => l.type === "product");
  const shipping = hasProduct ? (subtotal > 75 ? 0 : 9.95) : 0;

  const taxable = subtotal - discount + shipping;
  const tax = customer.state === "PA" ? 0.06 * taxable : 0;
  const total = taxable + tax;

  return [
    `Customer: ${customer.id} - ${customer.name} (${customer.state})`,
    `Subtotal: ${subtotal.toFixed(2)}`,
    `Discount: -${discount.toFixed(2)}`,
    `Shipping: ${shipping.toFixed(2)}`,
    `Tax: ${tax.toFixed(2)}`,
    `TOTAL: ${total.toFixed(2)}`,
  ].join("\n");
}
