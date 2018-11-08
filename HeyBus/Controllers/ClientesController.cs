using HeyBus.Connection;
using HeyBus.Models;
using HeyBus.Repository;
using HeyBus.Validations;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
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
                if (existe > 0)
                {
                    ModelState.AddModelError("EmailExiste", "E-mail já está em uso");
                    return View(cli);
                }
                else
                {
                    cli.ativacao_Cliente = Guid.NewGuid();
                    cli.email_Verify = false;
                    repCli.Insert_Cliente(cli);
                    EnviarVerificacao(cli.email_Cliente, cli.ativacao_Cliente.ToString());
                    message = "Cadastro feito com sucesso. Link para ativar" +
                        "a conta foi enviado no seu email: " + cli.email_Cliente;
                    status = true;
                }
            }
            else
            {
                message = "Invalid Request";
            }
            ViewBag.Message = message;
            ViewBag.Status = status;
            return View(cli);
        }

        [HttpGet]
        public ActionResult VerificacaoConta(string id, string email)
        {
            bool status = false;
            var go = VerifyAccount(id, email);
            if (go == true)
            {
                using (cmd = new MySqlCommand("Update Cliente set email_Verify = 2 where email_Cliente = @email", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.Parameters.AddWithValue("@email", email);
                    status = true;
                }
            }
            else
            {
                ViewBag.Message = "Invalid Request";
            }
            ViewBag.Status = status;
            return View();
        }

        [NonAction]
        public bool VerifyAccount(string id, string email)
        {
            Cliente cli = new Cliente();
            bool v = false;
            using (cmd = new MySqlCommand("Select ativacao_Cliente from Cliente where email_Cliente = @email", Conexao.conexao))
            {
                cmd.Parameters.AddWithValue("@email", email);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    id = dr["ativacao_Cliente"].ToString();
                    v = true;
                }     
                dr.Close();
                return v;
            }
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
        public int EmailExiste(string email)
        {
            int r = 0;
            using (cmd = new MySqlCommand("Select * from Cliente where email_Cliente = @email", Conexao.conexao))
            {
                conn.abrirConexao();
                cmd.Parameters.AddWithValue("@email", email);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    r = Convert.ToInt32(dr["id_Cliente"]);
                }
                dr.Close();
            }
            return r;
        }

        [NonAction]
        public void EnviarVerificacao(string email, string ativacao)
        {
            var verifyUrl = "/Clientes/VerificacaoConta/" + ativacao +"/"+ email;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            var fromEmail = new MailAddress("heyuseroficial@gmail.com", "Hey User");
            var toEmail = new MailAddress(email);
            var fromEmailPassword = "heyuser123";
            string subject = "Conta criada com sucesso! Bem vindo à HeyBus!";
            string body = "<br/><br/>Nós estamos muito felizes de lhe avisar que sua conta na HeyBus" +
                "foi criada com sucesso. Por favor entre no link abaixo para verificar sua conta" +
                "<br/><br/><a href='" + link + "'>" + link + "<a/> ";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
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
            smtp.Send(message);
        }
    }
}

