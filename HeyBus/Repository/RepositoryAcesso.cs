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
        Conexao conn = new Conexao();

        public void Update_Acesso(Acesso ac)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_Alterar_Acesso", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@login", ac.login_Acesso);
                    cmd.Parameters.AddWithValue("@senha", ac.password_Acesso);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}