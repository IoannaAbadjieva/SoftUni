function solve(count, type, day) {
  let totalPrice = 0;
  if (type === "Students") {
    if (day === "Friday") {
      totalPrice = count * 8.45;
    } else if (day === "Saturday") {
      totalPrice = count * 9.8;
    } else if (day === "Sunday") {
      totalPrice = count * 10.46;
    }

    if (count >= 30) {
      totalPrice -= 0.15 * totalPrice;
    }
  } else if (type === "Business") {
    if (count >= 100) {
      count -= 10;
    }
    if (day === "Friday") {
      totalPrice = count * 10.9;
    } else if (day === "Saturday") {
      totalPrice = count * 15.6;
    } else if (day === "Sunday") {
      totalPrice = count * 16;
    }
  } else if (type === "Regular") {
    if (day === "Friday") {
      totalPrice = count * 15;
    } else if (day === "Saturday") {
      totalPrice = count * 20;
    } else if (day === "Sunday") {
      totalPrice = count * 22.5;
    }

    if (count >= 10 && count <= 20) {
      totalPrice -= 0.05 * totalPrice;
    }
  }

  console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

solve(30, "Students", "Sunday");
solve(40, "Regular", "Saturday");

function calculatePrice(count, type, day) {
  const prices = {
    Students: {
      Friday: 8.45,
      Saturday: 9.8,
      Sunday: 10.46,
    },
    Business: {
      Friday: 10.9,
      Saturday: 15.6,
      Sunday: 16,
    },
    Regular: {
      Friday: 15,
      Saturday: 20,
      Sunday: 22.5,
    },
  };

  const cost = prices[type][day];
  let totalPrice = count * cost;

  if (type === "Business" && count >= 100) {
    totalPrice -= 10 * cost;
  } else if (type === "Students" && count >= 30) {
    totalPrice -= 0.15 * totalPrice;
  } else if (type === "regular" && count >= 10 && count <= 20) {
    totalPrice -= 0.05 * totalPrice;
  }

  console.log(`Total price: ${totalPrice.toFixed(2)}`);
}
calculatePrice(30, "Students", "Sunday");
calculatePrice(40, "Regular", "Saturday");
calculatePrice(99, "Business", "Saturday");
