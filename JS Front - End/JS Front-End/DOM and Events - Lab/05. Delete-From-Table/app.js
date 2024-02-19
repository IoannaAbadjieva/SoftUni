function deleteByEmail() {
  const email = document.querySelector("input").value;
  const emailAddresses = Array.from(
    document.querySelectorAll("td:nth-child(even)")
  );
  const user = emailAddresses.find((td) => td.textContent === email);

  if (user) {
    const row = user.parentElement;
    row.parentElement.removeChild(row);
    document.querySelector("#result").textContent = "Deleted.";
  } else {
    document.querySelector("#result").textContent = "Not found.";
  }
}
