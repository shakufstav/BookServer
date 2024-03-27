using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BooksDB : BaseDB
    {
        static private BooksList list = new BooksList();

        public BooksDB() : base() 
        { 

        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Books book = entity as Books;
            book.BookName = reader["bookName"].ToString();
            
            int writer = int.Parse(reader["writer"].ToString());
            book.Writer = WriterDB.SelectById(writer);
            
            int genre = int.Parse(reader["genre"].ToString());
            book.Genre =    GenreDB.SelectById(genre);
            
            base.CreateModel(entity);
            return book;
        }
        public static Books SelectById(int id)
        {
            if (list.Count == 0)
            {
                BooksDB db = new BooksDB();
                list = db.SelectAll();
            }
            Books books = list.Find(item => item.Id == id);
            return books;
        }
        public BooksList SelectAll()
        {
            command.CommandText = $"select * from  booksTbl";
            BooksList bList = new BooksList(base.Select());
            return bList;
        }
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Books books = entity as Books;
            string sqlStr = $"DELETE FROM booksTbl WHERE ID = @Id";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@Id", books.Id));
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Books books = entity as Books;
            if (books != null)
            {
                string sqlStr = $"INSERT INTO booksTbl ( BookName,Writer,Genre) " +
                                $" Values (@bookName,@writer,@genre)";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@bookName", books.BookName));
                cmd.Parameters.Add(new OleDbParameter("@writer", books.Writer.Id));
                cmd.Parameters.Add(new OleDbParameter("@genre", books.Genre.Id));

            }
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Books books = entity as Books;

            string sqlStr = $"UPDATE booksTbl SET bookName='{books.BookName}', Writer ={books.Writer.Id}, Genre={books.Genre.Id} " +
                $" WHERE ID =@Id";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@Id", books.Id));
            
        }

        protected override BaseEntity NewEntity()
        {
            return new Books();
        }
    }
}
