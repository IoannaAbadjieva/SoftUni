function solve([target, ...chunks]) {
  const conditions = {
    canCut: (x) => x / 4 >= target,
    canLap: (x) => x - 0.2 * x >= target,
    canGrind: (x) => x - 20 >= target,
    canEtch: (x) => x - 2 >= target - 1,
  };

  const operations = {
    cut: (x) => x / 4,
    lap: (x) => x - 0.2 * x,
    grind: (x) => x - 20,
    etch: (x) => x - 2,
    xray: (x) => x + 1,
    transportingAndWashing: (x) => Math.floor(x),
  };

  //   console.log(chunks);

  for (let chunk of chunks) {
    console.log(`Processing chunk ${chunk} microns`);
    while (chunk > target) {
      if (conditions.canCut(chunk)) {
        let counter = 0;

        while (conditions.canCut(chunk)) {
          chunk = operations.cut(chunk);
          counter++;
        }
        chunk = operations.transportingAndWashing(chunk);
        console.log(`Cut x${counter}`);
        console.log("Transporting and washing");
      }

      if (conditions.canLap(chunk)) {
        let counter = 0;

        while (conditions.canLap(chunk)) {
          chunk = operations.lap(chunk);
          counter++;
        }
        console.log(`Lap x${counter}`);
        chunk = operations.transportingAndWashing(chunk);
        console.log("Transporting and washing");
      }

      if (conditions.canGrind(chunk)) {
        let counter = 0;

        while (conditions.canGrind(chunk)) {
          chunk = operations.grind(chunk);
          counter++;
        }
        chunk = operations.transportingAndWashing(chunk);
        console.log(`Grind x${counter}`);
        console.log("Transporting and washing");
      }

      if (conditions.canEtch(chunk)) {
        let counter = 0;

        while (conditions.canEtch(chunk)) {
          chunk = operations.etch(chunk);
          counter++;
        }
        chunk = operations.transportingAndWashing(chunk);
        console.log(`Etch x${counter}`);
        console.log("Transporting and washing");
      }

      if (chunk + 1 === target) {
        chunk = operations.xray(chunk);
        console.log("X-ray x1");
      }
    }
    console.log(`Finished crystal ${chunk} microns`);
  }
}

solve([1375, 50000]);
solve([1000, 4000, 8100]);
