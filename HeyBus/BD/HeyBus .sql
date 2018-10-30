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
usuario_Cliente varchar(25),
senha_Cliente varchar(25),
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
itinerario_Rota time,
distancia_Rota char(10),
primary key(id_Rota)
)ENGINE = innodb;

create table if not exists Bancos(
id_Bancos int auto_increment not null,
num_Banco int,
primary key(id_Bancos)
)ENGINE = innodb;

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
data_Viagem date,
valor_Viagem decimal(3,2),
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
id_Rota int,
id_Onibus int,
id_Viagem int,
id_FormPag int,
cpf_Cliente char(14),
desconto_Passagem decimal(3,2),
valor_Passagem decimal(3,2),
data_Compra datetime,
primary key(id_Passagem)
)ENGINE = innodb;
alter table Passagem
add foreign key(id_Cliente)
references Cliente(id_Cliente);
alter table Passagem
add foreign key(id_Onibus)
references Onibus(id_Onibus);
alter table Passagem
add foreign key(id_Rota)
references Rota(id_Rota);
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