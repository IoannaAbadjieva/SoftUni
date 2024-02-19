function sortNames(names) {
  const result = names.sort((a, b) => a.localeCompare(b));

  for (let i = 0; i < result.length; i++) {
    console.log(`${i + 1}.${result[i]}`);
  }
}

sortNames(["John", "Bob", "Christina", "Ema", "dree", "Dree"]);
