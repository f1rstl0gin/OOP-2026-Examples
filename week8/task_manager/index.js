const readline = require("readline");

class Stack {
  constructor() {
    this.items = [];
  }

  push(item) {
    this.items.push(item);
  }

  pop() {
    return this.items.pop();
  }

  peek() {
    return this.items[this.items.length - 1];
  }

  isEmpty() {
    return this.items.length === 0;
  }
}

class Queue {
  constructor() {
    this.items = [];
  }

  enqueue(item) {
    this.items.push(item);
  }

  dequeue() {
    return this.items.shift();
  }

  isEmpty() {
    return this.items.length === 0;
  }
}

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

const stack = new Stack();
const queue = new Queue();

const menu = `\nChoose an option:
1) Add task to stack
2) Pop task from stack
3) Add task to queue
4) Dequeue task from queue
5) View next stack task
6) Exit\n`;

function prompt() {
  rl.question(menu, (answer) => {
    switch (answer.trim()) {
      case "1":
        rl.question("Stack task name: ", (task) => {
          stack.push(task);
          console.log(`Added to stack: ${task}`);
          prompt();
        });
        break;
      case "2": {
        const task = stack.pop();
        console.log(task ? `Popped from stack: ${task}` : "Stack is empty.");
        prompt();
        break;
      }
      case "3":
        rl.question("Queue task name: ", (task) => {
          queue.enqueue(task);
          console.log(`Added to queue: ${task}`);
          prompt();
        });
        break;
      case "4": {
        const task = queue.dequeue();
        console.log(task ? `Dequeued from queue: ${task}` : "Queue is empty.");
        prompt();
        break;
      }
      case "5": {
        const task = stack.peek();
        console.log(task ? `Next stack task: ${task}` : "Stack is empty.");
        prompt();
        break;
      }
      case "6":
        rl.close();
        break;
      default:
        console.log("Invalid option.");
        prompt();
    }
  });
}

console.log("Task Manager (Stack + Queue)");
prompt();
