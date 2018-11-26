Use HeyBus;
/*<----------------Passagem-------------->*/
Delimiter $$
create procedure SP_Comprar_Passagem
(in cliente int, in viagem int, in formPag int, in cpf char(14), in desconto decimal(4,2), in valor decimal(4,2), in data_Compra datetime)
begin 
	 insert into Passagem(id_Cliente, id_Viagem, id_FormPag, cpf, desconto_Passagem, valor_Passagem, valor_Passagem, data_Compra)
     values(cliente, viagem, formPag, cpf, desconto, valor, data_Compra);
end $$
Delimiter ;

Delimiter $$ 
create procedure SP_Consultar_Passagem
(in id int)
begin 
	 select nome_Cliente.Cliente, data_Viagem.Viagem, nome_FormPag.FormaPagamento, cpf, desconto_Passagem,
     valor_Passagem, data_Compra
     from Passagem 
     inner join Cliente
     on 
     Passagem.id_Cliente = Cliente.id_Cliente
     inner join Viagem
     on 
     Passagem.id_Viagem = Viagem.id_Viagem
     inner join FormaPagamento
     on
     Passagem.id_FormPag = FormaPagamento.id_FormPag
     where id_Passagem = id;
end $$
Delimiter ;