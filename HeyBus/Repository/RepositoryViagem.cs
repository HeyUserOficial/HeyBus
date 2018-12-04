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
                    cmd.Parameters.AddWithValue("@rota", viag.rot.id_Rota);
                    cmd.Parameters.AddWithValue("@onibus", viag.oni.id_Onibus);
                    cmd.Parameters.AddWithValue("@dataIda", viag.data_Ida);
                    cmd.Parameters.AddWithValue("@dataVolta", viag.data_Volta);
                    cmd.Parameters.AddWithValue("@horario", viag.horario_Viagem);
                    cmd.Parameters.AddWithValue("@valor", viag.valor_Viagem);
                    cmd.ExecuteNonQuery();
                }
            }catch(Exception ex)
            {
               throw new Exception(ex.Message.ToString());
            }
        }

    
        public List<Viagem> ProcurarOnibus()
        {
            List<Viagem> listaOni = new List<Viagem>();
            try
            {
                using(cmd = new MySqlCommand("Select id_Onibus, concat(viacao_Onibus,'-', categoria_Onibus) as Onibus from onibus order by Onibus asc", Conexao.conexao))
                {
                    conn.abrirConexao();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Viagem onib = new Viagem();
                        onib.oni.id_Onibus =  Convert.ToInt32(dr["id_Onibus"]);
                        onib.oni.viacao_Onibus = dr["Onibus"].ToString();
                        listaOni.Add(onib);
                    }
                    dr.Close();
                    return listaOni;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Viagem> ProcurarRota()
        {
            List<Viagem> listaRota = new List<Viagem>();
            try
            {
                using(cmd = new MySqlCommand("Select id_Rota, concat(origem_Rota ,'-', destino_Rota) as Rota from rota order by Rota ASC", Conexao.conexao))
                {
                    conn.abrirConexao();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Viagem rotas = new Viagem();
                        rotas.rot.id_Rota = Convert.ToInt32(dr["id_Rota"]);
                        rotas.rot.destino_Rota = dr["Rota"].ToString();
                        listaRota.Add(rotas);
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

        public IEnumerable<Viagem> Consultar_Viagens()
        {
            List<Viagem> viagemList = new List<Viagem>();
            try
            {
                using (cmd = new MySqlCommand("Select * from Consultar_Viagens", Conexao.conexao))
                {
                    conn.abrirConexao();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Viagem viag = new Viagem();
                        viag.id_Viagem = Convert.ToInt32(dr["id_Viagem"]);
                        viag.rot.origem_Rota = dr["origem_Rota"].ToString();
                        viag.rot.destino_Rota = dr["destino_Rota"].ToString();
                        viag.oni.viacao_Onibus = dr["viacao_Onibus"].ToString();
                        viag.oni.categoria_Onibus = dr["categoria_Onibus"].ToString();
                        viag.data_Ida = Convert.ToDateTime(dr["data_Ida"].ToString());
                        viag.data_Volta = Convert.ToDateTime(dr["data_Volta"].ToString());
                        viag.valor_Viagem = Convert.ToDouble(dr["valor_Viagem"].ToString());
                        viag.rot.distancia_Rota = dr["distancia_Rota"].ToString();
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

        public IEnumerable<Viagem> PesquisarViagemCompleto(DateTime? dataPartida, string origem, string destino, DateTime? dataVolta)
        {
            List<Viagem> listaViag = new List<Viagem>();
            try
            {
                using (cmd = new MySqlCommand("SP_Pesquisar_Viagens_Completo", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@dataPartida", dataPartida);
                    cmd.Parameters.AddWithValue("@origem", origem);
                    cmd.Parameters.AddWithValue("@destino", destino);
                    cmd.Parameters.AddWithValue("@dataVolta", dataVolta);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Viagem v = new Viagem();
                        v.id_Viagem = Convert.ToInt32(dr["id_Viagem"]);
                        v.rot.destino_Rota = dr["destino_Rota"].ToString();
                        v.rot.origem_Rota = dr["origem_Rota"].ToString();
                        v.oni.categoria_Onibus = dr["categoria_Onibus"].ToString();
                        v.oni.viacao_Onibus = dr["viacao_Onibus"].ToString();
                        v.valor_Viagem = Convert.ToDouble(dr["valor_Viagem"].ToString());
                        v.data_Ida = Convert.ToDateTime(dr["data_Ida"].ToString());
                        v.data_Volta = Convert.ToDateTime(dr["data_Volta"].ToString());
                        v.horario_Viagem = Convert.ToDateTime(dr["horario_Viagem"].ToString());
                        v.rot.distancia_Rota = dr["distancia_Rota"].ToString();
                        listaViag.Add(v);
                    }
                    dr.Close();
                    return listaViag;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Viagem> PesquisarViagemIda(DateTime? dataPartida, string origem, string destino)
        {
            List<Viagem> listaViag = new List<Viagem>();
            try
            {
                using(cmd = new MySqlCommand("SP_Pesquisar_Viagens_Ida", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@dataPartida", dataPartida);
                    cmd.Parameters.AddWithValue("@origem", origem);
                    cmd.Parameters.AddWithValue("@destino", destino);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Viagem v = new Viagem();
                        v.id_Viagem = Convert.ToInt32(dr["id_Viagem"]);
                        v.rot.destino_Rota = dr["destino_Rota"].ToString();
                        v.rot.origem_Rota = dr["origem_Rota"].ToString();
                        v.oni.categoria_Onibus = dr["categoria_Onibus"].ToString();
                        v.oni.viacao_Onibus = dr["viacao_Onibus"].ToString();
                        v.valor_Viagem = Convert.ToDouble(dr["valor_Viagem"].ToString());
                        v.data_Ida = Convert.ToDateTime(dr["data_Ida"].ToString());
                        v.horario_Viagem = Convert.ToDateTime(dr["horario_Viagem"].ToString());
                        v.rot.distancia_Rota = dr["distancia_Rota"].ToString();
                        listaViag.Add(v);
                    }
                    dr.Close();
                    return listaViag;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Viagem> PesquisarViagemDestino(string origem, string destino)
        {
            List<Viagem> listaViag = new List<Viagem>();
            try
            {
                using(cmd = new MySqlCommand("SP_Pesquisar_Viagens_Destino", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@origem", origem);
                    cmd.Parameters.AddWithValue("@destino", destino);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Viagem v = new Viagem();
                        v.id_Viagem = Convert.ToInt32(dr["id_Viagem"]);
                        v.rot.destino_Rota = dr["destino_Rota"].ToString();
                        v.rot.origem_Rota = dr["origem_Rota"].ToString();
                        v.oni.categoria_Onibus = dr["categoria_Onibus"].ToString();
                        v.oni.viacao_Onibus = dr["viacao_Onibus"].ToString();
                        v.valor_Viagem = Convert.ToDouble(dr["valor_Viagem"].ToString());
                        v.data_Ida = Convert.ToDateTime(dr["data_Ida"].ToString());
                        v.data_Volta = Convert.ToDateTime(dr["data_Volta"].ToString());
                        v.horario_Viagem = Convert.ToDateTime(dr["horario_Viagem"].ToString());
                        v.rot.distancia_Rota = dr["distancia_Rota"].ToString();
                        listaViag.Add(v);
                    }
                    dr.Close();
                    return listaViag;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}