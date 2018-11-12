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
(in usuario varchar(25), in senha varchar(25))
begin 
	 select * from Acesso where login_Acesso = login and senha_Acesso = senha;
end $$
Delimiter ;