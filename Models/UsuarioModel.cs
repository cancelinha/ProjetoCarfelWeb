using System;
using System.Collections.Generic;
using Senai.CheckPoint.Models;

namespace Senai.CheckPoint.Models
{
    public class UsuarioModel
    {
          public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime Data { get; set; }
    
    }
}