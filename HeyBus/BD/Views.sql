/*use HeyBus;
Create View Consultar_Funcionarios as
select cpf_Funcionario, nome_Funcionario, email_Funcionario, endereco_Funcionario, 
Acesso.login_Acesso from Funcionario inner join Acesso
on Funcionario.id_Acesso = Acesso.id_Acesso;