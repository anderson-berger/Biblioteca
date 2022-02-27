using BibliotecaMVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaMVC.Models.Repositories
{
    public class SqlManager
    {     
        public static string GetSql(Tsql tsql)
        {
            string sql = "";

            switch (tsql)
            {
                case Tsql.CADASTRA_LIVRO:
                    sql = "insert into livro (id, nome, autor, editora) values (@id, @nome, @autor, @editora)";
                    break;
                case Tsql.ATUALIZA_LIVRO:
                    sql = "update livro set nome = @nome, autor = @autor, editora = @editora  where id = @id";
                    break;
                case Tsql.LISTA_LIVRO:
                    sql = "select id, nome, autor, editora from livro order by nome";
                    break;
                case Tsql.PESQUISAR_LIVRO:
                    sql = "select id, nome, autor, editora from livro where id = @id";
                    break;
                case Tsql.EXCLUIR_LIVRO:
                    sql = "delete from livro where id = @id";
                    break;
            }
            return sql;
        }

        

    }
}
