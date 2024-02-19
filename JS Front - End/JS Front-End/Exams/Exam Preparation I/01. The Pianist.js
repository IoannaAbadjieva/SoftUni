function solve(input) {
	const count = Number(input.shift());
	const piecesInfo = input.splice(0, count);
	const commands = input.splice(0);

	const commandRunner = {
		Add: addPiece,
		Remove: removePiece,
		ChangeKey: changeKey,
	};

	const pieces = piecesInfo.reduce((acc, curr) => {
		const [piece, composer, key] = curr.split("|");
		acc[piece] = { composer, key };
		return acc;
	}, {});

	let line = commands.shift();
	while (line !== "Stop") {
		const [command, ...args] = line.split("|");
		commandRunner[command](args);
		line = commands.shift();
	}

	function addPiece(args) {
		const [piece, composer, key] = args;

		if (pieces.hasOwnProperty(piece)) {
			console.log(`${piece} is already in the collection!`);
			return;
		}

		pieces[piece] = { composer, key };
		console.log(`${piece} by ${composer} in ${key} added to the collection!`);
	}

	Object.entries(pieces).forEach(([piece, { composer, key }]) => {
		console.log(`${piece} -> Composer: ${composer}, Key: ${key}`);
	});

	function removePiece(args) {
		const [piece] = args;
		if (!pieces.hasOwnProperty(piece)) {
			console.log(
				`Invalid operation! ${piece} does not exist in the collection.`
			);
			return;
		}

		delete pieces[piece];
		console.log(`Successfully removed ${piece}!`);
	}

	function changeKey(args) {
		const [piece, newkey] = args;

		if (!pieces.hasOwnProperty(piece)) {
			console.log(
				`Invalid operation! ${piece} does not exist in the collection.`
			);
			return;
		}

		pieces[piece].key = newkey;
		console.log(`Changed the key of ${piece} to ${newkey}!`);
	}
}

// solve([
// 	"3",
// 	"Fur Elise|Beethoven|A Minor",
// 	"Moonlight Sonata|Beethoven|C# Minor",
// 	"Clair de Lune|Debussy|C# Minor",
// 	"Add|Sonata No.2|Chopin|B Minor",
// 	"Add|Hungarian Rhapsody No.2|Liszt|C# Minor",
// 	"Add|Fur Elise|Beethoven|C# Minor",
// 	"Remove|Clair de Lune",
// 	"ChangeKey|Moonlight Sonata|C# Major",
// 	"Stop",
// ]);

solve([
	"4",
	"Eine kleine Nachtmusik|Mozart|G Major",
	"La Campanella|Liszt|G# Minor",
	"The Marriage of Figaro|Mozart|G Major",
	"Hungarian Dance No.5|Brahms|G Minor",
	"Add|Spring|Vivaldi|E Major",
	"Remove|The Marriage of Figaro",
	"Remove|Turkish March",
	"ChangeKey|Spring|C Major",
	"Add|Nocturne|Chopin|C# Minor",
	"Stop",
]);
