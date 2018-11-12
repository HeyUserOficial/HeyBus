Use HeyBus;
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