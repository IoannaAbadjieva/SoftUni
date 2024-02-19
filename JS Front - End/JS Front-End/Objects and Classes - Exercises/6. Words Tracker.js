function solve(input) {
  const [searchedWords, ...words] = input;
  const wordsOccurences = searchedWords.split(" ").reduce((acc, curr) => {
    acc[curr] = 0;
    return acc;
  }, {});

  words.forEach((w) => {
    if (wordsOccurences.hasOwnProperty(w)) {
      wordsOccurences[w]++;
    }
  });

  Object.entries(wordsOccurences)
    .sort(([keyA, valueA], [keyB, valueB]) => valueB - valueA)
    .forEach(([w, occ]) => console.log(`${w} - ${occ}`));
}

solve([
  "this sentence",
  "In",
  "this",
  "sentence",
  "you",
  "have",
  "to",
  "count",
  "the",
  "occurrences",
  "of",
  "the",
  "words",
  "this",
  "and",
  "sentence",
  "because",
  "this",
  "is",
  "your",
  "task",
]);

solve([
  "is the",
  "first",
  "sentence",
  "Here",
  "is",
  "another",
  "the",
  "And",
  "finally",
  "the",
  "the",
  "sentence",
]);
