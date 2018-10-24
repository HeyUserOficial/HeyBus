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
    public class RepositoryAcesso
    {
        MySqlCommand cmd;
        MySqlDataReader dr;
        Conexao conn = new Conexao();

        public void Insert_Acesso(Acesso ac)
        {
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("SP_Cadastrar_Acesso", Conexao.conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", ac.login_Acesso);
                cmd.Parameters.AddWithValue("@senha", ac.password_Acesso);
                cmd.ExecuteNonQuery();
            }
            catch(Exception kj)
            {
                throw;
            }
            finally
            {
                conn.fecharConexao();
            }
        }

        public void Update_Acesso(Acesso ac)
        {
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("SP_Alterar_Acesso", Conexao.conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", ac.login_Acesso);
                cmd.Parameters.AddWithValue("@senha", ac.password_Acesso);
                cmd.ExecuteNonQuery();
            }
            catch(Exception kk)
            {
                throw;
            }
            finally
            {
                conn.fecharConexao();
            }
        }
    }
}