function solve(input) {
  const wordsOccurences = input
    .toLowerCase()
    .split(" ")
    .reduce((acc, curr) => {
      if (!acc.hasOwnProperty(curr)) {
        acc[curr] = 0;
      }
      acc[curr]++;
      return acc;
    }, {});
  const wordsSet = new Set(input.toLowerCase().split(" "));
  const words = Array.from(wordsSet).filter(
    (w) => wordsOccurences[w] % 2 !== 0
  );

  console.log(words.join(" "));
}

solve("Java C# Php PHP Java PhP 3 C# 3 1 5 C#");
solve("Cake IS SWEET is Soft CAKE sweet Food");
