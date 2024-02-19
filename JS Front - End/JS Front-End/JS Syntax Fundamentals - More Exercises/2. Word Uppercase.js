function uppercaseWords(text) {
  const words = text.match(/[A-Za-z0-9]+/g).map((w) => w.toUpperCase());
  console.log(words.join(", "));
}

uppercaseWords("Hi, how are you?");
