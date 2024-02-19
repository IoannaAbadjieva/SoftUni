function printAge(years) {
  if (years < 0) {
    console.log("out of bounds");
    return;
  }

  let age;

  if (years >= 66) {
    age = "elder";
  } else if (years >= 20) {
    age = "adult";
  } else if (years >= 14) {
    age = "teenager";
  } else if (years >= 3) {
    age = "child";
  } else {
    age = "baby";
  }

  console.log(age);
}

printAge(100);
