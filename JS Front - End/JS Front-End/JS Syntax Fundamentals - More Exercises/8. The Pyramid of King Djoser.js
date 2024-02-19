function solve(base, increment) {
  let stones = 0;
  let marble = 0;
  let lapis = 0;
  let gold = 0;
  let counter = 0;

  for (let step = base; step >= 1; step -= 2) {
    counter++;

    if (step === 1 || step === 2) {
      gold += step ** 2;
      continue;
    }

    stones += (step - 2) ** 2;

    if (counter % 5 === 0) {
      lapis += step * 4 - 4;
      continue;
    }

    marble += step * 4 - 4;
  }

  console.log(`Stone required: ${Math.ceil(stones * increment)}`);
  console.log(`Marble required: ${Math.ceil(marble * increment)}`);
  console.log(`Lapis Lazuli required: ${Math.ceil(lapis * increment)}`);
  console.log(`Gold required: ${Math.ceil(gold * increment)}`);
  console.log(`Final pyramid height: ${Math.floor(counter * increment)}`);
}

solve(11, 1);
