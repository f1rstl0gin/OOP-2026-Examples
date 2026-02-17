/*
  JavaScript demo for Chapter 5 topics:

  - JavaScript doesn't provide class-based multiple inheritance.
  - Instead, we can compose objects (HAS-A) and delegate behavior.
  - This demo uses *constructor functions* to mirror the chapter's style.

  Run:
    npm start
*/

// -----------------------------
// Base constructor functions
// -----------------------------

function ComicCharacter(nickName) {
  this.nickName = nickName;
}

function GameCharacter(fullName, initialScore, x, y) {
  this.fullName = fullName;
  this.score = initialScore;
  this.x = x;
  this.y = y;
}

GameCharacter.prototype.move = function (x, y) {
  this.x = x;
  this.y = y;
};

GameCharacter.prototype.isIntersectingWith = function (other) {
  return this.x === other.x && this.y === other.y;
};

function Alien(numberOfEyes) {
  this.numberOfEyes = numberOfEyes;
  this.visible = false;
}

Alien.prototype.appear = function () {
  this.visible = true;
  console.log(`[Alien] appear (${this.numberOfEyes} eyes)`);
};

Alien.prototype.disappear = function () {
  this.visible = false;
  console.log(`[Alien] disappear`);
};

function Wizard(spellPower) {
  this.spellPower = spellPower;
}

Wizard.prototype.disappearAlien = function (alien) {
  console.log(`[Wizard] casting vanish (power=${this.spellPower})`);
  alien.disappear();
};

function Knight(swordPower, swordWeight) {
  this.swordPower = swordPower;
  this.swordWeight = swordWeight;
}

Knight.prototype.unsheatheSword = function (alien) {
  console.log(`[Knight] unsheathe (power=${this.swordPower}, weight=${this.swordWeight})`);
  console.log(`[Knight] targeting alien with ${alien.numberOfEyes} eyes`);
};

// -----------------------------
// Constructor functions that use composition
// -----------------------------

function AngryDog(nickName) {
  this.comic = new ComicCharacter(nickName);

  Object.defineProperty(this, "nickName", {
    get: function () {
      return this.comic.nickName;
    },
  });

  this.drawSpeechBalloon = function (message, destination) {
    const prefix = destination ? `${destination.nickName}, ` : "";
    console.log(`${this.nickName} -> "${prefix}${message}"`);
  };

  this.drawThoughtBalloon = function (message) {
    console.log(`${this.nickName} ***${message}***`);
  };
}

function AngryCat(nickName, age, fullName, initialScore, x, y) {
  this.comic = new ComicCharacter(nickName);
  this.game = new GameCharacter(fullName, initialScore, x, y);
  this.age = age;

  Object.defineProperty(this, "nickName", {
    get: function () {
      return this.comic.nickName;
    },
  });

  Object.defineProperty(this, "fullName", {
    get: function () {
      return this.game.fullName;
    },
  });

  Object.defineProperty(this, "x", {
    get: function () {
      return this.game.x;
    },
  });

  Object.defineProperty(this, "y", {
    get: function () {
      return this.game.y;
    },
  });

  this.draw = function () {
    console.log(`[Draw] ${this.fullName} at (${this.x}, ${this.y})`);
  };

  this.move = function (x, y) {
    this.game.move(x, y);
  };

  this.isIntersectingWith = function (other) {
    return this.game.isIntersectingWith(other);
  };

  this.drawSpeechBalloon = function (message, destination) {
    const meow = this.age > 5 ? "Meow" : "mew";
    const to = destination ? `${destination.nickName} === ` : "";
    console.log(`${to}${this.nickName} -> "${meow}. ${message}"`);
  };
}

function AngryCatAlien(nickName, age, fullName, initialScore, x, y, numberOfEyes) {
  this.cat = new AngryCat(nickName, age, fullName, initialScore, x, y);
  this.alien = new Alien(numberOfEyes);

  // expose common properties through delegation
  Object.defineProperty(this, "nickName", { get: () => this.cat.nickName });
  Object.defineProperty(this, "fullName", { get: () => this.cat.fullName });
  Object.defineProperty(this, "x", { get: () => this.cat.x });
  Object.defineProperty(this, "y", { get: () => this.cat.y });
  Object.defineProperty(this, "numberOfEyes", { get: () => this.alien.numberOfEyes });

  // delegate behaviors
  this.draw = () => this.cat.draw();
  this.move = (nx, ny) => this.cat.move(nx, ny);
  this.isIntersectingWith = (other) => this.cat.isIntersectingWith(other);
  this.drawSpeechBalloon = (m, d) => this.cat.drawSpeechBalloon(m, d);
  this.appear = () => this.alien.appear();
  this.disappear = () => this.alien.disappear();
}

// -----------------------------
// Demo
// -----------------------------

console.log("=== JavaScript Composition Demo ===");

const dog1 = new AngryDog("Brian");
const dog2 = new AngryDog("Merlin");
dog1.drawSpeechBalloon(`Hello, my name is ${dog1.nickName}`);
dog1.drawSpeechBalloon("How do you do?", dog2);
dog2.drawThoughtBalloon("Who are you? I think.");

const cat1 = new AngryCat("Garfield", 10, "Mr. Garfield", 0, 10, 20);
cat1.draw();
dog1.drawSpeechBalloon(`Hello ${cat1.nickName}`, cat1);

const alien1 = new AngryCatAlien("Xeno", 120, "Mr. Xeno", 0, 10, 20, 3);
if (alien1.isIntersectingWith(cat1)) {
  alien1.move(cat1.x + 20, cat1.y + 20);
}
alien1.appear();
alien1.drawSpeechBalloon("I come in peace.", cat1);

const wizard = new Wizard(9001);
wizard.disappearAlien(alien1);
alien1.appear();

const knight = new Knight(100, 30);
knight.unsheatheSword(alien1);
