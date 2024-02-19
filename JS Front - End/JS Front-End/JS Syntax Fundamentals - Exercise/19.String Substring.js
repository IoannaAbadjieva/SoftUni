function findSubstring(word, text) {
  const splittedText = text.split(" ");

  for (let i = 0; i < splittedText.length; i++) {
    if (splittedText[i].toLowerCase() === word.toLowerCase()) {
      console.log(word);
      return;
    }
  }

  console.log(`${word} not found!`);
}

findSubstring("jaVascRipt", "JavaScript is the best programming language");
