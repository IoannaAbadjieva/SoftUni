function sumTable() {
  const column = Array.from(
    document.querySelectorAll("td:nth-child(even):not(#sum)")
  );

  const total = column.reduce((acc, curr) => {
    return acc + Number(curr.textContent);
  }, 0);

  document.querySelector("#sum").textContent = total;
}
