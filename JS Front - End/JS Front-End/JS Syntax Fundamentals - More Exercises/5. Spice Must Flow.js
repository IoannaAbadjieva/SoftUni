function extractSpice(yield) {
  let days = 0;
  let harvest = 0;

  if (yield >= 100) {
    while (yield >= 100) {
      harvest += yield;
      days++;
      yield -= 10;
    }

    harvest -= (days + 1) * 26;
  }

  console.log(days);
  console.log(harvest);
}

extractSpice(450);
