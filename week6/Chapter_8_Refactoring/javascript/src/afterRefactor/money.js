export class Money {
  constructor(amount, currency = "USD") {
    this.amount = amount;
    this.currency = currency;
  }
  add(other) { this.#check(other); return new Money(this.amount + other.amount, this.currency); }
  sub(other) { this.#check(other); return new Money(this.amount - other.amount, this.currency); }
  mul(factor) { return new Money(this.amount * factor, this.currency); }
  #check(other) {
    if (this.currency !== other.currency) throw new Error(`Currency mismatch: ${this.currency} vs ${other.currency}`);
  }
  fmt() { return `${this.amount.toFixed(2)} ${this.currency}`; }
}
