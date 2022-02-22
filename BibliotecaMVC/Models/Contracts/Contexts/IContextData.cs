using BibliotecaMVC.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaMVC.Models.Contracts.Contexts
{
    public interface IContextData
    {
        void CadastrarLivro(LivroDto livro);
        List<LivroDto> ListarLivro();
        LivroDto pesquisarLivroPorId(string id);
        void AtualizarLivro(LivroDto livro);
        void ExcluirLivro(string id);

        

    }
}
