function lockedProfile() {
	const buttons = Array.from(document.querySelectorAll("button"));
	buttons.forEach((button) => {
		button.addEventListener("click", (e) => {
			const lockRadioButton = e.currentTarget.parentElement.querySelector(
				'input[type="radio"]'
			);

			if (lockRadioButton.checked) {
				return;
			}
			const hiddenContent = e.currentTarget.parentElement.querySelector([
				'[id *= "Hidden"]',
			]);
			button.textContent =
				button.textContent === "Show more" ? "Hide it" : "Show more";
			hiddenContent.style.display =
				hiddenContent.style.display !== "block" ? "block" : "none";
		});
	});
}
