﻿using HeyBus.Connection;
using HeyBus.Models;
using HeyBus.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeyBus.Controllers
{
    public class ViagensController : Controller
    {
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;
        RepositoryViagem repViagem = new RepositoryViagem();
        Conexao conn = new Conexao();
        // GET: Viagens
        [HttpGet]
        public ActionResult Consultar()
        {
            List<Viagem> viagem = repViagem.Consultar_Viagens().ToList();
            return View(viagem);
        }

        public ActionResult ConsultarViagens()
        {
            List<Viagem> viagem = repViagem.Consultar_Viagens().ToList();
            return View(viagem);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ActionName ("Cadastrar")]
        public ActionResult CadastrarViagem(Viagem viag)
        {
            if (ModelState.IsValid)
            {
                viag.oni.PuxarOnibus = PegarOnibus();
                viag.oni.PuxarCategoria = PegarCategoria();
                repViagem.Insert_Viagem(viag);
                return RedirectToAction("Consultar");
            }
            return View();
        }

        public IEnumerable<SelectListItem> PegarOnibus()
        {
            var onibus = repViagem.ProcurarOnibus().
                Select(v => new SelectListItem
                {
                    Value = v.oni.id_Onibus.ToString(),
                    Text = v.oni.viacao_Onibus,
                });
            return new SelectList(onibus, "Value", "Text");
        }

        public IEnumerable<SelectListItem> PegarCategoria()
        {
            var v = TrazerCategoria().
                Select(c => new SelectListItem
                {
                    Value = c.oni.id_Onibus.ToString(),
                    Text = c.oni.categoria_Onibus,
                });
            return new SelectList(v, "Value", "Text");
        }

        [NonAction]
        public IEnumerable<Viagem> TrazerCategoria()
        {
            Viagem onib = new Viagem();
            List<Viagem> listaOni = new List<Viagem>();
            var x = PegarOnibus();
            try
            {
                using(cmd = new MySqlCommand("Select * from Onibus where id_Onibus = @id", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.Parameters.AddWithValue("@id", x.FirstOrDefault());
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        onib.oni.id_Onibus = Convert.ToInt32(dr["id_Onibus"]);
                        onib.oni.categoria_Onibus = dr["categoria_Onibus"].ToString();
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

        public IEnumerable<SelectListItem> PegarRota()
        {
            var g = repViagem.ProcurarRota().
                Select(h => new SelectListItem
                {
                    Value = h.rot.id_Rota.ToString(),
                    Text = h.rot.destino_Rota
                });
            return new SelectList(g, "Value", "Text");
        }

        public IEnumerable<SelectListItem> PegarOrigem()
        {
            var j = ProcurarOrigem().
                Select(o => new SelectListItem
                {
                    Value = o.rot.id_Rota.ToString(),
                    Text = o.rot.origem_Rota
                });
            return new SelectList(j, "Value", "Text");
        }

        [NonAction]
        public IEnumerable<Viagem> ProcurarOrigem()
        {
            Viagem rota = new Viagem();
            List<Viagem> listaRota = new List<Viagem>();
            var b = PegarRota();
            try
            {
                using(cmd = new MySqlCommand("Select * from Rota where id_Rota = @id", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.Parameters.AddWithValue("@id", b.FirstOrDefault());
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rota.rot.id_Rota = Convert.ToInt32(dr["id_Rota"]);
                        rota.rot.destino_Rota = dr["destino_Origem"].ToString();
                        listaRota.Add(rota);
                    }
                    dr.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listaRota;
        }
    }
}