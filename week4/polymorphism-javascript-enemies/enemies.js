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

class Vampire extends Enemy {
  attack() {
    console.log("Vampire drinks your blood");
  }
}

class Bowser extends Enemy {
  attack() {
    console.log("Bowser knocks down the bridge");
  }
}

const enemies = [new Zombie(), new Robot(), new Alien(), new Vampire(), new Bowser()];

enemies.forEach((enemy) => enemy.attack());
