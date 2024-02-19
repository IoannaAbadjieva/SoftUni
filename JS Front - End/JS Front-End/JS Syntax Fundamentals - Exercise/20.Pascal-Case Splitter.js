function splitPascalCase(text) {
  const regExpr = /[A-Z][a-z]*/g;
  const splittedText = Array.from(text.matchAll(regExpr), (m) => m[0]);
  console.log(splittedText.join(", "));
}

splitPascalCase("SplitMeIfYouCanHaHaYouCantOrYouCan");
splitPascalCase("HoldTheDoor");
splitPascalCase("ThisIsSoAnnoyingToDo");
