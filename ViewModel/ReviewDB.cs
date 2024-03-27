using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ReviewDB : BaseDB
    {
        public ReviewDB() : base() { }

        static private ReviewList list = new ReviewList();

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Review review = entity as Review;
            review.Star = int.Parse(reader["star"].ToString());

            int bookid = int.Parse(reader["bookId"].ToString());
            review.BookId = BooksDB.SelectById(bookid);

            int userid = int.Parse(reader["userId"].ToString());
            review.UserId = UserDB.SelectById(userid);

            base.CreateModel(entity);
            return review;
        }
        public static Review SelectById(int id)
        {
            if (list.Count == 0)
            {
                ReviewDB db = new ReviewDB();
                list = db.SelectAll();
            }
            Review review = list.Find(item => item.Id == id);
            return review;
        }
        public ReviewList SelectAll()
        {
            command.CommandText = $"select * from  reviewTbl";
            ReviewList rList = new ReviewList(base.Select());
            return rList;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Review review = entity as Review;
            string sqlStr = $"DELETE FROM reviewTbl WHERE ID = @id";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@id", review.Id));
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Review review = entity as Review;
            if (review != null)
            {
                string sqlStr = $"INSERT INTO reviewTbl ( UserId,BookId,Star) " +
                                $" Values (@userId,bookId,star)";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@userId", review.UserId.Id));
                cmd.Parameters.Add(new OleDbParameter("@bookId", review.BookId.Id));
                cmd.Parameters.Add(new OleDbParameter("@star", review.Star));
            }
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Review review = entity as Review;

            string sqlStr = $"UPDATE reviewTbl SET userId='{review.UserId.Id}', bookId ='{review.BookId.Id}', star='{review.Star}' " +
                $" WHERE ID =@id";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@id", review.Id));
        }

        protected override BaseEntity NewEntity()
        {
            return new Review();
        }
    }
}
