function solve(input) {
	const horses = input.shift().split("|");

	const commandRunner = {
		Retake: retakePosition,
		Trouble: trouble,
		Rage: rage,
		Miracle: miracle,
	};
	let line = input.shift();

	while (line !== "Finish") {
		const [command, ...args] = line.split(" ");
		commandRunner[command](...args);
		line = input.shift();
	}

	console.log(horses.join("->"));
	console.log(`The winner is: ${horses[horses.length - 1]}`);

	function retakePosition(overtakingHorse, overtakenHorse) {
		const overtakingHorsePosition = horses.indexOf(overtakingHorse);
		const overtakenHorsePosition = horses.indexOf(overtakenHorse);

		if (overtakingHorsePosition < overtakenHorsePosition) {
			horses[overtakenHorsePosition] = overtakingHorse;
			horses[overtakingHorsePosition] = overtakenHorse;

			console.log(`${overtakingHorse} retakes ${overtakenHorse}.`);
		}
	}

	function trouble(horse) {
		const horsePosition = horses.indexOf(horse);

		if (horsePosition > 0) {
			horses[horsePosition] = horses[horsePosition - 1];
			horses[horsePosition - 1] = horse;

			console.log(`Trouble for ${horse} - drops one position.`);
		}
	}

	function rage(horse) {
		const horsePosition = horses.indexOf(horse);
		const ragePosition =
			horsePosition + 2 < horses.length - 1
				? horsePosition + 2
				: horses.length - 1;

		horses.splice(horsePosition, 1);
		horses.splice(ragePosition, 0, horse);

		console.log(`${horse} rages 2 positions ahead.`);
	}

	function miracle() {
		const miracleHorse = horses.shift();
		horses.push(miracleHorse);
		console.log(`What a miracle - ${miracleHorse} becomes first.`);
	}
}

solve([
	"Fancy|Lilly",
	"Retake Lilly Fancy",
	"Trouble Lilly",
	"Trouble Lilly",
	"Finish",
	"Rage Lilly",
]);
