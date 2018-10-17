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
    public class RepositoryGerente 
    {/*
        MySqlCommand cmd;
        MySqlDataReader dr;
        Conexao conn = new Conexao();
        Acesso ac = new Acesso();
        public bool Insert_Foreign_Ger(Gerente ger)
        {
            bool voltar = false;

            conn.abrirConexao();
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("select count(id_Acesso) as id_Acesso from Acesso;", Conexao.conexao);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ger.id_Acesso = Convert.ToInt32(dr["id_Acesso"]);
                    return true;
                }
                dr.Close();
            }
            catch (Exception oi)
            {
                throw new Exception(oi.Message);
                conn.fecharConexao();
                dr.Close();
                return false;
            }
            return voltar;
        }
        public bool Insert_Ger(Gerente ger)
        {
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("SP_Cadastrar_Ger", Conexao.conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cpf", ger.cpf_Gerente);
                cmd.Parameters.AddWithValue("@nome", ger.nome_Gerente);
                cmd.Parameters.AddWithValue("@email", ger.email_Gerente);
                cmd.Parameters.AddWithValue("@acesso", ger.id_Acesso);
                cmd.ExecuteNonQuery();
                return true;
                conn.fecharConexao();
            }catch(Exception ky)
            {
                conn.fecharConexao();
                throw new Exception(ky.Message);
                return false;
            }
        }

        public bool Consulta_Ger(Gerente ger)
        {
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("SP_Consultar_Ger", Conexao.conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ger.id_Gerente);
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    ger.cpf_Gerente = dr["cpf_Gerente"].ToString();
                    ger.nome_Gerente = dr["nome_Gerente"].ToString();
                    ger.email_Gerente = dr["email_Gerente"].ToString();
                    ac.usuario_Acesso = dr["login_Acesso"].ToString();
                    ac.senha_Acesso = dr["senha_Acesso"].ToString();
                }
                dr.Close();
                conn.fecharConexao();
                return true;
            }catch(Exception lk)
            {
                throw new Exception(lk.Message);
                dr.Close();
                conn.fecharConexao();
                return false;
            }
        }
    */}
}