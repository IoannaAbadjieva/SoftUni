function solve(input) {
	const count = Number(input.shift());
	const tasksData = input.splice(0, count);

	const commandsArgs = input.splice(0);

	const commandParser = {
		"Add New": addNewTask,
		"Change Status": changeStatus,
		"Remove Task": removeTask,
	};

	const tasks = tasksData.reduce((acc, curr) => {
		const [assignee, taskId, title, status, points] = curr.split(":");
		if (!acc.hasOwnProperty(assignee)) {
			acc[assignee] = [];
		}
		acc[assignee].push({ taskId, title, status, points: Number(points) });
		return acc;
	}, {});

	commandsArgs.forEach((line) => {
		[command, ...args] = line.split(":");
		commandParser[command](args);
	});

	const toDoTasksTotalPoints = calculateStatusTotalPoints("ToDo");
	const inProgressTasksTotalPoints = calculateStatusTotalPoints("In Progress");
	const codeReviewTasksTotalPoints = calculateStatusTotalPoints("Code Review");
	const doneTasksTotalPoints = calculateStatusTotalPoints("Done");

	console.log(`ToDo: ${toDoTasksTotalPoints}pts`);
	console.log(`In Progress: ${inProgressTasksTotalPoints}pts`);
	console.log(`Code Review: ${codeReviewTasksTotalPoints}pts`);
	console.log(`Done Points: ${doneTasksTotalPoints}pts`);

	if (
		doneTasksTotalPoints <
		inProgressTasksTotalPoints +
			codeReviewTasksTotalPoints +
			toDoTasksTotalPoints
	) {
		console.log("Sprint was unsuccessful...");
	} else {
		console.log("Sprint was successful!");
	}

	function addNewTask(args) {
		const [assignee, taskId, title, status, points] = args;
		if (!tasks.hasOwnProperty(assignee)) {
			console.log(`Assignee ${assignee} does not exist on the board!`);
			return;
		}

		tasks[assignee].push({ taskId, title, status, points: Number(points) });
	}

	function changeStatus(args) {
		const [assignee, taskId, newStatus] = args;
		if (!tasks.hasOwnProperty(assignee)) {
			console.log(`Assignee ${assignee} does not exist on the board!`);
			return;
		}

		const task = tasks[assignee].find((t) => t.taskId === taskId);

		if (!task) {
			console.log(`Task with ID ${taskId} does not exist for ${assignee}!`);
			return;
		}

		task.status = newStatus;
	}

	function removeTask(args) {
		const [assignee, index] = args;

		if (!tasks.hasOwnProperty(assignee)) {
			console.log(`Assignee ${assignee} does not exist on the board!`);
			return;
		}

		if (index < 0 || index >= tasks[assignee].length) {
			console.log("Index is out of range!");
			return;
		}

		tasks[assignee].splice(index, 1);
	}

	function calculateStatusTotalPoints(status) {
		return Object.values(tasks)
			.flat()
			.filter((t) => t.status === status)
			.reduce((acc, curr) => {
				return acc + curr.points;
			}, 0);
	}
}

solve([
	"4",
	"Kiril:BOP-1213:Fix Typo:Done:1",
	"Peter:BOP-1214:New Products Page:In Progress:2",
	"Mariya:BOP-1215:Setup Routing:ToDo:8",
	"Georgi:BOP-1216:Add Business Card:Code Review:3",
	"Add New:Sam:BOP-1237:Testing Home Page:Done:3",
	"Change Status:Georgi:BOP-1216:Done",
	"Change Status:Will:BOP-1212:In Progress",
	"Remove Task:Georgi:3",
	"Change Status:Mariya:BOP-1215:Done",
]);
