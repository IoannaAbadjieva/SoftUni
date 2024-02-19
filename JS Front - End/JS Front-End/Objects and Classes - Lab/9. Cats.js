function solve(input) {
  class Cat {
    constructor(name, age) {
      this.name = name;
      this.age = age;
    }
    meow() {
      console.log(`${this.name}, age ${this.age} says Meow`);
    }
  }

  input.forEach((element) => {
    const [name, age] = element.split(" ");
    const cat = new Cat(name, age);
    cat.meow();
  });
}

solve(["Mellow 2", "Tom 5"]);
solve(["Candy 1", "Poppy 3", "Nyx 2"]);
