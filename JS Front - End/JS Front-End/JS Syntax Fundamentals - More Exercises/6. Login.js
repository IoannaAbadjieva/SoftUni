function logIn([username, ...passwords]) {
  const pass = username.split("").reverse().join("");
  for (let index = 0; index < 4; index++) {
    if (pass === passwords[index]) {
      console.log(`User ${username} logged in.`);
      return;
    }

    if (index < 3) {
      console.log("Incorrect password. Try again.");
    } else {
      console.log(`User ${username} blocked!`);
    }
  }
}

logIn(["Acer", "login", "go", "let me in", "recA"]);
