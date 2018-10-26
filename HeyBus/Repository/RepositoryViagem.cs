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
                    cmd.Parameters.AddWithValue("@rota", viag.id_Rota);
                    cmd.Parameters.AddWithValue("@onibus", viag.id_Onibus);
                    cmd.Parameters.AddWithValue("@dataVi", viag.data_Viagem.Date);
                    cmd.Parameters.AddWithValue("@valor", viag.valor_Viagem);
                    cmd.ExecuteNonQuery();
                }
            }catch(Exception yo)
            {
                throw;
            }
        }
    }
}