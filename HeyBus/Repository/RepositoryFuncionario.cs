using Dapper;
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

        public bool Insert_Foreign_Func(Funcionario func)
        {
            bool voltar = false;
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("select count(id_Acesso) as id_Acesso from Acesso;", Conexao.conexao);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    func.id_Ac = Convert.ToInt32(dr["id_Acesso"]);
                    return true;
                }
                dr.Close();
                conn.fecharConexao();
            }catch(Exception ui)
            {
                dr.Close();
                conn.fecharConexao();
                return false;
                throw new Exception(ui.Message);
            }
            return voltar;
        }

        public bool Insert_Func(Funcionario func)
        {
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("SP_Cadastrar_Func", Conexao.conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cpf", func.cpf_Func);
                cmd.Parameters.AddWithValue("@nome", func.nome_Func);
                cmd.Parameters.AddWithValue("@email", func.email_Func);
                cmd.Parameters.AddWithValue("@endereco", func.endereco_Func);
                cmd.Parameters.AddWithValue("@acesso", func.id_Ac);
                cmd.ExecuteNonQuery();
                return true;
                conn.fecharConexao();
            }
            catch (Exception po)
            {
                conn.fecharConexao();
                return false;
                throw new Exception(po.Message);
            }
        }

        public bool Consultar_Func(Funcionario func)
        {
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("SP_Consultar_Func", Conexao.conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", func.id_Func);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    func.cpf_Func = dr["cpf_Funcionario"].ToString();
                    func.nome_Func = dr["nome_Funcionario"].ToString();
                    func.email_Func = dr["email_Funcionario"].ToString();
                    func.endereco_Func = dr["endereco_Funcionario"].ToString();
                    Acesso.usuario_Acesso = dr["login_Acesso"].ToString();
                    Acesso.senha_Acesso = dr["senha_Acesso"].ToString();
                }
                return true;
                dr.Close();
                conn.fecharConexao();            
            }catch(Exception lp)
            {
                dr.Close();
                conn.fecharConexao();
                return false;
                throw new Exception(lp.Message);
            }
        }

        public bool Update_Func(Funcionario func)
        {
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("SP_Alterar_Func", Conexao.conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cpf", func.cpf_Func);
                cmd.Parameters.AddWithValue("@nome", func.nome_Func);
                cmd.Parameters.AddWithValue("@email", func.email_Func);
                cmd.Parameters.AddWithValue("@endereco", func.endereco_Func);
                cmd.ExecuteNonQuery();
                return true;
                conn.fecharConexao();
            }
            catch (Exception kp)
            {
                throw new Exception(kp.Message);
                return false;
                conn.fecharConexao();
            }
        }
    }
}