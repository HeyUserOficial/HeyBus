use HeyBus;
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