using HeyBus.Connection;
using HeyBus.Models;
using HeyBus.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;


namespace HeyBus.Controllers
{
    [Route("Clientes")]
    public class ClientesController : Controller
    {
        Cliente cli = new Cliente();
        MySqlCommand cmd;
        Conexao conn = new Conexao();
        MySqlDataReader dr;
        RepositoryCliente repCli = new RepositoryCliente();

        //GET
        // GET: Clientes
        public ActionResult Consultar()
        {
            List<Cliente> cli = repCli.Consultar_Cliente().ToList();
            return View(cli);
        }

        public ActionResult ClienteLista()
        {
            List<Cliente> cli = repCli.Consultar_Cliente().ToList();
            return View(cli);
        }

        //GET
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Cadastrar")]
        public ActionResult Cadastrar([Bind(Exclude = "email_Verify,ativacao_Cliente")]Cliente cli)
        {
            bool status = false;
            string message = "";

            if (ModelState.IsValid)
            {
                var existe = EmailExiste(cli.email_Cliente);
                if (existe)
                {
                    ModelState.AddModelError("EmailExiste", "E-mail já está em uso");
                    cli.ativacao_Cliente = Guid.NewGuid();
                    cli.senha_Cliente = Crypto.Hash(cli.senha_Cliente);
                    cli.confirma_Senha = Crypto.Hash(cli.confirma_Senha);
                    cli.email_Verify = false;
                    repCli.Insert_Cliente(cli);

                    EnviarVerificacao(cli.email_Cliente, cli.ativacao_Cliente.ToString());
                    message = "Cadastro feito com sucesso. Link para ativar" +
                        "a conta foi enviado no seu email:" + cli.email_Cliente;
                    status = true;
                    return View(cli);
                }
            }
            else
            {
                message = "Invalid Request";
            }
            return View(cli);
        }

        public ActionResult Atualizar(int id)
        {
            return View(repCli.ConsultarPorId(id));
        }

        [HttpPost]
        [ActionName("Atualizar")]
        public ActionResult AtualizarCli(Cliente cli)
        {
            if (ModelState.IsValid)
            {
                repCli.Update_Cliente(cli);

                return RedirectToAction("Consultar");
            }
            return View();
        }

        [NonAction]
        public bool EmailExiste(string email)
        {
            bool v = true;
            using (cmd = new MySqlCommand("Select * from Cliente where email_Cliente = @email"))
            {
                conn.abrirConexao();
                cmd.Parameters.AddWithValue("@email", email);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                     v = Convert.ToBoolean(dr["@email"].Equals(email));
                }              
            }
            return v;
        }

        [NonAction]
        public void EnviarVerificacao(string email, string ativacao)
        {
            var verifyUrl = "/Clientes/VarificarConta" + ativacao;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            var fromEmail = new MailAddress("heyuseroficial@gmail.com", "Hey User");
            var toEmail = new MailAddress(email);
            var fromEmailPassword = "heyuser123";
            string subject = "Conta criada com sucesso! Bem vindo à HeyBus!";
            string body = "<br/><br/>Nós estamos muito felizes de lhe avisar que sua conta na HeyBus"+
                "foi criada com sucesso. Por favor entre no link abaixo para verificar sua conta"+
                "<br/><br/><a href='"+ link +"'>"+link+"<a/> ";

            var stmp = new SmtpClient
            {
                Host = "stmp@gmail.com",
                Port = 587,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                stmp.Send(message);
        }
    }
}

