using HeyBus.Connection;
using HeyBus.Models;
//using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeyBus.Repository
{
    public class RepositoryViagem
    {/*
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
                    cmd.Parameters.AddWithValue("@onibus", viag.oni.viacao_Onibus);
                    cmd.Parameters.AddWithValue("@dataVi", viag.data_Viagem.Date);
                    cmd.Parameters.AddWithValue("@valor", viag.valor_Viagem);
                    cmd.ExecuteNonQuery();
                }
            }catch(Exception yo)
            {
               throw;
            }
        }
<<<<<<< HEAD
    */}
=======

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
            }catch(Exception jh)
            {
                throw;
            }
        }
    }
>>>>>>> 302a6d4822827d78abbf2dfce2dc1988f736b803
}