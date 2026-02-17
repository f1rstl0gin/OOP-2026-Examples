// Chapter 8 (JavaScript): runnable entry point (BEFORE + AFTER).
//
// Run:
//   npm install
//   npm run demo

import { buildInvoiceBefore } from "./beforeRefactor/invoice.js";
import { buildInvoiceAfter } from "./afterRefactor/invoice.js";

console.log("=== BEFORE (procedural) ===");
console.log(buildInvoiceBefore());

console.log("\n=== AFTER (refactored to OOP) ===");
console.log(buildInvoiceAfter());
