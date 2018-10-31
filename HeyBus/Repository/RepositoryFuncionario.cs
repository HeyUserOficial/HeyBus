using HeyBus.Connection;
using HeyBus.Models;
//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HeyBus.Repository
{
    public class RepositoryFuncionario 
    {/*
        MySqlCommand cmd;
        MySqlDataReader dr;
        Conexao conn = new Conexao();

        public void Insert_Func(Funcionario func)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_Cadastrar_Func", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@login", func.login_Acesso);
                    cmd.Parameters.AddWithValue("@senha", func.password_Acesso);
                    cmd.Parameters.AddWithValue("@nivel", func.level_Acesso);
                    cmd.Parameters.AddWithValue("@cpf", func.cpf_Funcionario);
                    cmd.Parameters.AddWithValue("@nome", func.nome_Funcionario);
                    cmd.Parameters.AddWithValue("@email", func.email_Funcionario);
                    cmd.Parameters.AddWithValue("@endereco", func.endereco_Funcionario);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception lj)
            {
                throw;
            }
        }

        public void Update_Func(Funcionario func)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_Alterar_Func", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cpf", func.cpf_Funcionario);
                    cmd.Parameters.AddWithValue("@nome", func.nome_Funcionario);
                    cmd.Parameters.AddWithValue("@email", func.email_Funcionario);
                    cmd.Parameters.AddWithValue("@endereco", func.endereco_Funcionario);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception hj)
            {
                throw;
            }
        }

        public IEnumerable<Funcionario> Consultar_Func()
        {
            Funcionario func = new Funcionario();
            List<Funcionario> funcList = new List<Funcionario>();
            try
            {
                using (cmd = new MySqlCommand("Select * from Consultar_Funcionarios", Conexao.conexao))
                {
                    conn.abrirConexao();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        func.id_Funcionario = Convert.ToInt32(dr["id_Funcionario"].ToString());
                        func.cpf_Funcionario = dr["cpf_Funcionario"].ToString();
                        func.nome_Funcionario = dr["nome_Funcionario"].ToString();
                        func.email_Funcionario = dr["email_Funcionario"].ToString();
                        func.endereco_Funcionario = dr["endereco_Funcionario"].ToString();
                        func.login_Acesso = dr["login_Acesso"].ToString();
                        funcList.Add(func);
                    }
                    dr.Close();
                    return funcList;
                }
            }catch(Exception kl)
            {
                throw;
            }   
        }
    */}
}