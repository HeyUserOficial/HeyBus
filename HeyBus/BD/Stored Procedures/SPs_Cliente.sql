Use HeyBus;
/*<----------------Cliente-------------->*/
Delimiter $$ 
create Procedure SP_Cadastrar_Cliente
(in cpf char(14), in nome varchar(70), in nascimento varchar(20),in tel char(20),in cel char(20),in email varchar(60),
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