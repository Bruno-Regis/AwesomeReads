using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeReads.Core.Models
{
    public class BookServiceViewModel
    {
        public string Titulo { get; set; }
        public string Isbn { get; set; }
        public List<string> Autores { get; set; }
        public List<string> Assuntos { get; set; }
        public DateTime DataPublicacao { get; set; }
        public List<string> Editoras { get; set; }
        public string UrlImagem { get; set; }

    }
}
