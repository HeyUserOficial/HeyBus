/*use HeyBus;
Create View Consultar_Funcionarios as
select cpf_Funcionario, nome_Funcionario, email_Funcionario, endereco_Funcionario, 
Acesso.login_Acesso from Funcionario inner join Acesso
on Funcionario.id_Acesso = Acesso.id_Acesso;
*/

/*Create View Consultar_Clientes as
select * from Cliente;
*/

/*Create View Consultar_Rotas as 
select * from Rota;
*/

/*Create View Consultar_Onibus
select * from Onibus;*/

/*Create View Consultar_Viagens as
Select destino_Rota.Rota, viacao_Onibus.Onibus, categoria_Onibus.Onibus, data_Viagem, valor_Viagem,
     itinerario_Rota.Rota, distancia_Rota.Rota, id_Bancos.Onibus
     from Viagem 
     inner join Rota
     on Viagem.id_Rota = Rota.id_Rota 
     inner join Onibus 
     on Viagem.id_Onibus = Onibus.id_Onibus;
*/

/*Create View Consultar_Passagens as
	 select nome_Cliente.Cliente, origem_Rota.Rota, viacao_Onibus.Onibus, destino_Rota.Rota, data_Viagem.Viagem, nome_FormPag.FormaPagamento, cpf_Cliente, desconto_Passagem,
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
     Passagem.id_FormPag = FormaPagamento.id_FormPag;
	*/

