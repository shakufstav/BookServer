using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace ViewModel
{
    public class BooksLibraryDB : BaseDB
    {
        public BooksLibraryDB() : base() { }

        static private BooksLibraryList list = new BooksLibraryList();

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            BooksLibrary booksLibrary = entity as BooksLibrary;
            booksLibrary.AddDate = DateTime.Parse(reader["addDate"].ToString());

            int userid = int.Parse(reader["userId"].ToString());
            booksLibrary.UserId = UserDB.SelectById(userid);

            int bookid = int.Parse(reader["bookId"].ToString());
            booksLibrary.BookId = BooksDB.SelectById(bookid);

            int bookCategory = int.Parse(reader["bookCategory"].ToString());
            booksLibrary.BookCategory = CategoryDB.SelectById(bookCategory);

            base.CreateModel(entity);
            return booksLibrary;
        }
        public static BooksLibrary SelectById(int id)
        {
            if (list.Count == 0)
            {
                BooksLibraryDB db = new BooksLibraryDB();
                list = db.SelectAll();
            }
            BooksLibrary booksLibrary = list.Find(item => item.Id == id);
            return booksLibrary;
        }
        public BooksLibraryList SelectAll()
        {
            command.CommandText = $"select * from  booksLibraryTbl";
            BooksLibraryList blList = new BooksLibraryList(base.Select());
            return blList;
        }
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            BooksLibrary booksLibrary = entity as BooksLibrary;
            string sqlStr = $"DELETE FROM booksLibraryTbl WHERE ID = @id";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@id", booksLibrary.Id));
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            BooksLibrary booksLibrary = entity as BooksLibrary;
            if (booksLibrary != null)
            {
                string sqlStr = $"INSERT INTO booksLibraryTbl ( UserId,BookId,AddDate,BookCategory) " +
                                $" Values (@userId,bookId,addDate,bookCategory)";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@userId", booksLibrary.UserId.Id));
                cmd.Parameters.Add(new OleDbParameter("@bookId", booksLibrary.BookId.Id));
                cmd.Parameters.Add(new OleDbParameter("@addDate", DateTime.Parse(booksLibrary.AddDate.Date.ToString())));
                cmd.Parameters.Add(new OleDbParameter("@bookCategory", booksLibrary.BookCategory.Id));


            }
        }
        public override void Update(BaseEntity entity)
        {
            if (entity as BooksLibrary!=null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
            }
        }
        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            BooksLibrary booksLibrary = entity as BooksLibrary;

            string sqlStr = $"UPDATE booksLibraryTbl SET userId='{booksLibrary.UserId.Id}', bookId ='{booksLibrary.BookId.Id}', addDate='{DateTime.Parse(booksLibrary.AddDate.Date.ToString())}', bookCategory='{booksLibrary.BookCategory.Id}' " +
                $" WHERE ID =@id";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@id", booksLibrary.Id));
        }

        protected override BaseEntity NewEntity()
        {
            return new BooksLibrary();
        }
    }
}
