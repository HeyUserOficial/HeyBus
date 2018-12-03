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
                using (cmd = new MySqlCommand("SP_Cadastrar_Func", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@login", func.login_Acesso);
                    cmd.Parameters.AddWithValue("@senha", func.password_Acesso);
                    cmd.Parameters.AddWithValue("@cpf", func.cpf_Funcionario);
                    cmd.Parameters.AddWithValue("@nome", func.nome_Funcionario);
                    cmd.Parameters.AddWithValue("@email", func.email_Funcionario);
                    cmd.Parameters.AddWithValue("@endereco", func.endereco_Funcionario);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Login_Func(Acesso func)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_Efetuar_Acesso", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuario", func.login_Acesso);
                    cmd.Parameters.AddWithValue("@senha", func.password_Acesso);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dr.Close();
            }
        }

        public string RetornarNome(string usuario)
        {
            Funcionario f = new Funcionario();
            try
            {
                using(cmd = new MySqlCommand("select id_Funcionario, nome_Funcionario from funcionario inner join acesso on funcionario.id_Acesso = acesso.id_Acesso where acesso.login_Acesso = @usuario", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        f.id_Funcionario = Convert.ToInt32(dr["id_Funcionario"]);
                        f.nome_Funcionario = dr["nome_Funcionario"].ToString();
                    }
                    dr.Close();
                    return f.nome_Funcionario;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Funcionario Update_Func(Funcionario func)
        {
            try
            {
                using(cmd = new MySqlCommand("SP_Alterar_Func", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", func.id_Funcionario);
                    cmd.Parameters.AddWithValue("@cpf", func.cpf_Funcionario);
                    cmd.Parameters.AddWithValue("@nome", func.nome_Funcionario);
                    cmd.Parameters.AddWithValue("@email", func.email_Funcionario);
                    cmd.Parameters.AddWithValue("@endereco", func.endereco_Funcionario);
                    cmd.ExecuteNonQuery();
                }
                return func;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Funcionario> Consultar_Func()
        {
            List<Funcionario> funcList = new List<Funcionario>();
            try
            {
                using (cmd = new MySqlCommand("Select * from Consultar_Funcionarios", Conexao.conexao))
                {
                    conn.abrirConexao();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Funcionario func = new Funcionario();
                        func.id_Funcionario = Convert.ToInt32(dr["id_Funcionario"].ToString());
                        func.cpf_Funcionario = dr["cpf_Funcionario"].ToString();
                        func.nome_Funcionario = dr["nome_Funcionario"].ToString();
                        func.email_Funcionario = dr["email_Funcionario"].ToString();
                        func.endereco_Funcionario = dr["endereco_Funcionario"].ToString();
                        func.login_Funcionario = dr["login_Acesso"].ToString();
                        funcList.Add(func);
                    }
                    dr.Close();
                    return funcList;
                }
            }catch(Exception)
            {
                throw;
            }   
        }


        public Funcionario BuscarPorId(int id)
        {
            Funcionario func = new Funcionario();
            try
            {
                using(cmd = new MySqlCommand("Select * from funcionario where id_Funcionario = @id", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.Parameters.AddWithValue("@id", func.id_Funcionario);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        func.cpf_Funcionario = dr["cpf_Funcionario"].ToString();
                        func.nome_Funcionario = dr["nome_Funcionario"].ToString();
                        func.email_Funcionario = dr["email_Funcionario"].ToString();
                        func.endereco_Funcionario = dr["endereco_Funcionario"].ToString();
                    }
                    dr.Close();
                }
                return func;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Funcionario> ProcurarPorID(int id)
        {
            List<Funcionario> listaFunc = new List<Funcionario>();
            try
            {
                using (cmd = new MySqlCommand("Select * from funcionario where id_Funcionario = @id", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.Parameters.AddWithValue("@id", id);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Funcionario func = new Funcionario();
                        func.id_Funcionario = Convert.ToInt32(dr["id_Funcionario"].ToString());
                        func.cpf_Funcionario = dr["cpf_Funcionario"].ToString();
                        func.nome_Funcionario = dr["nome_Funcionario"].ToString();
                        func.email_Funcionario = dr["email_Funcionario"].ToString();
                        func.endereco_Funcionario = dr["endereco_Funcionario"].ToString();
                        listaFunc.Add(func);
                    }
                    dr.Close();
                    return listaFunc;
                }               
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<Funcionario> ProcurarPorCPF(string cpf)
        {          
            List<Funcionario> listaFunc = new List<Funcionario>();
            try
            {
                using (cmd = new MySqlCommand("Select * from funcionario where cpf_Funcionario = @cpf", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Funcionario func = new Funcionario();
                        func.id_Funcionario = Convert.ToInt32(dr["id_Funcionario"].ToString());
                        func.cpf_Funcionario = dr["cpf_Funcionario"].ToString();
                        func.nome_Funcionario = dr["nome_Funcionario"].ToString();
                        func.email_Funcionario = dr["email_Funcionario"].ToString();
                        func.endereco_Funcionario = dr["endereco_Funcionario"].ToString();
                        listaFunc.Add(func);
                    }
                    dr.Close();
                    return listaFunc;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Funcionario> ProcurarPorNome(string nome)
        {
            List<Funcionario> listaFunc = new List<Funcionario>();
            try
            {
                using (cmd = new MySqlCommand("Select * from funcionario where nome_Funcionario = @nome", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.Parameters.AddWithValue("@nome", nome);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Funcionario func = new Funcionario();
                        func.id_Funcionario = Convert.ToInt32(dr["id_Funcionario"].ToString());
                        func.cpf_Funcionario = dr["cpf_Funcionario"].ToString();
                        func.nome_Funcionario = dr["nome_Funcionario"].ToString();
                        func.email_Funcionario = dr["email_Funcionario"].ToString();
                        func.endereco_Funcionario = dr["endereco_Funcionario"].ToString();
                        listaFunc.Add(func);
                    }
                    dr.Close();
                    return listaFunc;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}