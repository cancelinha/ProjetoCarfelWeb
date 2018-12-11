using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.CheckPoint.Models;

namespace Senai.CheckPoint.Controllers {
    public class UsuarioController : Controller {
        [HttpGet]
        public ActionResult Cadastrar () {
            return View ();
        }

        [HttpPost]
        public ActionResult Cadastrar (IFormCollection form) {
            UsuarioModel usuario = new UsuarioModel ();

            if (System.IO.File.Exists ("usuarios.csv")) {
                usuario.Id = System.IO.File.ReadAllLines ("usuarios.csv").Length + 1;
            } else {
                usuario.Id = 1;
            }

            usuario.Nome = form["Nome"];
            usuario.Email = form["Email"];
            usuario.Senha = form["Senha"];
            // usuario.DataNascimento = DateTime.Parse (form["dataNascimento"]);

            using (StreamWriter sw = new StreamWriter ("usuarios.csv", true)) {
                sw.WriteLine ($"{usuario.Id};{usuario.Nome};{usuario.Email};{usuario.Senha}");
            }

            TempData["Mensagem"] = "Usuário Cadastrado";

            return RedirectToAction ("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login () {
            return View ();
        }

        [HttpPost]
        public IActionResult Login (IFormCollection form) {
            UsuarioModel usuario = new UsuarioModel ();
            usuario.Email = form["Email"];
            usuario.Senha = form["Senha"];

            using (StreamReader sr = new StreamReader ("usuarios.csv")) {
                while (!sr.EndOfStream) {
                    var linha = sr.ReadLine ();

                    if (string.IsNullOrEmpty (linha)) {
                        continue;
                    }

                    string[] dados = linha.Split (";");

                    if (dados[2] == usuario.Email && dados[3] == usuario.Senha) {

                        HttpContext.Session.SetString ("emailUsuario", usuario.Email);
                        HttpContext.Session.SetString ("nomeUsuario", dados[1]);
                        TempData["Mensagem"] = "Usuário Logado";
                        return Redirect ("/");
                    }
                }
            }

            TempData["Mensagem"] = "Usuário inválido";

            return RedirectToAction ("/");
        }

            [HttpGet]
        public IActionResult Logout () {
            // HttpContext.Session.Clear();
            // return Redirect("/");
            return View();
        }
        [HttpPost]
        public IActionResult Logout (IFormCollection form) {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
[HttpGet]
        public ActionResult Comentarios () {
            return View ();
        }
        [HttpPost]
        public ActionResult Comentarios (IFormCollection form) {
       ComentarioModel comments = new ComentarioModel ();
       
        using (StreamWriter sw = new StreamWriter ("comentarios.csv", true)) {
               
            }

        TempData["Mensagem"] = "Comentário Efetuado";

            return RedirectToAction ("Index", "Home");
        }

    }
}