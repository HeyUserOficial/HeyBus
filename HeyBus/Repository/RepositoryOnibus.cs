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
                    cmd.Parameters.AddWithValue("@bancos", oni.assentos_Onibus);
                    cmd.Parameters.AddWithValue("@manutencao", oni.manutencao_Onibus);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception kj)
            {
                throw;
            }
        }

        public Onibus Consultar_OnibusID(int id)
        {
            Onibus oni = new Onibus();
            try
            {
                using (cmd = new MySqlCommand("SP_Consultar_Onibus", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        oni.viacao_Onibus = dr["viacao_Onibus"].ToString();
                        oni.categoria_Onibus = dr["categoria_Onibus"].ToString();
                        oni.assentos_Onibus = Convert.ToInt32(dr["id_Bancos"].ToString());
                        oni.manutencao_Onibus = dr["manutencao_Onibus"].ToString();
                    }
                    oni.id_Onibus = id;
                    dr.Close();
                }
                return oni;
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

        public IEnumerable<Onibus> Consultar_Onibus()
        {
            Onibus oni = new Onibus();
            List<Onibus> oniList = new List<Onibus>();
            try
            {
                using (cmd = new MySqlCommand("Select * from Consultar_Onibus", Conexao.conexao))
                {
                    conn.abrirConexao();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        oni.id_Onibus = Convert.ToInt32(dr["id_Onibus"].ToString());
                        oni.viacao_Onibus = dr["viacao_Onibus"].ToString();
                        oni.categoria_Onibus = dr["categoria_Onibus"].ToString();
                        oni.assentos_Onibus = Convert.ToInt32(dr["id_Bancos"].ToString());
                        oni.manutencao_Onibus = dr["manutencao_Onibus"].ToString();
                        oniList.Add(oni);               
                    }
                    dr.Close();
                    return oniList;
                }               
            }catch(Exception kj)
            {
                throw;
            }
        }
    }
}