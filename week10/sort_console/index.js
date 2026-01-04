const readline = require("readline");

function mergeSort(values) {
  if (values.length <= 1) {
    return values;
  }
  const mid = Math.floor(values.length / 2);
  const left = mergeSort(values.slice(0, mid));
  const right = mergeSort(values.slice(mid));
  return merge(left, right);
}

function merge(left, right) {
  const result = [];
  let i = 0;
  let j = 0;

  while (i < left.length && j < right.length) {
    if (left[i] <= right[j]) {
      result.push(left[i]);
      i += 1;
    } else {
      result.push(right[j]);
      j += 1;
    }
  }

  return result.concat(left.slice(i)).concat(right.slice(j));
}

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

console.log("Merge Sort Demo");
rl.question("Enter numbers separated by commas: ", (answer) => {
  const numbers = answer
    .split(",")
    .map((value) => Number(value.trim()))
    .filter((value) => !Number.isNaN(value));

  if (numbers.length === 0) {
    console.log("No valid numbers provided.");
    rl.close();
    return;
  }

  const sorted = mergeSort(numbers);
  console.log(`Sorted: ${sorted.join(", ")}`);
  rl.close();
});
