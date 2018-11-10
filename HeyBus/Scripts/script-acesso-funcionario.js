function fecharMenu() {
	const fecharMenu = document.querySelector("#menu-lateral-funcionario");
	const toggleAbrir = document.querySelector("#toggle-abriMenu");
	const iconFunc = document.querySelector(".icon-func-fechado")
	const iconBus = document.querySelector(".icon-bus-fechado")
	const iconRota = document.querySelector(".icon-rota-fechado")
	const iconSair = document.querySelector(".icon-sair-fechado")

	fecharMenu.classList.remove("aparecerMenu")
	toggleAbrir.classList.add("bar-fechado")
	toggleAbrir.classList.remove("d-none")
	iconFunc.classList.remove("d-none")
	iconBus.classList.remove("d-none")
	iconRota.classList.remove("d-none")
	iconSair.classList.remove("d-none")
}
function abrirMenu() {
	const fecharMenu = document.querySelector("#menu-lateral-funcionario");
	const toggleAbrir = document.querySelector("#toggle-abriMenu");
	const iconFunc = document.querySelector(".icon-func-fechado")
	const iconBus = document.querySelector(".icon-bus-fechado")
	const iconRota = document.querySelector(".icon-rota-fechado")
	const iconSair = document.querySelector(".icon-sair-fechado")

	fecharMenu.classList.add("aparecerMenu")
	toggleAbrir.classList.remove("bar-fechado")
	toggleAbrir.classList.add("d-none")
	iconFunc.classList.add("d-none")
	iconBus.classList.add("d-none")
	iconRota.classList.add("d-none")
	iconSair.classList.add("d-none")
}

var acc = document.getElementsByClassName("accordion");
var i;

for (i = 0; i < acc.length; i++) {
	acc[i].addEventListener("click", function () {
		this.classList.toggle("active");
		var panel = this.nextElementSibling;
		if (panel.style.maxHeight) {
			panel.style.maxHeight = null;
		} else {
			panel.style.maxHeight = panel.scrollHeight + "px";
		}
	});
}