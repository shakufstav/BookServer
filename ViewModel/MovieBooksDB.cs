using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MovieBooksDB:BooksDB
    {
        static private MovieBooksList list =new MovieBooksList();

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            MovieBooks m = entity as MovieBooks;
            m.Trailer = reader["Trailer"].ToString();
            base.CreateModel(entity);
            return m;
        }
        
        public MovieBooksList SelectAll()
        {
            command.CommandText = $"SELECT booksTbl.Id, booksTbl.bookName, booksTbl.writer, booksTbl.genre, moviesBooksTbl.Trailer FROM (moviesBooksTbl INNER JOIN booksTbl ON moviesBooksTbl.Id = booksTbl.Id)";
            MovieBooksList mList = new MovieBooksList(base.Select());
            return mList;

        }
        public static MovieBooks SelectById(int id)
        {
            if (list.Count == 0)
            {
                MovieBooksDB db = new MovieBooksDB();
                list = db.SelectAll();
            }
            MovieBooks moviebooks = list.Find(item => item.Id == id);
            return moviebooks;
        }
        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            MovieBooks movieBoooks = entity as MovieBooks;
            if (movieBoooks != null)
            {
                string sqlStr = $"INSERT INTO moviesBooksTbl (Id,Trailer) " +
                                $" Values (@Id,@Trailer)";
                string s = movieBoooks.Trailer;
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@Id", movieBoooks.Id));
                cmd.Parameters.Add(new OleDbParameter("@Trailer", movieBoooks.Trailer));

            }
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {

            MovieBooks movieBoooks = entity as MovieBooks;

            string sqlStr = $"UPDATE moviesBooksTbl SET  Trailer='{movieBoooks.Trailer}' " +
                $" WHERE ID =@id";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@id", movieBoooks.Id));
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {

            MovieBooks movieBoooks = entity as MovieBooks;
            string sqlStr = $"DELETE FROM moviesBooksTbl WHERE ID = @Id";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@Id", movieBoooks.Id));
        }

        protected override BaseEntity NewEntity()
        {
            return new MovieBooks();
        }
    }
}
