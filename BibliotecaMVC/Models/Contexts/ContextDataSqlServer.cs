using BibliotecaMVC.Models.Contracts.Contexts;
using BibliotecaMVC.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaMVC.Models.Contracts.Repositories;
using BibliotecaMVC.Models.Repositories;
using BibliotecaMVC.Models.Enums;
using System.Data;

namespace BibliotecaMVC.Models.Contexts
{
    public class ContextDataSqlServer : IContextData
    {
        private readonly SqlConnection _connection = null;

        public ContextDataSqlServer(IConnectionManager connectionManager)
        {
            _connection = connectionManager.GetConnection();
        }
        public void AtualizarLivro(LivroDto livro)
        {
            try
            {
                _connection.Open();
                string query = SqlManager.GetSql(Tsql.ATUALIZA_LIVRO);

                SqlCommand command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = livro.ID;
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = livro.Nome;
                command.Parameters.Add("@autor", SqlDbType.VarChar).Value = livro.Autor;
                command.Parameters.Add("@editora", SqlDbType.VarChar).Value = livro.Editora;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }

        public void CadastrarLivro(LivroDto livro)
        {
            try
            {
                _connection.Open();
                string query = SqlManager.GetSql(Tsql.CADASTRA_LIVRO);

                SqlCommand command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = livro.ID;
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = livro.Nome;
                command.Parameters.Add("@autor", SqlDbType.VarChar).Value = livro.Autor;
                command.Parameters.Add("@editora", SqlDbType.VarChar).Value = livro.Editora;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }

        public void ExcluirLivro(string id)
        {
            try
            {
                _connection.Open();
                string query = SqlManager.GetSql(Tsql.EXCLUIR_LIVRO);

                SqlCommand command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

        }

        public List<LivroDto> ListarLivro()
        {
            List<LivroDto> livros = new List<LivroDto>();
            try
            {
                string query = SqlManager.GetSql(Tsql.LISTA_LIVRO);

                SqlCommand command = new SqlCommand(query, _connection);

                DataSet dataset = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataset);

                DataRowCollection rows = dataset.Tables[0].Rows;

                foreach (DataRow item in rows)
                {
                    object[] colunas = item.ItemArray;

                    string id = colunas[0].ToString();
                    string nome = colunas[1].ToString();
                    string autor = colunas[2].ToString();
                    string editora = colunas[3].ToString();

                    LivroDto livro = new LivroDto(id, nome, autor, editora);

                    livros.Add(livro);
                }

                dataAdapter = null;
                dataset = null;

                return livros;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

        }

        public LivroDto pesquisarLivroPorId(string id)
        {
            LivroDto livro = new LivroDto();

            try
            {

                string query = SqlManager.GetSql(Tsql.PESQUISAR_LIVRO);

                SqlCommand command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

                DataSet dataset = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataset);

                DataRowCollection rows = dataset.Tables[0].Rows;

                foreach (DataRow item in rows)
                {
                    object[] colunas = item.ItemArray;

                    string codigo = colunas[0].ToString();
                    string nome = colunas[1].ToString();
                    string autor = colunas[2].ToString();
                    string editora = colunas[3].ToString();

                    livro = new LivroDto(id, nome, autor, editora);
                }
                dataAdapter = null;
                dataset = null;

                return livro;

            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
               
            }

        }
    }
}
