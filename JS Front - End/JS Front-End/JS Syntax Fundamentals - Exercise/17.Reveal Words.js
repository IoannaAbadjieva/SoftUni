function revealWords(...input) {
  const regexp = /\*+/g;
  const words = input[0].split(", ");
  let text = input[1];
  const censored = Array.from(text.matchAll(regexp), (m) => m[0]);

  for (let i = 0; i < censored.length; i++) {
    if (words.some((w) => w.length == censored[i].length)) {
      const word = words.find((w) => w.length == censored[i].length);
      text = text.replace(censored[i], word);
    }
  }

  console.log(text);
}

revealWords(
  "great, learning",
  "softuni is ***** place for ******** new programming languages"
);
