using BibliotecaMVC.Models.Contracts.Contexts;
using BibliotecaMVC.Models.Contracts.Repositories;
using BibliotecaMVC.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaMVC.Models.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly IContextData _contextData;

        public LivroRepository(IContextData contextData)
        {
            _contextData = contextData;
        }

        public void Atualizar(LivroDto livro)
        {
            _contextData.AtualizarLivro(livro);
        }

        public void Excluir(string id)
        {
            _contextData.ExcluirLivro(id);
        }

        public void Cadastrar(LivroDto livro)
        {
            _contextData.CadastrarLivro(livro);
        }

        public List<LivroDto> Listar()
        {
           return _contextData.ListarLivro();
        }

        public LivroDto PesquisarPorID(string id)
        {
           return _contextData.pesquisarLivroPorId(id);
        }
    }
}
