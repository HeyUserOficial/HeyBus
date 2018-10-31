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

        public void Login_Cliente(Cliente cli)
        {
            try
            {
                using(cmd = new MySqlCommand("SP_Login_Cliente"))
                {
                    conn.abrirConexao();
                    cmd.Parameters.AddWithValue("@usuario", Cliente.user_Cliente);
                    cmd.Parameters.AddWithValue("@senha", Cliente.password_Cliente);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        
                    }
                }
            }
            catch (Exception h)
            {
                throw;
            }
        }
        public void Insert_Cliente(Cliente cli)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_Cadastrar_Cliente", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cpf", cli.cpf_Cliente);
                    cmd.Parameters.AddWithValue("@nome", cli.nome_Cliente);
                    cmd.Parameters.AddWithValue("@nascimento", cli.nascimento_Cliente);
                    cmd.Parameters.AddWithValue("@tel", cli.tel_Cliente);
                    cmd.Parameters.AddWithValue("@cel", cli.cel_Cliente);
                    cmd.Parameters.AddWithValue("@email", cli.email_Cliente);
                    cmd.Parameters.AddWithValue("@usuario", cli.usuario_Cliente);
                    cmd.Parameters.AddWithValue("@senha", cli.senha_Cliente);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception i)
            {
                throw;
            }
        }

        public Cliente Update_Cliente(Cliente cli)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_Atualizar_Cliente", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", cli.id_Cliente);
                    cmd.Parameters.AddWithValue("@cpf", cli.cpf_Cliente);
                    cmd.Parameters.AddWithValue("@nome", cli.nome_Cliente);
                    cmd.Parameters.AddWithValue("@nascimento", cli.nascimento_Cliente.Date);
                    cmd.Parameters.AddWithValue("@tel", cli.tel_Cliente);
                    cmd.Parameters.AddWithValue("@cel", cli.cel_Cliente);
                    cmd.Parameters.AddWithValue("@email", cli.email_Cliente);
                    cmd.Parameters.AddWithValue("@usuario", cli.usuario_Cliente);
                    cmd.Parameters.AddWithValue("@senha", cli.senha_Cliente);
                    cmd.ExecuteNonQuery();
                }
                return cli;
            }
            catch (Exception ui)
            {  
                throw;               
            }
        }

        public Cliente ConsultarPorId(int id)
        {
            Cliente cli = new Cliente();
            try
            {
                using(cmd = new MySqlCommand("Select * from Cliente where id_Cliente = @id", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.Parameters.AddWithValue("@id", id);
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
                    }
                    cli.id_Cliente = id;
                    dr.Close();
                }
                return cli;
            }
            catch (Exception jk)
            {
                throw;
            }
        }

        public IEnumerable<Cliente> Consultar_Cliente()
        {
            Cliente cli = new Cliente();
            List<Cliente> cliList = new List<Cliente>();
            try
            {
                using (cmd = new MySqlCommand("Select * from Consultar_Clientes", Conexao.conexao))
                {
                    conn.abrirConexao();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        cli.id_Cliente = Convert.ToInt32(dr["id_Cliente"].ToString());
                        cli.cpf_Cliente = dr["cpf_Cliente"].ToString();
                        cli.nome_Cliente = dr["nome_Cliente"].ToString();
                        cli.nascimento_Cliente = Convert.ToDateTime(dr["nascimento_Cliente"].ToString());
                        cli.tel_Cliente = dr["tel_Cliente"].ToString();
                        cli.cel_Cliente = dr["cel_Cliente"].ToString();
                        cli.email_Cliente = dr["email_Cliente"].ToString();
                        cli.usuario_Cliente = dr["usuario_Cliente"].ToString();
                        cli.senha_Cliente = dr["senha_Cliente"].ToString();
                        cliList.Add(cli);
                    }
                    dr.Close();
                    return cliList;
                }
            }
            catch (Exception po)
            {
                throw;
            }
        }
   */ }
}
