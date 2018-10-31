using HeyBus.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HeyBus.Models;

namespace HeyBus.Repository
{
    public class RepositoryPassagem
    {
        MySqlCommand cmd;
        MySqlDataReader dr;
        Conexao conn = new Conexao();
        Viagem viag = new Viagem();

        public void Insert_Passagem(Passagem pass)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_Comprar_Passagem", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cliente", pass.cli.id_Cliente);
                    cmd.Parameters.AddWithValue("@rota", pass.rot.destino_Rota);
                    cmd.Parameters.AddWithValue("@onibus", pass.bus.viacao_Onibus);
                    cmd.Parameters.AddWithValue("@viagem", viag.id_Viagem);
                    cmd.Parameters.AddWithValue("@formPag", pass.forma_Pagamaneto);
                    cmd.Parameters.AddWithValue("@cpf", pass.cpf_Cliente);
                    cmd.Parameters.AddWithValue("@desconto", pass.desconto_Passagem);
                    cmd.Parameters.AddWithValue("@valor", pass.valor_Passagem);
                    cmd.Parameters.AddWithValue("@data_Compra", pass.data_Compra);
                    cmd.ExecuteNonQuery();
                }
            }catch(Exception kh)
            {
                throw;
            }
        }

        public IEnumerable<Passagem> Consultar_Passagens()
        {
            Passagem pass = new Passagem();
            List<Passagem> passagensList = new List<Passagem>();
            try
            {
                using (cmd = new MySqlCommand("Select * from Consultar_Passagens", Conexao.conexao))
                {
                    conn.abrirConexao();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        pass.id_Passagem = Convert.ToInt32(dr["id_Passagem"].ToString());
                        pass.cli.nome_Cliente = dr["nome_Cliente"].ToString();
                        pass.rot.origem_Rota = dr["origem_Rota"].ToString();
                        pass.bus.viacao_Onibus = dr["viacao_Onibus"].ToString();
                        pass.rot.destino_Rota = dr["destino_Rota"].ToString();
                        pass.viag.data_Viagem = Convert.ToDateTime(dr["data_Viagem"].ToString());
                        pass.forma_Pagamaneto = dr["nome_FormPag"].ToString();
                        pass.cpf_Cliente = dr["cpf"].ToString();
                        pass.desconto_Passagem = Convert.ToDouble(dr["desconto_Passagem"].ToString());
                        pass.valor_Passagem = Convert.ToDouble(dr["valor_Passagem"].ToString());
                        pass.data_Compra = Convert.ToDateTime(dr["data_Compra"].ToString());
                        passagensList.Add(pass);
                    }
                    dr.Close();
                    return passagensList;
                }
            }catch(Exception lk)
            {
                throw;
            }
        }
    }
}