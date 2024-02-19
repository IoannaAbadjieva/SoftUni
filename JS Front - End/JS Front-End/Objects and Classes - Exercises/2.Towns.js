function solve(input) {
  input
    .map((town) => {
      const [name, lat, long] = town.split(" | ");
      return {
        town: name,
        latitude: Number(lat).toFixed(2),
        longitude: Number(long).toFixed(2),
      };
    })
    .forEach((town) => console.log(town));
}

solve(["Sofia | 42.696552 | 23.32601", "Beijing | 39.913818 | 116.363625"]);
