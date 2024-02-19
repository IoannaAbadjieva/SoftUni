function focused() {
  const elements = Array.from(document.querySelectorAll("input"));
  elements.forEach((element) => {
    element.addEventListener("focus", (e) => {
      e.target.parentElement.classList.add("focused");
    });
    element.addEventListener("blur", (e) => {
      e.target.parentElement.classList.remove("focused");
    });
  });
}
