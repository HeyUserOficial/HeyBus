function fecharMenu() {
	const fecharMenu = document.querySelector("#menu-lateral-funcionario");
	const toggleAbrir = document.querySelector("#toggle-abriMenu");
	const iconFunc = document.querySelector(".icon-func-fechado")
	const iconBus = document.querySelector(".icon-bus-fechado")
	const iconRota = document.querySelector(".icon-rota-fechado")
	const iconSair = document.querySelector(".icon-sair-fechado")
	const iconCliente = document.querySelector(".icon-cliente-fechado")
	const iconViagem = document.querySelector(".icon-viagem-fechado")
	const iconHome = document.querySelector(".icon-home-fechado")
	const a = document.querySelector("#accordion-nav-func")
	const b = document.querySelector("#accordion-nav-bus")
	const c = document.querySelector("#accordion-nav-rota")
	const d = document.querySelector("#accordion-nav-cliente")
	const e = document.querySelector("#accordion-nav-viagem")
	const f = document.querySelector("#accordion-nav-home")

	fecharMenu.classList.remove("aparecerMenu")
	toggleAbrir.classList.add("bar-fechado")
	toggleAbrir.classList.remove("d-none")
	iconFunc.classList.remove("d-none")
	iconBus.classList.remove("d-none")
	iconRota.classList.remove("d-none")
	iconSair.classList.remove("d-none")
	iconCliente.classList.remove("d-none")
	iconViagem.classList.remove("d-none")
	iconHome.classList.remove("d-none")
	a.classList.remove("active")
	b.classList.remove("active")
	c.classList.remove("active")
	d.classList.remove("active")
	e.classList.remove("active")
	f.classList.remove("active")

	$("#panelFunc").removeAttr('style');
	$("#panelBus").removeAttr('style');
	$("#panelRota").removeAttr('style');
	$("#panelCliente").removeAttr('style');
	$("#panelViagem").removeAttr('style');
}
function abrirMenu() {
	const fecharMenu = document.querySelector("#menu-lateral-funcionario");
	const toggleAbrir = document.querySelector("#toggle-abriMenu");
	const iconFunc = document.querySelector(".icon-func-fechado")
	const iconBus = document.querySelector(".icon-bus-fechado")
	const iconRota = document.querySelector(".icon-rota-fechado")
	const iconSair = document.querySelector(".icon-sair-fechado")
	const iconCliente = document.querySelector(".icon-cliente-fechado")
	const iconViagem = document.querySelector(".icon-viagem-fechado")
	const iconHome = document.querySelector(".icon-home-fechado")

	fecharMenu.classList.add("aparecerMenu")
	toggleAbrir.classList.remove("bar-fechado")
	toggleAbrir.classList.add("d-none")
	iconFunc.classList.add("d-none")
	iconBus.classList.add("d-none")
	iconRota.classList.add("d-none")
	iconSair.classList.add("d-none")
	iconCliente.classList.add("d-none")
	iconViagem.classList.add("d-none")
	iconHome.classList.add("d-none")
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

$(document).ready(function () {
	$(".maskcpf").mask("999.999.999-99");
})

$('.tbResizable').resizableColumns();