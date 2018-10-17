using HeyBus.Connection;
using HeyBus.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeyBus.Repository
{
    public class RepositoryAcesso
    {
        MySqlCommand cmd;
        MySqlDataReader dr;
        Conexao conn = new Conexao();
        Acesso ac = new Acesso();
        public bool Insert_Acesso()
        {
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("SP_Cadastrar_Acesso", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", ac.login_Ac);
                cmd.Parameters.AddWithValue("@senha", ac.password_Ac);
                cmd.ExecuteNonQuery();
                return true;
                conn.fecharConexao();
            }catch(Exception hj)
            {
                throw new Exception(hj.Message);
                conn.fecharConexao();
                return false;          
            }
        }

        public bool Efetuar_Login()
        {
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("SP_Efetuar_Acesso", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", Acesso.usuario_Acesso);
                cmd.Parameters.AddWithValue("@senha", Acesso.senha_Acesso);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    return true;
                }
                else
                {

                    return false;
                    conn.fecharConexao();
                }
            }catch(Exception kk)
            {
                throw new Exception(kk.Message);
            }
        }

        public bool Alterar_Login()
        {
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("SP_Alterar_Acesso", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@login", Acesso.usuario_Acesso);
                cmd.Parameters.AddWithValue("@senha", Acesso.senha_Acesso);
                cmd.ExecuteNonQuery();
                conn.fecharConexao();
                return true;
            }catch(Exception hg)
            {
                throw new Exception(hg.Message);
                conn.fecharConexao();
                return false;
            }
        }
    }
}