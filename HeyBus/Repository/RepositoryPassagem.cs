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
        Cliente cli = new Cliente();

        public void Insert_Passagem(Passagem pass)
        {
            try
            {
                using (cmd = new MySqlCommand("SP_Comprar_Passagem", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cliente", cli.id_Cliente);
                    cmd.Parameters.AddWithValue("@rota", pass.destino_Passagem);
                    cmd.Parameters.AddWithValue("@onibus", pass.viacao_Onibus);
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
    }
}