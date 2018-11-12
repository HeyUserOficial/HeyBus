Use HeyBus;
/*<----------------Passagem-------------->*/
Delimiter $$
create procedure SP_Comprar_Passagem
(in cliente int, in rota int, in onibus int, in viagem int, in formPag int, in cpf char(14), in desconto decimal(3,2), in valor decimal(3,2), in data_Compra datetime)
begin 
	 insert into Passagem(id_Cliente, id_Rota, id_Onibus, id_Viagem, id_FormPag, cpf, desconto_Passagem, valor_Passagem, valor_Passagem, data_Compra)
     values(cliente, rota, onibus, viagem, formPag, cpf, desconto, valor, data_Compra);
end $$
Delimiter ;

Delimiter $$ 
create procedure SP_Consultar_Passagem
(in id int)
begin 
	 select nome_Cliente.Cliente, origem_Rota.Rota, viacao_Onibus.Onibus, destino_Rota.Rota, data_Viagem.Viagem, nome_FormPag.FormaPagamento, cpf, desconto_Passagem,
     valor_Passagem, data_Compra
     from Passagem 
     inner join Cliente
     on 
     Passagem.id_Cliente = Cliente.id_Cliente
     inner join Rota
     on
     Passagem.id_Rota = Rota.id_Rota
     inner join Onibus
     on 
     Passagem.id_Onibus = Onibus.id_Onibus
     inner join Viagem
     on 
     Passagem.id_Viagem = Viagem.id_Viagem
     inner join FormaPagamento
     on
     Passagem.id_FormPag = FormaPagamento.id_FormPag
     where id_Passagem = id;
end $$
Delimiter ;