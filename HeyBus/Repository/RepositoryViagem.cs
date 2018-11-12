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
    public class RepositoryViagem
    {
        MySqlCommand cmd;
        MySqlDataReader dr;
        Conexao conn = new Conexao();

        public void Insert_Viagem(Viagem viag)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_Cadastrar_Viagem", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@rota", viag.rot.destino_Rota);
                    cmd.Parameters.AddWithValue("@onibus", viag.oni.id_Onibus);
                    cmd.Parameters.AddWithValue("@dataVi", viag.data_Viagem.Date);
                    cmd.Parameters.AddWithValue("@valor", viag.valor_Viagem);
                    cmd.ExecuteNonQuery();
                }
            }catch(Exception)
            {
               throw;
            }
        }

    
        public IEnumerable<Viagem> ProcurarOnibus()
        {
            Viagem onib = new Viagem();
            List<Viagem> listaOni = new List<Viagem>();
            
            try
            {
                using(cmd = new MySqlCommand("Select * from Onibus where manutencao_Onibus = Preparado", Conexao.conexao))
                {
                    conn.abrirConexao();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        onib.oni.id_Onibus = Convert.ToInt32(dr["id_Onibus"]);
                        onib.oni.viacao_Onibus = dr["viacao_Onibus"].ToString();
                        listaOni.Add(onib);
                    }
                    dr.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listaOni;
        }

        public IEnumerable<Viagem> ProcurarRota()
        {
            Viagem rotas = new Viagem();
            List<Viagem> listaRota = new List<Viagem>();
            try
            {
                using(cmd = new MySqlCommand("Select * from Rota", Conexao.conexao))
                {
                    conn.abrirConexao();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rotas.rot.id_Rota = Convert.ToInt32(dr["id_Rota"]);
                        rotas.rot.destino_Rota = dr["destino_Rota"].ToString();
                        listaRota.Add(rotas);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listaRota;
        }

        public IEnumerable<Viagem> Consultar_Viagens()
        {
            Viagem viag = new Viagem();
            List<Viagem> viagemList = new List<Viagem>();
            try
            {
                using (cmd = new MySqlCommand("Select * from Consultar_Viagens", Conexao.conexao))
                {
                    conn.abrirConexao();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        viag.id_Viagem = Convert.ToInt32(dr["id_Viagem"]);
                        viag.rot.destino_Rota = dr["destino_Rota"].ToString();
                        viag.oni.viacao_Onibus = dr["viacao_Onibus"].ToString();
                        viag.oni.categoria_Onibus = dr["categoria_Onibus"].ToString();
                        viag.data_Viagem = Convert.ToDateTime(dr["data_Viagem"].ToString());
                        viag.valor_Viagem = Convert.ToDouble(dr["valor_Viagem"].ToString());
                        viag.rot.distancia_Rota = dr["distancia_Rota"].ToString();
                        viag.oni.assentos_Onibus = Convert.ToInt32(dr["id_Bancos"].ToString());
                        viagemList.Add(viag);
                    }
                    dr.Close();
                    return viagemList;
                }
            }catch(Exception)
            {
                throw;
            }
        }
    }
}