﻿using HeyBus.Connection;
using HeyBus.Models;
//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeyBus.Repository
{
    public class RepositorioCliente
    {/*
        MySqlCommand cmd;
        MySqlDataReader dr;
        Conexao conn = new Conexao();
        Acesso ac = new Acesso();

        public bool Insert_Foregin_Cliente()
        {
            bool voltar  = false;
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("select count(id_Acesso) as id_Acesso from Acesso;", Conexao.conexao);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ac.id_Acesso = Convert.ToInt32(dr["id_Acesso"]);
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

        public bool Insert_Cliente(Cliente cli)
        {
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("SP_Cadastro_Cliente", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cpf", cli.cpf_Cliente);
                cmd.Parameters.AddWithValue("@nome", cli.nome_Cliente);
                cmd.Parameters.AddWithValue("@nascimento", cli.nascimento_Cliente.Date);
                cmd.Parameters.AddWithValue("@tel", cli.tel_Cliente);
                cmd.Parameters.AddWithValue("@cel", cli.cel_Cliente);
                cmd.Parameters.AddWithValue("@email", cli.email_Cliente);
                cmd.Parameters.AddWithValue("@acesso", ac.id_Acesso);
                cmd.ExecuteScalar();
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
                cmd.ExecuteNonQuery();
                return true;
                conn.fecharConexao();
            }catch(Exception ui)
            {
                throw new Exception(ui.Message);
                return false;
                conn.fecharConexao();
            }
        }

        public bool Consultar_Cliente(Cliente cli)
        {
            try
            {
                conn.abrirConexao();
                cmd = new MySqlCommand("SP_Consultar_Cliente", Conexao.conexao);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", cli.id_Cliente);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cli.cpf_Cliente = dr["cpf_Cliente"].ToString();
                    cli.nome_Cliente = dr["nome_Cliente"].ToString();
                    cli.nascimento_Cliente = Convert.ToDateTime(dr["nascimento_Cliente"].ToString());
                    cli.tel_Cliente = dr["tel_Cliente"].ToString();
                    cli.cel_Cliente = dr["cel_Cliente"].ToString();
                    cli.email_Cliente = dr["email_Cliente"].ToString();
                }
                return true;
                dr.Close();
                conn.fecharConexao();
            }catch(Exception po)
            {
                throw new Exception(po.Message);
                dr.Close();
                conn.fecharConexao();
                return false;
            }
        }
    */}
}