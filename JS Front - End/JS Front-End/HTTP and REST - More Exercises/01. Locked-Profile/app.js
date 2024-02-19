async function lockedProfile() {
	const BaseURL = "http://localhost:3030/jsonstore/advanced/profiles";
	const container = document.querySelector("#container");

	const users = [];

	container.innerHTML = "";
	const usersInfo = await (await fetch(BaseURL)).json();

	Object.values(usersInfo).forEach((user) => {
		const main = document.createElement("main");
		main.setAttribute("id", "main");
		const userContainer = document.createElement("div");
		userContainer.classList.add("profile");

		const imageElement = document.createElement("img");
		imageElement.src = "./iconProfile2.png";
		imageElement.classList.add("userIcon");
		userContainer.appendChild(imageElement);

		const lockLabel = document.createElement("label");
		lockLabel.textContent = "Lock";
		userContainer.appendChild(lockLabel);

		const lockElement = document.createElement("input");
		lockElement.type = "radio";
		lockElement.name = `user${users.length + 1}Locked`;
		lockElement.value = "lock";
		lockElement.checked = true;
		userContainer.appendChild(lockElement);

		const unlockLabel = document.createElement("label");
		unlockLabel.textContent = "Unlock";
		userContainer.appendChild(unlockLabel);

		const unlockElement = document.createElement("input");
		unlockElement.type = "radio";
		unlockElement.name = `user${users.length + 1}Locked`;
		unlockElement.value = "unlock";
		userContainer.appendChild(unlockElement);

		userContainer.appendChild(document.createElement("hr"));

		const usernameLabel = document.createElement("label");
		usernameLabel.textContent = "Username";
		userContainer.appendChild(usernameLabel);

		const usernameElement = document.createElement("input");
		usernameElement.name = `user${users.length + 1}Username`;
		usernameElement.value = user.username;
		usernameElement.disabled = true;
		usernameElement.readOnly = true;
		userContainer.appendChild(usernameElement);

		const hidden = document.createElement("div");
		hidden.classList.add("hiddenInfo");
		hidden.setAttribute("id", `user${users.length + 1}HiddenFields`);
		hidden.appendChild(document.createElement("hr"));

		const emailLabel = document.createElement("label");
		emailLabel.textContent = "Email:";
		hidden.appendChild(emailLabel);

		const emailElement = document.createElement("input");
		emailElement.type = "email";
		emailElement.name = `user${users.length + 1}Email`;
		emailElement.value = user.email;
		emailElement.disabled = true;
		emailElement.readOnly = true;
		hidden.appendChild(emailElement);

		const ageLabel = document.createElement("label");
		ageLabel.textContent = "Age:";
		hidden.appendChild(ageLabel);

		const ageElement = document.createElement("input");
		ageElement.name = `user${users.length + 1}Age`;
		ageElement.type = "email";
		ageElement.value = user.age;
		ageElement.disabled = true;
		emailElement.readOnly = true;
		hidden.appendChild(ageElement);

		userContainer.appendChild(hidden);

		const showBtn = document.createElement("button");
		showBtn.textContent = "Show more";
		showBtn.addEventListener("click", (e) => {
			const currCheck = e.currentTarget.parentElement.querySelector(
				"input[value='lock']"
			);

			if (currCheck.checked) {
				return;
			}

			const hiddenFields = Array.from(
				e.currentTarget.parentElement.querySelectorAll(
					"[id*='HiddenFields'] input, [id*='HiddenFields'] label "
				)
			);

			hiddenFields.forEach((field) => {
				field.style.display =
					field.style.display !== "inline-block" ? "inline-block" : "none";
			});
			e.currentTarget.textContent =
				e.currentTarget.textContent === "Show more" ? "Hide it" : "Show more";
		});
		userContainer.appendChild(showBtn);

		main.appendChild(userContainer);

		container.appendChild(userContainer);

		users.push(user);
	});
}
