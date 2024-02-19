function modifyNumber(number) {
  function getAvgValue(num) {
    return (
      Array.from(num, Number).reduce((acc, cur) => acc + cur, 0) / num.length
    );
  }

  num = number.toString();
  let average = getAvgValue(num);

  while (average < 5) {
    num += "9";
    average = getAvgValue(num);
  }
  console.log(num);
}

modifyNumber(5835);
