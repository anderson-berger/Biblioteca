using BibliotecaMVC.Models.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaMVC.Models.Entidades
{
    public class Livro : EntidadeBase
    {
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public StatusLivro StatusLivroId { get; set; }

    }
}
