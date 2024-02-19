function validatePassword(password) {
  function isLengthValid(password) {
    return password.length >= 6 && password.length <= 10;
  }

  function isCountOfDigitsValid(password) {
    const digits = password.match(/\d/g);
    return digits != null && digits.length >= 2;
  }

  function isPasswordOnlyOfLettersAndDigits(password) {
    const symbols = password.match(/[^A-Za-z0-9]/g);
    return symbols === null;
  }

  if (
    isLengthValid(password) &&
    isCountOfDigitsValid(password) &&
    isPasswordOnlyOfLettersAndDigits(password)
  ) {
    console.log("Password is valid");
    return;
  }

  if (!isLengthValid(password)) {
    console.log("Password must be between 6 and 10 characters");
  }

  if (!isPasswordOnlyOfLettersAndDigits(password)) {
    console.log("Password must consist only of letters and digits");
  }

  if (!isCountOfDigitsValid(password)) {
    console.log("Password must have at least 2 digits");
  }
}

validatePassword("MyPass@123");
