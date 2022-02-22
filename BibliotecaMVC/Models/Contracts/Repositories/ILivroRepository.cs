using BibliotecaMVC.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaMVC.Models.Contracts.Repositories
{
    public interface ILivroRepository
    {
         List<LivroDto> Listar();

        void Cadastrar(LivroDto livro);
        LivroDto PesquisarPorID(string id);
        void Excluir(string id);
        void Atualizar(LivroDto livro);

    }

}
