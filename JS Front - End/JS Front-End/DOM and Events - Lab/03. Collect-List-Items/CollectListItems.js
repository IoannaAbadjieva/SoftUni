function extractText() {
  const listItems = Array.from(document.querySelectorAll("#items li")).map(
    (x) => x.textContent
  );

  document.querySelector("#result").value = listItems.join("\n");
}
