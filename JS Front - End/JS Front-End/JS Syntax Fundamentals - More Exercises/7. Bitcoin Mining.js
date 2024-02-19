function miningBitcoins(yield) {
  const prices = {
    bitcoin: 11949.16,
    gold: 67.51,
  };

  let bitcoinsCount = 0;
  let furstPurchaseDay = 0;
  let money = 0;

  for (let i = 0; i < yield.length; i++) {
    let profit = yield[i] * prices.gold;
    if ((i + 1) % 3 === 0) {
      profit -= 0.3 * profit;
    }

    money += profit;
    if (money >= prices.bitcoin) {
      bitcoinsCount += Math.floor(money / prices.bitcoin);
      money -= prices.bitcoin * Math.floor(money / prices.bitcoin);
      if (furstPurchaseDay === 0) {
        furstPurchaseDay = i + 1;
      }
    }
  }

  console.log(`Bought bitcoins: ${bitcoinsCount}`);
  if (furstPurchaseDay > 0) {
    console.log(`Day of the first purchased bitcoin: ${furstPurchaseDay}`);
  }
  console.log(`Left money: ${money.toFixed(2)} lv.`);
}

miningBitcoins([100, 200, 300]);
