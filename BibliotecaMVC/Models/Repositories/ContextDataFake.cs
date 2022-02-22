using BibliotecaMVC.Models.Contracts.Contexts;
using BibliotecaMVC.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaMVC.Models.Repositories
{
    public class ContextDataFake : IContextData
    {
        private static List<LivroDto> livros;

        public ContextDataFake()
        {
            livros = new List<LivroDto>();
            InitializeData();
        }

        private void InitializeData()
        {
            var livro = new LivroDto("Lais","lais","lais");
            livros.Add(livro);

            livro = new LivroDto("Anderson", "Anderson", "Anderson");
            livros.Add(livro);

            livro = new LivroDto("Neithan", "Neithan", "Neithan");
            livros.Add(livro);

            livro = new LivroDto("Rozangela", "Rozangela", "Rozangela");
            livros.Add(livro);


        }

        public void AtualizarLivro(LivroDto livro)
        {
            try
            {
                LivroDto objPesquisa = pesquisarLivroPorId(livro.ID);
                livros.Remove(objPesquisa);

                objPesquisa.Nome = livro.Nome;
                objPesquisa.Editora = livro.Editora;
                objPesquisa.Autor = livro.Autor;

                CadastrarLivro(objPesquisa);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CadastrarLivro(LivroDto livro)
        {
            try
            {
                livros.Add(livro);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirLivro(string id)
        {
            try
            {
                LivroDto objPesquisa = pesquisarLivroPorId(id);
                livros.Remove(objPesquisa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LivroDto> ListarLivro()
        {
            try
            {
                return livros
                    .OrderBy(p => p.Nome)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LivroDto pesquisarLivroPorId(string id)
        {
            try
            {
                return livros.FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
