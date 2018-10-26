use HeyBus;
Create View Consultar_Funcionarios as
select cpf_Funcionario, nome_Funcionario, email_Funcionario, endereco_Funcionario, 
	   Acesso.login_Acesso 
       from Funcionario
       inner join Acesso
       on 
       Funcionario.id_Acesso = Acesso.id_Acesso;

Create View Consultar_Clientes as
select * from Cliente;

Create View Consultar_Rotas as 
select * from Rota;

Create View Consultar_Onibus as
select * from Onibus;

Create View Consultar_Viagens as
Select Rota.destino_Rota, Onibus.viacao_Onibus, Onibus.categoria_Onibus, data_Viagem, valor_Viagem, 
     Rota.itinerario_Rota, Rota.distancia_Rota, Onibus.id_Bancos
     from Viagem 
     inner join Rota 
     on 
     Viagem.id_Rota = Rota.id_Rota
     inner join 
     Onibus
     on
     Viagem.id_Onibus = Onibus.id_Onibus;
     
Create View Consultar_Passagens as
	 select Cliente.nome_Cliente, Rota.origem_Rota, Onibus.viacao_Onibus, Rota.destino_Rota,
     Viagem.data_Viagem, FormaPagamento.nome_FormPag, Passagem.cpf_Cliente, desconto_Passagem,
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
	
