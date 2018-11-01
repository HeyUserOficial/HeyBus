using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace HeyBus.Connection
{
    public class Conexao
    {
       public static MySqlConnection conexao = new MySqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString);

        //Construtor
        public Conexao()
        {

        }

        //Getters And Setters

        //Codigo

        public bool abrirConexao()
        {

            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();

                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }



        }
        public void fecharConexao()
        {
            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Close();
            }

        }
    }
}