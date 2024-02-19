function findSpecialWords(text) {
  const regExpr = /(#)([A-z]+\b)/g;
  const specialWords = Array.from(text.matchAll(regExpr), (m) => m[2]);
  specialWords.forEach((w) => console.log(w));
}

findSpecialWords(
  "The symbol # is known #variously in English-speaking #regions as the #number sign"
);
