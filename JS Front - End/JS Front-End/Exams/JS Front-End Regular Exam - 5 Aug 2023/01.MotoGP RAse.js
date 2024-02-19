function solve(input) {
	const count = input.shift();
	const ridersData = input.splice(0, count);
	const commands = input.splice(0);

	const commandRunner = {
		StopForFuel: makeStop,
		Overtaking: overtake,
		EngineFail: removeRider,
	};
	const riders = ridersData.reduce((acc, curr) => {
		const [rider, fuel, position] = curr.split("|");

		acc[rider] = { fuel: Number(fuel) > 100 ? 100 : Number(fuel), position };
		return acc;
	}, {});

	let line = commands.shift();
	while (line !== "Finish") {
		const [command, ...args] = line.split(" - ");
		commandRunner[command](...args);
		line = commands.shift();
	}

	Object.keys(riders).forEach((rider) => {
		console.log(`${rider}`);
		console.log(`  Final position: ${riders[rider].position}`);
	});

	function makeStop(rider, minimumFuel, changedPosition) {
		if (riders[rider].fuel > Number(minimumFuel)) {
			console.log(`${rider} does not need to stop for fuel!`);
			return;
		}

		riders[rider].position = changedPosition;
		console.log(
			`${rider} stopped to refuel but lost his position, now he is ${changedPosition}.`
		);
	}

	function overtake(rider1, rider2) {
		const rider1Position = riders[rider1].position;
		const rider2Position = riders[rider2].position;
		if (rider1Position < rider2Position) {
			riders[rider1].position = rider2Position;
			riders[rider2].position = rider1Position;

			console.log(`${rider1} overtook ${rider2}!`);
		}
	}

	function removeRider(rider, lapsLeft) {
		delete riders[rider];
		console.log(
			`${rider} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`
		);
	}
}
solve([
	"4",
	"Valentino Rossi|100|1",
	"Marc Marquez|90|3",
	"Jorge Lorenzo|80|4",
	"Johann Zarco|80|2",
	"StopForFuel - Johann Zarco - 90 - 5",
	"Overtaking - Marc Marquez - Jorge Lorenzo",
	"EngineFail - Marc Marquez - 10",
	"Finish",
]);
