//using Dapper;
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
    public class RepositoryCliente
    {/*

        MySqlCommand cmd;
        MySqlDataReader dr;
        Conexao conn = new Conexao();


        public bool Insert_Cliente(Cliente cli)
        {
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("SP_Cadastrar_Cliente", Conexao.conexao);
                cmd.Parameters.AddWithValue("@cpf", cli.cpf_Cliente);
                cmd.Parameters.AddWithValue("@nome", cli.nome_Cliente);
                cmd.Parameters.AddWithValue("@nascimento", cli.nascimento_Cliente);
                cmd.Parameters.AddWithValue("@tel", cli.tel_Cliente);
                cmd.Parameters.AddWithValue("@cel", cli.cel_Cliente);
                cmd.Parameters.AddWithValue("@email", cli.email_Cliente);
                cmd.Parameters.AddWithValue("@usuario", cli.usuario_Cliente);
                cmd.Parameters.AddWithValue("@senha", cli.senha_Cliente);
                cmd.ExecuteNonQuery();
                return true;
                conn.fecharConexao();
            }
            catch (Exception io)
            {
                throw new Exception(io.Message);
                conn.fecharConexao();
                return false;
            }
        }

        public bool Update_Cliente(Cliente cli)
        {
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("SP_Atualizar_Cliente", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cpf", cli.cpf_Cliente);
                cmd.Parameters.AddWithValue("@nome", cli.nome_Cliente);
                cmd.Parameters.AddWithValue("@nascimento", cli.nascimento_Cliente.Date);
                cmd.Parameters.AddWithValue("@tel", cli.tel_Cliente);
                cmd.Parameters.AddWithValue("@cel", cli.cel_Cliente);
                cmd.Parameters.AddWithValue("@email", cli.email_Cliente);
                cmd.Parameters.AddWithValue("@usuario", cli.usuario_Cliente);
                cmd.Parameters.AddWithValue("@senha", cli.senha_Cliente);
                cmd.ExecuteNonQuery();
                return true;
                conn.fecharConexao();
            }
            catch (Exception ui)
            {
                throw;
                return false;
                
            }
            finally
            {
                conn.fecharConexao();
            }
        }

        public IEnumerable<Cliente> Consultar_Cliente()
        {
            Cliente cli = new Cliente();
            List<Cliente> clit = new List<Cliente>();
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("Select * from Cliente", Conexao.conexao);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cli.cpf_Cliente = dr["cpf_Cliente"].ToString();
                    cli.nome_Cliente = dr["nome_Cliente"].ToString();
                    cli.nascimento_Cliente = Convert.ToDateTime(dr["nascimento_Cliente"].ToString());
                    cli.tel_Cliente = dr["tel_Cliente"].ToString();
                    cli.cel_Cliente = dr["cel_Cliente"].ToString();
                    cli.email_Cliente = dr["email_Cliente"].ToString();
                    cli.usuario_Cliente = dr["usuario_Cliente"].ToString();
                    cli.senha_Cliente = dr["senha_Cliente"].ToString();
                    clit.Add(cli);              
                }
                dr.Close();
                return clit;
            }
            catch (Exception po)
            {
                throw;
            }
            finally
            {
                conn.fecharConexao();
            }
        }
    */}
}
