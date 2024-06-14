export function init() {
	const signUpButton = document.getElementById('signUp');
	const signInButton = document.getElementById('signIn');
	const container = document.getElementById('container');

	signUpButton.addEventListener('click', () => {
		container.classList.add("right-panel-active");
	});

	signInButton.addEventListener('click', () => {
		container.classList.remove("right-panel-active");
	});
}

export function signUpChange() {
	const container = document.getElementById('container');
	container.classList.add("right-panel-active")
}

export function signInChange() {
	const container = document.getElementById('container');
	container.classList.remove("right-panel-active")
}
