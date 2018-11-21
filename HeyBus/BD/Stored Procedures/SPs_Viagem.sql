Use HeyBus;
/*<----------------Viagem-------------->*/
Delimiter $$
create procedure SP_Cadastrar_Viagem
(in rota int, in onibus int, in dataVi varchar(25), in horario varchar(10), in valor decimal(3,2))
begin
     insert into Viagem(id_Rota, id_Onibus, data_Viagem, horario_Viagem, valor_Viagem)
     values(rota, onibus, dataVi, horario, valor);
end $$
Delimiter ;


Delimiter $$ 
create procedure SP_Consultar_Viagem
(in id int)
begin 
	 Select Rota.destino_Rota, Onibus.viacao_Onibus, Onibus.categoria_Onibus, data_Viagem, horario_Viagem, 
     valor_Viagem, Rota.distancia_Rota, Onibus.id_Bancos
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

Delimiter $$
create procedure SP_Detalhes_Viagem
(in id int)
begin
	 Select Rota.destino_Rota, Onibus.viacao_Onibus, Onibus.categoria_Onibus, data_Viagem, horario_Viagem, 
     valor_Viagem, Rota.distancia_Rota, Onibus.id_Bancos, id_Viagem
     from Viagem 
     inner join Rota
     on Viagem.id_Rota = Rota.id_Rota 
     inner join Onibus 
     on Viagem.id_Onibus = Onibus.id_Onibus
     where id_Viagem = id;
end $$
Delimiter ;