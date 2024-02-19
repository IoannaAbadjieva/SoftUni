function convertToObj(jsonString) {
  const person = JSON.parse(jsonString);
  Object.entries(person).forEach(([key, value]) =>
    console.log(`${key}: ${value}`)
  );
}

convertToObj('{"name": "George", "age": 40, "town": "Sofia"}');
convertToObj('{"name": "Peter", "age": 35, "town": "Plovdiv"}');
