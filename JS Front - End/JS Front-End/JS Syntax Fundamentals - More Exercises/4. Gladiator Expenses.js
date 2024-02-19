function calculateExpences(
  lostFightsCount,
  helmetPrice,
  swordPrice,
  shieldPrice,
  armorPrice
) {
  let expenses = 0;
  expenses += Math.floor(lostFightsCount / 2) * helmetPrice;
  expenses += Math.floor(lostFightsCount / 3) * swordPrice;
  expenses += Math.floor(lostFightsCount / 6) * shieldPrice;
  expenses += Math.floor(lostFightsCount / 12) * armorPrice;
  console.log(`Gladiator expenses: ${expenses.toFixed(2)} aureus`);
}

calculateExpences(23, 12.5, 21.5, 40, 200);
