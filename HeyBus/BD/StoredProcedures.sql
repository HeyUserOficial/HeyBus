Use HeyBus;
/*<----------------Acesso-------------->*/
Delimiter $$
create Procedure SP_Alterar_Acesso
(in id int, in login varchar(25), in senha varchar(25))
begin
	update Acesso set
					 login_Acesso = login,
					 senha_Acesso = senha
	where
	     				 id_Acesso = id;
end $$
Delimiter ;

Delimiter $$
create procedure SP_Efetuar_Acesso
(in login varchar(25), in senha varchar(25))
begin 
	 select * from Acesso where login_Acesso = login and senha_Acesso = senha;
end $$
Delimiter ;

/*<----------------Cliente-------------->*/
Delimiter $$ 
create Procedure SP_Cadastrar_Cliente
(in cpf char(14),in nome varchar(70),in nascimento varchar(20),in tel char(20),in cel char(20),in email varchar(60),
 in usuario varchar(25), in senha varchar(30))
begin 
	insert into Cliente (cpf_Cliente, nome_Cliente, nascimento_Cliente, tel_Cliente, cel_Cliente,
    email_Cliente, usuario_Cliente, senha_Cliente) values (cpf, nome, nascimento, tel, cel, email, usuario, senha);
end $$
Delimiter ;


Delimiter $$ 
create procedure SP_Login_Cliente
(in usuario varchar(25), in senha varchar(25))
begin 
	 Select usuario_Cliente, senha_Cliente from Cliente
     where
		  usuario_Cliente = usuario 
          and 
          senha_Cliente = senha;
end $$
Delimiter ;

Delimiter $$ 
create Procedure SP_Atualizar_Cliente
(in id int, in cpf char(14), in nome varchar(70), in nascimento varchar(20), in tel char(20), in cel char(20), in email varchar(60),
in usuario varchar(25), senha varchar(25))
begin 
	update Cliente set 
					  cpf_Cliente = cpf,
					  nome_Cliente = nome,
                      nascimento_Cliente = nascimento,
                      tel_Cliente = tel,
                      cel_Cliente = cel,
                      email_Cliente = email,
                      usuario_Cliente = usuario,
                      senha_Cliente = senha
	where 
					  id_Cliente = id;
end $$
Delimiter ;

Delimiter $$
create Procedure SP_Deletar_Cliente
(in id int)
begin 
	delete from Cliente where id_Cliente = id;
end $$
Delimiter ;

Delimiter $$
create Procedure SP_Consultar_Cliente
(in id int)
begin 
	select * from Cliente where id_Cliente = id;
end $$
Delimiter ;

/*<----------------Funcionário-------------->*/
Delimiter $$ 
create procedure SP_Cadastrar_Func
(in cpf char(14), in nome varchar(70), in email varchar(60), in endereco varchar(100), in login varchar(25), in senha varchar(25),
 in nivel char(15))
begin
start transaction;
   insert into Acesso (login_Acesso, senha_Acesso, nivel_Acesso) 
    values(login, senha, nivel);
    
	insert into Funcionario(cpf_Funcionario, nome_Funcionario, email_Funcionario, endereco_Funcionario, id_Acesso)
	values(cpf, nome, email, endereco, last_insert_id());
commit;
end $$
Delimiter ;

Delimiter $$
create procedure SP_Alterar_Func
(in id int, in cpf char(14), in nome varchar(70), in email varchar(60), in endereco varchar(100))
begin 
	 update Funcionario set
						   cpf_Funcionario = cpf,
						   nome_Funcionario = nome,
						   email_Funcionario = email,
						   endereco_Funcionario = endereco
	where
						   id_Funcionario = id;
end $$
Delimiter ;

Delimiter $$
create procedure SP_Consultar_Func
(in id int)
begin
	select cpf_Funcionario, nome_Funcionario, email_Funcionario, endereco_Funcionario, 
	Acesso.login_Acesso, Acesso.senha_Acesso from Funcionario inner join Acesso
	on Funcionario.id_Acesso = Acesso.id_Acesso where id_Funcionario = id;
end $$
Delimiter ;

/*<----------------Rota-------------->*/
Delimiter $$ 
create procedure SP_Cadastrar_Rota
(in origem varchar(60), in destino varchar(60), in distancia char(10))
begin
	insert into Rota(origem_Rota, destino_Rota, distancia_Rota)
    values(origem, destino, distancia);
end $$
Delimiter ;

Delimiter $$
create procedure SP_Consultar_Rota
(in id int)
begin
	 Select * from Rota where id_Rota = id;
end $$
Delimiter ;

Delimiter $$
create procedure SP_Alterar_Rota
(in id int, in origem varchar(60), in destino varchar(60), in distancia char(10))
begin
	 update Rota set 
					origem_Rota = origem,
                    destino_Rota = destino, 
                    distancia_Rota = distancia
	 where
					id_Rota = id;
end $$
Delimiter ;

/*<----------------Ônibus-------------->*/
Delimiter $$
create procedure SP_Cadastrar_Onibus
(in viacao varchar(30), in categoria varchar(30), in bancos int, in manutencao char(15))
begin
	 insert into Onibus(viacao_Onibus, categoria_Onibus, id_Bancos, manutencao_Onibus)
     values(viacao, categoria, bancos, manutencao);
end $$ 
Delimiter ;

Delimiter $$
create procedure SP_Consultar_Onibus
(in id int)
begin 
	 Select * from Onibus where id_Onibus = id;
end $$
Delimiter ;

Delimiter $$
create procedure SP_Alterar_Onibus
(in id int, in manutencao char(15))
begin
	update Onibus set 
					 manutencao_Onibus = manutencao
	where 
					 id_Onibus = id;
end $$
Delimiter ;


/*<----------------Viagem-------------->*/
Delimiter $$
create procedure SP_Cadastrar_Viagem
(in rota int, in onibus int, in dataVi date, in valor decimal(3,2))
begin
     insert into Viagem(id_Rota, id_Onibus, data_Viagem, valor_Viagem)
     values(rota, onibus, dataVi, valor);
end $$
Delimiter ;


Delimiter $$ 
create procedure SP_Consultar_Viagem
(in id int)
begin 
	 Select destino_Rota.Rota, viacao_Onibus.Onibus, categoria_Onibus.Onibus, data_Viagem, valor_Viagem,
     distancia_Rota.Rota, id_Bancos.Onibus
     from Viagem 
     inner join Rota
     on Viagem.id_Rota = Rota.id_Rota 
     inner join Onibus 
     on Viagem.id_Onibus = Onibus.id_Onibus
     where id_Viagem = id;
end $$
Delimiter ; 

Delimiter $$
create procedure SP_Alterar_Viagem
(in id int, in dataVi datetime, valor decimal(3,2))
begin
	 update Viagem set 
					  data_Viagem_Viagem = dataVi,
                      valor_Viagem = valor
	 where
					  id_Viagem = id;
end $$
Delimiter ;

Delimiter $$
create procedure SP_Deletar_Viagem
(in id int)
begin 
	 delete from Viagem 
     where id_Viagem = id;
end $$
Delimiter ;

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

