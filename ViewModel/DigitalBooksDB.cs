using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class DigitalBooksDB:BooksDB
    {
        static private DigitalBooksList list = new DigitalBooksList();

        public DigitalBooksDB() : base()
        {

        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            DigitalBooks d = entity as DigitalBooks;
            d.AudioLink = reader["AudioLink"].ToString();
            base.CreateModel(entity);
            return d;
        }
        public DigitalBooksList SelectAll()
        {
            command.CommandText = $"SELECT booksTbl.Id, booksTbl.bookName, booksTbl.writer, booksTbl.genre, digitalBooksTbl.AudioLink FROM (booksTbl INNER JOIN digitalBooksTbl ON booksTbl.Id = digitalBooksTbl.Id)";
            DigitalBooksList dList = new DigitalBooksList(base.Select());
            return dList;

        }
        public static DigitalBooks SelectById(int id)
        {
            if (list.Count == 0)
            {
                DigitalBooksDB db = new DigitalBooksDB();
                list = db.SelectAll();
            }
            DigitalBooks digitalBooks = list.Find(item => item.Id == id);
            return digitalBooks;
        }
        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            DigitalBooks digitalBooks = entity as DigitalBooks;
            if (digitalBooks != null)
            {
                string sqlStr = $"INSERT INTO digitalBooksTbl (Id,AudioLink) " +
                                $" Values (@Id,@AudioLink)";
                string s = digitalBooks.AudioLink;
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@Id", digitalBooks.Id));
                cmd.Parameters.Add(new OleDbParameter("@AudioLink", digitalBooks.AudioLink));

            }
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            DigitalBooks digitalBooks = entity as DigitalBooks;

            string sqlStr = $"UPDATE digitalBooksTbl SET  AudioLink='{digitalBooks.AudioLink}' " +
                $" WHERE ID =@id";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@id", digitalBooks.Id));
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            DigitalBooks digitalBooks = entity as DigitalBooks;
            string sqlStr = $"DELETE FROM digitalBooksTbl WHERE ID = @Id";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@Id", digitalBooks.Id));
        }

        protected override BaseEntity NewEntity()
        {
            return new DigitalBooks();
        }
    }
}
