using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class WriterDB:BaseDB
    {
        static private WriterList list = new WriterList();

        public WriterDB() : base()
        {

        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Writer w = entity as Writer;
            w.WriterName = reader["WriterName"].ToString();
            base.CreateModel(entity);
            return w;
        }
        public WriterList SelectAll()
        {
            command.CommandText = $"select * from  writersTbl";
            WriterList wList = new WriterList(base.Select());
            return wList;

        }
        public static Writer SelectById(int id)
        {
            if (list.Count == 0)
            {
                WriterDB db = new WriterDB();
                list = db.SelectAll();
            }
            Writer writer = list.Find(item => item.Id == id);
            return writer;
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Writer writer = entity as Writer;
            if (writer != null)
            {
                string sqlStr = $"INSERT INTO writersTbl (WriterName) " +
                                $" Values (@writerName)";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@writerName", writer.WriterName));


            }
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Writer writer = entity as Writer;

            string sqlStr = $"UPDATE writersTbl SET  WriterName='{writer.WriterName}' " +
                $" WHERE ID =@Id";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@Id", writer.Id));
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Writer writer = entity as Writer;
            string sqlStr = $"DELETE FROM writersTbl WHERE ID = @Id";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@Id", writer.Id));
        }

        protected override BaseEntity NewEntity()
        {
            return new Writer();
        }
    }
}
