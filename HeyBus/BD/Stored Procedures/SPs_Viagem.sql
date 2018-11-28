Use HeyBus;
/*<----------------Viagem-------------->*/
Delimiter $$
create procedure SP_Alterar_Viagem
(in id int, in dataVi varchar(25), valor decimal(4,2))
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
create procedure SP_Detalhes_Viagem_Ida
(in id int)
begin
	 Select Rota.destino_Rota, Onibus.viacao_Onibus, Onibus.categoria_Onibus, data_Ida, horario_Viagem, 
     valor_Viagem, Rota.distancia_Rota, id_Viagem
     from Viagem 
     inner join Rota
     on Viagem.id_Rota = Rota.id_Rota 
     inner join Onibus 
     on Viagem.id_Onibus = Onibus.id_Onibus
     where id_Viagem = id;
end $$
Delimiter ;

Delimiter $$
create procedure SP_Pesquisar_Viagens_Completo
(in dataPartida varchar(25), in origem varchar(30), in destino varchar(30), in dataVolta varchar(25))
begin
	Select id_Viagem, Rota.destino_Rota, Onibus.viacao_Onibus, Onibus.categoria_Onibus, data_Ida, data_Volta, horario_Viagem, 
     valor_Viagem, Rota.distancia_Rota
     from Viagem 
     inner join Rota
     on Viagem.id_Rota = Rota.id_Rota 
     inner join Onibus 
     on Viagem.id_Onibus = Onibus.id_Onibus
     where data_Ida = str_to_date(dataPartida, '%d/%m/%Y') AND data_Volta = str_to_date(dataVolta, '%d/%m/%Y')
     AND destino_Rota = destino AND origem_Rota = origem;
end $$
Delimiter ;

Delimiter $$
create procedure SP_Pesquisar_Viagens_Ida
(in dataPartida varchar(25), in origem varchar(30), in destino varchar(30))
begin
     Select id_Viagem, Rota.destino_Rota, Rota.origem_Rota, Onibus.viacao_Onibus, Onibus.categoria_Onibus, data_Ida, horario_Viagem, 
     valor_Viagem, Rota.distancia_Rota
     from Viagem 
     inner join Rota
     on Viagem.id_Rota = Rota.id_Rota 
     inner join Onibus 
     on Viagem.id_Onibus = Onibus.id_Onibus
     where data_Ida = str_to_date(dataPartida, '%d/%m/%Y') AND destino_Rota = destino AND origem_Rota = origem;
end $$
Delimiter ;

Delimiter $$
create procedure SP_Pesquisar_Viagens_Destino
(in origem varchar(30), in destino varchar(30))
begin
     Select id_Viagem, Rota.destino_Rota, Rota.origem_Rota, Onibus.viacao_Onibus, Onibus.categoria_Onibus, data_Ida, data_Volta, horario_Viagem, 
     valor_Viagem, Rota.distancia_Rota
     from Viagem 
     inner join Rota
     on Viagem.id_Rota = Rota.id_Rota 
     inner join Onibus 
     on Viagem.id_Onibus = Onibus.id_Onibus
     where destino_Rota = destino AND origem_Rota = origem order by curdate();
end $$
Delimiter ;
