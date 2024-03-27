using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        static private UserList list = new UserList();

        public UserDB() :base() { }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = entity as User;
            user.UserName = reader["userName"].ToString();
            user.Ppassword1 = int.Parse(reader["Ppassword"].ToString());
            user.Email = reader["email"].ToString();

            base.CreateModel(entity);
            return user;
        }
        public static User SelectById(int id)
        {
            if (list.Count == 0)
            {
                UserDB db = new UserDB();
                list = db.SelectAll();
            }
            User user = list.Find(item => item.Id == id);
            return user;
        }
        public UserList SelectAll()
        {
            command.CommandText = $"select * from  userTbl";
            UserList uList = new UserList(base.Select());
            return uList;
        }
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            User user = entity as User;
            string sqlStr = $"DELETE FROM userTbl WHERE ID = @id";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@id", user.Id));
        }

        protected override void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd)
        {
            User user = entity as User;
            if (user != null)
            {
                string sqlStr = $"INSERT INTO userTbl ( userName,Ppassword,email) " +
                                $" Values (@userName,Ppassword,email)";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@userName", user.UserName));
                cmd.Parameters.Add(new OleDbParameter("@Ppassword", user.Ppassword1));
                cmd.Parameters.Add(new OleDbParameter("@email", user.Email));
            }
        }

        protected override void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd)
        {
            User user = entity as User;

            string sqlStr = $"UPDATE userTbl SET userName='{user.UserName}', Ppassword ='{user.Ppassword1}', email='{user.Email}' " +
                $" WHERE ID =@id";

            cmd.CommandText = sqlStr;
            cmd.Parameters.Add(new OleDbParameter("@id", user.Id));
        }

        protected override BaseEntity NewEntity()
        {
            return new User();
        }
    }
}
