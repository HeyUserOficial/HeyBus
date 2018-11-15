use HeyBus;
/*<----------------Funcionário-------------->*/
Delimiter $$ 
create procedure SP_Cadastrar_Func
(in cpf char(14), in nome varchar(70), in email varchar(60), in endereco varchar(100), in login varchar(25), in senha varchar(25),
 in nivel char(15))
begin
start transaction;
   insert into Acesso (login_Acesso, senha_Acesso) 
    values(login, senha);
    
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