class Enemy {
  attack() {
    throw new Error("attack() must be implemented");
  }
}

class Zombie extends Enemy {
  attack() {
    console.log("Zombie bites slowly");
  }
}

class Robot extends Enemy {
  attack() {
    console.log("Robot fires laser");
  }
}

class Alien extends Enemy {
  attack() {
    console.log("Alien uses mind control");
  }
}

const enemies = [new Zombie(), new Robot(), new Alien()];

enemies.forEach((enemy) => enemy.attack());
