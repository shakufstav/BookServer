using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CommentsDB : BaseDB
    {
        public CommentsDB() :base() { }

        static private CommentsList list = new CommentsList();

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Comments comments = entity as Comments;
            comments.Comment = reader["comment"].ToString();

            int bookid = int.Parse(reader["bookId"].ToString());
            comments.BookId = BooksDB.SelectById(bookid);

            int userid = int.Parse(reader["userId"].ToString());
            comments.UserId = UserDB.SelectById(userid);

            base.CreateModel(entity);
            return comments;
        }
        public static Comments SelectById(int id)
        {
            if (list.Count == 0)
            {
                CommentsDB db = new CommentsDB();
                list = db.SelectAll();
            }
            Comments comments = list.Find(item => item.Id == id);
            return comments;
        }
        public CommentsList SelectAll()
        {
            command.CommandText = $"select * from  commentsTbl";
            CommentsList cList = new CommentsList(base.Select());
            return cList;
        }
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Comments comments = entity as Comments;
            string sqlStr = $"DELETE FROM commentsTbl WHERE ID = @id";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@id", comments.Id));
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Comments comments = entity as Comments;
            if (comments != null)
            {
                string sqlStr = $"INSERT INTO commentsTbl ( UserId,BookId,comment) " +
                                $" Values (@userId,bookId,comment)";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@userId", comments.UserId.Id));
                cmd.Parameters.Add(new OleDbParameter("@bookId", comments.BookId.Id));
                cmd.Parameters.Add(new OleDbParameter("@addDate", comments.Comment));
            }
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Comments comments = entity as Comments;

            string sqlStr = $"UPDATE commentsTbl SET userId='{comments.UserId.Id}', bookId ='{comments.BookId.Id}', comment='{comments.Comment}' " +
                $" WHERE ID =@id";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@id", comments.Id));
        }

        protected override BaseEntity NewEntity()
        {
            return new Comments();
        }
    }
}
