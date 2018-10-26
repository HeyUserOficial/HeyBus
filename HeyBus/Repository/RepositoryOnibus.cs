using HeyBus.Connection;
using HeyBus.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeyBus.Repository
{
    public class RepositoryOnibus
    {
        MySqlCommand cmd;
        MySqlDataReader dr;
        Conexao conn = new Conexao();

        public void Cadastrar_Onibus(Onibus oni)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_Cadastrar_Onibus", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@viacao", oni.viacao_Onibus);
                    cmd.Parameters.AddWithValue("@categoria", oni.categoria_Onibus);
                    cmd.Parameters.AddWithValue("@banco", oni.assentos_Onibus);
                    cmd.Parameters.AddWithValue("@manutencao", oni.manutencao_Onibus);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception kj)
            {
                throw;
            }
        }

        public void Consultar_Onibus(Onibus oni)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_Consultar_Onibus", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", oni.id_Onibus);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        oni.viacao_Onibus = dr["viacao_Onibus"].ToString();
                        oni.categoria_Onibus = dr["categoria_Onibus"].ToString();
                        oni.assentos_Onibus = Convert.ToInt32(dr["id_Banco"].ToString());
                        oni.manutencao_Onibus = dr["manutencao_Onibus"].ToString();
                    }
                }
            }
            catch (Exception mk)
            {
                throw;
            }
        }

        public void Update_Onibus(Onibus oni)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_Alterar_Onibus", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@manutencao", oni.manutencao_Onibus);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception kl)
            {
                throw;
            }
        }
    }
}