$("a[href=\"#\"]").on("click", function (e) {
    return false;
});
var $item = $('.carousel-item');
var $wHeight = $(window).height();
$item.eq(0).addClass('active');
$item.height($wHeight);
$item.addClass('full-screen');

$('.carousel img').each(function () {
    var $src = $(this).attr('src');
    var $color = $(this).attr('data-color');
    $(this).parent().css({
        'background-image': 'url(' + $src + ')',
        'background-color': $color
    });
    $(this).remove();
});

$(window).on('resize', function () {
    $wHeight = $(window).height();
    $item.height($wHeight);
});

$('.carousel').carousel({
    interval: 6000,
    pause: "false"
});


function Enviar()
	{
		var Nome =document.getElementById("nome").value;
		var Email =document.getElementById("email").value;
		var Assunto = document.getElementById("assunto").value;
		var Mensagem = document.getElementById("mensagem").value;
		if (Nome == "") {
			$.notify({
				message: 'Preencha seu nome corretamente'
			}, {
					type: 'danger',
					timer: 1000,
				});
			document.getElementById("nome").focus();
			return false;
		}
 		else if(Email == ""){
			$.notify({
				message: 'Digite um e-mail valido'
			}, {
					type: 'danger',
					timer: 1000,
				});
			document.getElementById("email").focus();
			return false;
		}
		else if (Assunto == "") {
			$.notify({
				message: 'Escreva o assunto da sua mensagem'
			}, {
					type: 'danger',
					timer: 1000,
				});
			document.getElementById("assunto").focus();
			return false;
		}
 		else if(Mensagem == ""){
			$.notify({
				message: 'Escreva a mensagem que deseja nos enviar'
			}, {
					type: 'danger',
					timer: 1000,
				});
			document.getElementById("mensagem").focus();
			return false;
 		}
		else{
			$.notify({
				message: 'Mensagem enviada com sucesso!'
			}, {
					type: "success",
					timer: 1000,
				});
		document.getElementById("nome").value="";
		document.getElementById("email").value="";
		document.getElementById("assunto").value="";
		document.getElementById("mensagem").value = "";
		document.getElementById("nome").focus();
	}
}
function Clear() {
	document.getElementById("nome").value = "";
	document.getElementById("email").value = "";
	document.getElementById("assunto").value = "";
	document.getElementById("mensagem").value = "";
	document.getElementById("nome").focus();
}

window.onload = function () { scrollFunction() };
window.onresize = function () { scrollFunction() };
window.onscroll = function () { scrollFunction() };
const elemento = document.querySelector(".barra-menu");

function scrollFunction() {
	if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20 || window.innerWidth < 992) {
		elemento.classList.add("destaque-menu")
	} else {
		elemento.classList.remove("destaque-menu")
	}
}

$(document).ready(function () {
	$(".maskcpf").mask("999.999.999-99");
	$(".masktelefone").mask("(99) 9999-9999");
	$(".maskcelular").mask("(99) 9 9999-9999");
	$(".maskdata").mask("99/99/9999");
})