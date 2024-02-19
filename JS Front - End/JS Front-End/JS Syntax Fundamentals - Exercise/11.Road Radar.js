function solve(speed, zone) {
  const speedLimits = {
    motorway: 130,
    interstate: 90,
    city: 50,
    residential: 20,
  };

  const overspeed = speed - speedLimits[zone];

  if (overspeed <= 0) {
    console.log(`Driving ${speed} km/h in a ${speedLimits[zone]} zone`);
    return;
  }

  const status =
    overspeed <= 20
      ? "speeding"
      : overspeed <= 40
      ? "excessive speeding"
      : "reckless driving";

  console.log(
    `The speed is ${overspeed} km/h faster than the allowed speed of ${speedLimits[zone]} - ${status}`
  );
}

solve(40, "city");
solve(21, "residential");
solve(120, "interstate");
solve(200, "motorway");
