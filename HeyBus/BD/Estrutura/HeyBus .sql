drop database if exists HeyBus;
create database if not exists HeyBus;
use HeyBus;
create table if not exists Acesso(
id_Acesso int auto_increment not null,
login_Acesso varchar(25),
senha_Acesso varchar(25),
nivel_Acesso char(15),
primary key (id_Acesso)
)ENGINE = innodb;

create table if not exists Cliente(
id_Cliente int auto_increment not null,
cpf_Cliente char(14),
nome_Cliente varchar(70),
nascimento_Cliente date,
tel_Cliente char(20),
cel_Cliente char(20),
email_Cliente varchar(60),
email_Verify bit(1),
ativacao_Cliente char(38) UNIQUE,
usuario_Cliente varchar(25),
senha_Cliente varchar(30),
primary key (id_Cliente)
) ENGINE = innodb;


create table if not exists Funcionario(
id_Funcionario int auto_increment not null,
cpf_Funcionario char(14),
nome_Funcionario varchar(70),
email_Funcionario varchar(60),
endereco_Funcionario varchar(100),
id_Acesso int,
primary key (id_Funcionario)
)ENGINE = innodb;
alter table Funcionario
add foreign key(id_Acesso)
references Acesso(id_Acesso);


create table if not exists Rota(
id_Rota int auto_increment not null,
origem_Rota varchar(60),
destino_Rota varchar(60),
distancia_Rota char(10),
primary key(id_Rota)
)ENGINE = innodb;

create table if not exists Bancos(
id_Bancos int auto_increment not null,
num_Banco int,
primary key(id_Bancos)
)ENGINE = innodb;

insert into Bancos(num_Banco) values(1);
insert into Bancos(num_Banco) values(2);
insert into Bancos(num_Banco) values(3);
insert into Bancos(num_Banco) values(4);
insert into Bancos(num_Banco) values(5);
insert into Bancos(num_Banco) values(6);
insert into Bancos(num_Banco) values(7);
insert into Bancos(num_Banco) values(8);
insert into Bancos(num_Banco) values(9);
insert into Bancos(num_Banco) values(10);
insert into Bancos(num_Banco) values(11);
insert into Bancos(num_Banco) values(12);
insert into Bancos(num_Banco) values(13);
insert into Bancos(num_Banco) values(14);
insert into Bancos(num_Banco) values(15);
insert into Bancos(num_Banco) values(16);
insert into Bancos(num_Banco) values(17);
insert into Bancos(num_Banco) values(18);
insert into Bancos(num_Banco) values(19);
insert into Bancos(num_Banco) values(20);
insert into Bancos(num_Banco) values(21);
insert into Bancos(num_Banco) values(22);
insert into Bancos(num_Banco) values(23);
insert into Bancos(num_Banco) values(24);
insert into Bancos(num_Banco) values(25);
insert into Bancos(num_Banco) values(26);
insert into Bancos(num_Banco) values(27);
insert into Bancos(num_Banco) values(28);
insert into Bancos(num_Banco) values(29);
insert into Bancos(num_Banco) values(30);
insert into Bancos(num_Banco) values(31);
insert into Bancos(num_Banco) values(32);
insert into Bancos(num_Banco) values(33);
insert into Bancos(num_Banco) values(34);
insert into Bancos(num_Banco) values(35);
insert into Bancos(num_Banco) values(36);
insert into Bancos(num_Banco) values(37);
insert into Bancos(num_Banco) values(38);
insert into Bancos(num_Banco) values(39);
insert into Bancos(num_Banco) values(40);
insert into Bancos(num_Banco) values(41);
insert into Bancos(num_Banco) values(42);
insert into Bancos(num_Banco) values(43);
insert into Bancos(num_Banco) values(44);
insert into Bancos(num_Banco) values(45);
insert into Bancos(num_Banco) values(46);
insert into Bancos(num_Banco) values(47);
insert into Bancos(num_Banco) values(48);
insert into Bancos(num_Banco) values(49);
insert into Bancos(num_Banco) values(50);

create table if not exists Onibus(
id_Onibus int auto_increment not null,
viacao_Onibus varchar(30),
categoria_Onibus varchar(30),
id_Bancos int,
manutencao_Onibus char(15),
primary key(id_Onibus)
)ENGINE = innodb;
alter table Onibus
add foreign key(id_Bancos)
references Bancos(id_Bancos);

create table if not exists Viagem(
id_Viagem int auto_increment not null,
id_Rota int,
id_Onibus int,
data_Ida date,
data_Volta date,
valor_Viagem decimal(4,2),
horario_Viagem time,
primary key(id_Viagem)
)ENGINE = innodb;
alter table Viagem 
add foreign key(id_Rota)
references Rota(id_Rota);
alter table Viagem 
add foreign key(id_Onibus)
references Onibus(id_Onibus);

create table if not exists FormaPagamento(
id_FormPag int auto_increment not null,
nome_FormPag char(15),
primary key(id_FormPag)
)ENGINE = innodb;
 
create table if not exists Passagem(
id_Passagem int auto_increment not null,
id_Cliente int,
id_Viagem int,
id_FormPag int,
poltrona int,
cpf char(14),
desconto_Passagem decimal(4,2),
valor_Passagem decimal(4,2),
data_Compra datetime,
primary key(id_Passagem)
)ENGINE = innodb;
alter table Passagem
add foreign key(id_Cliente)
references Cliente(id_Cliente);
alter table Passagem
add foreign key(id_Viagem)
references Viagem(id_Viagem);
alter table Passagem
add foreign key(id_FormPag)
references FormaPagamento(id_FormPag);

create table if not exists Cartao(
id_Cartao int auto_increment not null,
num_Cartao int,
val_Cartao date,
nome_Cartao varchar(50),
bandeira_Cartao char(40),
codigo_Seg int,
primary key (id_Cartao)
)ENGINE = innodb;
alter table Cartao
add column id_Cliente int;
alter table Cartao
add foreign key(id_Cliente)
references Cliente(id_Cliente);