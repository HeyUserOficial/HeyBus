using HeyBus.Connection;
using HeyBus.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeyBus.Repository
{
    public class RepositoryRota
    {
        MySqlCommand cmd;
        MySqlDataReader dr;
        Conexao conn = new Conexao();

        public void Insert_Rota(Rota rot)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_Cadastrar_Rota", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@origem", rot.origem_Rota);
                    cmd.Parameters.AddWithValue("@destino", rot.destino_Rota);
                    cmd.Parameters.AddWithValue("@distancia", rot.distancia_Rota);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void Update_Rota(Rota rot)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_Alterar_Rota", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", rot.id_Rota);
                    cmd.Parameters.AddWithValue("@origem", rot.origem_Rota);
                    cmd.Parameters.AddWithValue("@destino", rot.destino_Rota);
                    cmd.Parameters.AddWithValue("@distancia", rot.distancia_Rota);
                    cmd.ExecuteNonQuery();
                }
            }catch(Exception)
            {
                throw;
            }
        }

        public Rota Consultar_Rota(int id)
        {
            Rota rot = new Rota();
            try
            {
                using (cmd = new MySqlCommand("SP_Consultar_Rota", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rot.origem_Rota = dr["origem_Rota"].ToString();
                        rot.destino_Rota = dr["destino_Rota"].ToString();
                        rot.distancia_Rota = dr["distancia_Rota"].ToString();
                    }
                    rot.id_Rota = id;
                    dr.Close();
                }
                return rot;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Rota> Consultar_Rotas()
        {
            List<Rota> rotaList = new List<Rota>();
            try
            {
                using(cmd = new MySqlCommand("Select * from Consultar_Rotas", Conexao.conexao))
                {
                    conn.abrirConexao();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Rota rot = new Rota();
                        rot.id_Rota = Convert.ToInt32(dr["id_Rota"].ToString());
                        rot.origem_Rota = dr["origem_Rota"].ToString();
                        rot.destino_Rota = dr["destino_Rota"].ToString();
                        rot.distancia_Rota = dr["distancia_Rota"].ToString();
                        rotaList.Add(rot);
                    }
                    dr.Close();
                    return rotaList;
                }
            }catch(Exception)
            {
                throw;
            }
        }

        public List<Rota> ProcurarPorID(int id)
        {
            List<Rota> listaRota = new List<Rota>();
            try
            {
                using(cmd = new MySqlCommand("Select * from Rota where id_Rota = @id", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.Parameters.AddWithValue("@id", id);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Rota rot = new Rota();
                        rot.id_Rota = Convert.ToInt32(dr["id_Rota"].ToString());
                        rot.origem_Rota = dr["origem_Rota"].ToString();
                        rot.destino_Rota = dr["destino_Rota"].ToString();
                        rot.distancia_Rota = dr["distancia_Rota"].ToString();
                        listaRota.Add(rot);
                    }
                    dr.Close();
                    return listaRota;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Rota> ProcurarPorDestino(string destino)
        {
            List<Rota> listaRota = new List<Rota>();
            try
            {
                using (cmd = new MySqlCommand("Select * from Rota where destino_Rota = @destino", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.Parameters.AddWithValue("@destino", destino);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Rota rot = new Rota();
                        rot.id_Rota = Convert.ToInt32(dr["id_Rota"].ToString());
                        rot.origem_Rota = dr["origem_Rota"].ToString();
                        rot.destino_Rota = dr["destino_Rota"].ToString();
                        rot.distancia_Rota = dr["distancia_Rota"].ToString();
                        listaRota.Add(rot);
                    }
                    dr.Close();
                    return listaRota;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Rota> ProcurarPorOrigem(string origem)
        {
            List<Rota> listaRota = new List<Rota>();
            try
            {
                using (cmd = new MySqlCommand("Select * from Rota where origem_Rota = @origem", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.Parameters.AddWithValue("@origem", origem);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Rota rot = new Rota();
                        rot.id_Rota = Convert.ToInt32(dr["id_Rota"].ToString());
                        rot.origem_Rota = dr["origem_Rota"].ToString();
                        rot.destino_Rota = dr["destino_Rota"].ToString();
                        rot.distancia_Rota = dr["distancia_Rota"].ToString();
                        listaRota.Add(rot);
                    }
                    dr.Close();
                    return listaRota;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}