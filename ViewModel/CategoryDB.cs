using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class CategoryDB:BaseDB

    {
        public CategoryDB() : base()
        {
           
        }
        static private CategoryList list = new CategoryList();

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Category c = entity as Category;
            c.BookCategory = reader["BookCategory"].ToString();
            base.CreateModel(entity);
            return c;
        }
        public CategoryList SelectAll()
        {
            command.CommandText = $"select * from  categoryTbl";
            CategoryList cList = new CategoryList(base.Select());
            return cList;

        }
        public static Category SelectById(int id)
        {
            if (list.Count == 0)
            {
                CategoryDB db = new CategoryDB();
                list = db.SelectAll();
            }
            Category category = list.Find(item => item.Id == id);
            return category;
        }
        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Category category = entity as Category;
            if (category != null)
            {
                string sqlStr = $"INSERT INTO categoryTbl (BookCategory) " +
                                $" Values (@bookCategory)";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@bookCategory", category.BookCategory));


            }
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Category category = entity as Category;

            string sqlStr = $"UPDATE categoryTbl SET  bookCategory='{category.BookCategory}' " +
                $" WHERE ID =@id";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@id", category.Id));
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Category category = entity as Category;
            string sqlStr = $"DELETE FROM categoryTbl WHERE ID = @id";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@id", category.Id));
        }

        protected override BaseEntity NewEntity()
        {
            return new Category();
        }
    }
}
