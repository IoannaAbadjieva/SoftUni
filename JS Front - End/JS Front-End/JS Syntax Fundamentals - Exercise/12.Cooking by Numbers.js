function mathOperations(first, ...commands) {
  let number = Number(first);

  for (let index = 0; index < commands.length; index++) {
    switch (commands[index]) {
      case "chop":
        number = number / 2;
        break;
      case "dice":
        number = Math.sqrt(number);
        break;
      case "spice":
        number++;
        break;
      case "bake":
        number = 3 * number;
        break;
      case "fillet":
        number -= 0.2 * number;
        break;
    }
    console.log(number);
  }
}

mathOperations("9", "dice", "spice", "chop", "bake", "fillet");
