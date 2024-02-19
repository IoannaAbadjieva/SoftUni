function loadBar(num) {
  const bar = `[${"%".repeat(num / 10)}${".".repeat(10 - num / 10)}]`;

  if (num === 100) {
    console.log(`${num}% Complete!\n${bar}`);
    return;
  }
  console.log(`${num}% ${bar}\nStill loading...`);
}

loadBar(30);
