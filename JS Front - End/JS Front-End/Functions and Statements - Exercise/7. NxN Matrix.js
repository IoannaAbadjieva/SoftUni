function printmatrix(n) {
  const row = Array.from({ length: n }, (v, i) => n);
  const matrix = Array.from({ length: n }, (v, i) => row);

  matrix.forEach((element) => {
    console.log(element.join(" "));
  });
}

printmatrix(2);
