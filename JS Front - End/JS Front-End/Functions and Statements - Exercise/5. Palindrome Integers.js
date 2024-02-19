function printIntegersPalindrome(numbers) {
  function isIntegerPalindrome(number) {
    const reversedNumber = Number(
      Array.from(number.toString()).reverse().join("")
    );
    return number === reversedNumber;
  }

  numbers.forEach((element) => {
    console.log(isIntegerPalindrome(element));
  });
}

printIntegersPalindrome([123, 323, 421, 121]);
//console.log(isIntegerPalindrome(123));
