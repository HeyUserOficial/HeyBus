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
                    cmd.Parameters.AddWithValue("@viagem", pass.viag.id_Viagem);
                    cmd.Parameters.AddWithValue("@formPag", pass.forma_Pagamaneto = 1);
                    cmd.Parameters.AddWithValue("@cpf", pass.cpf_Cliente);
                    cmd.Parameters.AddWithValue("@valor", pass.valor_Passagem);
                    cmd.Parameters.AddWithValue("@data_Compra", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }catch(Exception)
            {
                throw;
            }
        }

        public IEnumerable<Passagem> Consultar_Passagens()
        {
            List<Passagem> passagensList = new List<Passagem>();
            try
            {
                using (cmd = new MySqlCommand("Select * from Consultar_Passagens", Conexao.conexao))
                {
                    conn.abrirConexao();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Passagem pass = new Passagem();
                        pass.id_Passagem = Convert.ToInt32(dr["id_Passagem"].ToString());
                        pass.cli.nome_Cliente = dr["nome_Cliente"].ToString();
                        pass.rot.origem_Rota = dr["origem_Rota"].ToString();
                        pass.oni.viacao_Onibus = dr["viacao_Onibus"].ToString();
                        pass.rot.destino_Rota = dr["destino_Rota"].ToString();
                        pass.viag.data_Ida = Convert.ToDateTime(dr["data_Viagem"].ToString());
                        pass.forma_Pagamaneto = Convert.ToInt32(dr["nome_FormPag"]); 
                        pass.cpf_Cliente = dr["cpf"].ToString();
                        pass.desconto_Passagem = Convert.ToDouble(dr["desconto_Passagem"].ToString());
                        pass.valor_Passagem = Convert.ToDouble(dr["valor_Passagem"].ToString());
                        pass.data_Compra = Convert.ToDateTime(dr["data_Compra"].ToString());
                        passagensList.Add(pass);
                    }
                    dr.Close();
                    return passagensList;
                }
            }catch(Exception)
            {
                throw;
            }
        }

        
        public Passagem Detalhes_Viagem(int id)
        {
            Passagem pass = new Passagem();
            try
            {
                using (cmd = new MySqlCommand("SP_Detalhes_Viagem", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        pass.viag.id_Viagem = Convert.ToInt32(dr["id_Viagem"]);
                        pass.oni.viacao_Onibus = dr["viacao_Onibus"].ToString();
                        pass.viag.data_Ida = Convert.ToDateTime(dr["data_Ida"].ToString());
                        pass.viag.data_Volta = Convert.ToDateTime(dr["data_Volta"].ToString());
                        pass.viag.horario_Viagem = Convert.ToDateTime(dr["horario_Viagem"].ToString());
                        pass.viag.oni.categoria_Onibus = dr["categoria_Onibus"].ToString();
                        pass.viag.rot.destino_Rota = dr["destino_Rota"].ToString();
                        pass.viag.rot.origem_Rota = dr["origem_Rota"].ToString();
                        pass.viag.valor_Viagem = Convert.ToDouble(dr["valor_Viagem"].ToString());
                        pass.assentos.banco = Convert.ToInt32(dr["id_Bancos"].ToString());
                        pass.assentos.listaBancos.Add(pass.assentos.banco);
                    }
                    dr.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return pass;
        }
    }
}