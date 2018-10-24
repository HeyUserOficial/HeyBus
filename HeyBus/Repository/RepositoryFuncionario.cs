//using Dapper;
using HeyBus.Connection;
using HeyBus.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HeyBus.Repository
{
    public class RepositoryFuncionario 
    {
        MySqlCommand cmd;
        MySqlDataReader dr;
        Conexao conn = new Conexao();

        public void Insert_Func(Funcionario func)
        {
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("SP_Cadastrar_Func", Conexao.conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cpf", func.cpf_Funcionario);
                cmd.Parameters.AddWithValue("@nome", func.nome_Funcionario);
                cmd.Parameters.AddWithValue("@email", func.email_Funcionario);
                cmd.Parameters.AddWithValue("@endereco", func.endereco_Funcionario);
                cmd.Parameters.AddWithValue("@acesso", func.id_Acesso);
                cmd.ExecuteNonQuery();
            }
            catch (Exception lj)
            {
                throw;
            }
            finally
            {
                conn.fecharConexao();
            }
        }

        public void Update_Func(Funcionario func)
        {
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("SP_Alterar_Func", Conexao.conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cpf", func.cpf_Funcionario);
                cmd.Parameters.AddWithValue("@nome", func.nome_Funcionario);
                cmd.Parameters.AddWithValue("@email", func.email_Funcionario);
                cmd.Parameters.AddWithValue("@endereco", func.endereco_Funcionario);
                cmd.ExecuteNonQuery();
            }
            catch (Exception hj)
            {
                throw;
            }
            finally
            {
                conn.fecharConexao();
            }
        }

        public IEnumerable<Funcionario> Consultar_Func()
        {
            Funcionario func = new Funcionario();
            List<Funcionario> funcList = new List<Funcionario>();
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("Select * from Consultar_Funcs", Conexao.conexao);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    func.cpf_Funcionario = dr["cpf_Funcionario"].ToString();
                    func.nome_Funcionario = dr["nome_Funcionario"].ToString();
                    func.email_Funcionario = dr["email_Funcionario"].ToString();
                    func.endereco_Funcionario = dr["endereco_Funcionario"].ToString();
                    func.usuario_Funcionario = dr["login_Acesso"].ToString();
                    funcList.Add(func);
                }
            }catch(Exception kl)
            {
                throw;
            }
            finally
            {
                conn.fecharConexao();
            }
            return funcList;
        }
    }
}