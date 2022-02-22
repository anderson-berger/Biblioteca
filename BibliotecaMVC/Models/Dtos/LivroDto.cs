using BibliotecaMVC.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaMVC.Models.Dtos
{
    public class LivroDto : EntidadeBase
    {
        
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }


        public LivroDto()
        {

        }

        public LivroDto(string iD, string nome, string autor, string editora) : this(nome, autor, editora)
        {
            ID = iD;
            
        }

        public LivroDto(string nome, string autor, string editora)
        {
            Nome = nome;
            Autor = autor;
            Editora = editora;
        }
    }
}
