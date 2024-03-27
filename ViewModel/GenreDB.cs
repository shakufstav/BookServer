using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class GenreDB:BaseDB
    {
        static private GenreList list = new GenreList();

        public GenreDB() : base()
        {

        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Genre g = entity as Genre;
            g.GenreName = reader["generName"].ToString();
            base.CreateModel(entity);
            return g;
        }
        public GenreList SelectAll()
        {
            command.CommandText = $"select * from  GenreTbl";
            GenreList gList = new GenreList(base.Select());
            return gList;

        }
        public static Genre SelectById(int id)
        {
            if (list.Count == 0)
            {
                GenreDB db = new GenreDB();
                list = db.SelectAll();
            }
            Genre genre = list.Find(item => item.Id == id);
            return genre;
        }
        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Genre genre = entity as Genre;
            if (genre != null)
            {
                string sqlStr = $"INSERT INTO genreTbl (GenerName) " +
                                $" Values (@generName)";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@generName", genre.GenreName));


            }
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Genre genre = entity as Genre;

            string sqlStr = $"UPDATE genreTbl SET  GenerName='{genre.GenreName}' " +
                $" WHERE ID =@Id";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@Id", genre.Id));
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Genre genre = entity as Genre;
            string sqlStr = $"DELETE FROM genreTbl WHERE ID = @Id";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@Id", genre.Id));
        }
        
    

        protected override BaseEntity NewEntity()
        {
            return new Genre();
        }
    }
}
