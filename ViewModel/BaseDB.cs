using System;
using System.Collections.Generic;

using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.OleDb;

namespace ViewModel
{
    public abstract class BaseDB
    {

        protected string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + System.IO.Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../../../../../../ViewModel/BookReviewSProject1.accdb");
        protected static OleDbConnection connection;
        protected OleDbCommand command;
        protected OleDbDataReader reader;

        public static List<ChangeEntity> inserted = new List<ChangeEntity>();
        public static List<ChangeEntity> deleted = new List<ChangeEntity>();
        public static List<ChangeEntity> updated = new List<ChangeEntity>();

        protected abstract void CreateInsertSQL(BaseEntity entity, OleDbCommand cmd);
        protected abstract void CreateUpdateSQL(BaseEntity entity, OleDbCommand cmd);
        protected abstract void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd);

        protected abstract BaseEntity NewEntity();

        public virtual void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity)); ;
            }
        }

        public virtual void Update(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
            }
        }

        public virtual void Delete(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
            }
        }
         
        public static void CloseConnection()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        protected List<BaseEntity> Select()
        {
            List<BaseEntity> list = new List<BaseEntity>();

            try
            {
               // command.Connection = connection;
                // command.CommandTGext = sqlStr;
               // connection.Open();
               if(connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                reader = command.ExecuteReader();


                while (reader.Read())
                {
                    BaseEntity entity = NewEntity();
                    list.Add(CreateModel(entity));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(
                    e.Message + "\nSQL:" + command.CommandText);
            }
            finally
            {
                if (reader != null) reader.Close();
            }

            return list;
        }

        //protected async Task<List<BaseEntity>> SelectAsync(string sqlStr)
        //{
        //    OleDbConnection connection = new OleDbConnection();
        //    OleDbCommand command = new OleDbCommand();
        //    List<BaseEntity> list = new List<BaseEntity>();

        //    try
        //    {
        //        command.Connection = connection;
        //        command.CommandText = sqlStr;
        //        connection.Open();
        //        this.reader = (OleDbDataReader)await command.ExecuteReaderAsync();


        //        while (reader.Read())
        //        {
        //            BaseEntity entity = NewEntity();
        //            list.Add(CreateModel(entity));
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL:" + command.CommandText);
        //    }
        //    finally
        //    {
        //        if (reader != null) reader.Close();
        //        if (connection.State == ConnectionState.Open) connection.Close();
        //    }

        //    return list;
        //}
        public BaseDB()
        {
            connection ??= new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = connection;
        }

        public int SaveChanges()
        {
            OleDbTransaction trans = null;

            int records_affected = 0;

            try
            {
                //connection.Open();
                if(connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                trans = connection.BeginTransaction();
                command.Transaction = trans;

                foreach (var entity in inserted)
                {
                    command.Parameters.Clear();
                    entity.CreateSql(entity.Entity, command); //cmd.CommandText = CreateInsertSQL(entity.Entity);
                    records_affected += command.ExecuteNonQuery();

                    command.CommandText = "Select @@Identity";
                    entity.Entity.Id = (int)command.ExecuteScalar();
                }

                foreach (var entity in updated)
                {
                    command.Parameters.Clear();
                    entity.CreateSql(entity.Entity, command); //cmd.CommandText = CreateUpdateSQL(entity.Entity);
                    records_affected += command.ExecuteNonQuery();
                }

                foreach (var entity in deleted)
                {
                    command.Parameters.Clear();
                    entity.CreateSql(entity.Entity, command);

                    records_affected += command.ExecuteNonQuery();
                }

                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                System.Diagnostics.Debug.WriteLine(ex.Message + "\n SQL:" + command.CommandText);
            }
            finally
            {
                inserted.Clear();
                updated.Clear();
                deleted.Clear();

              
                  
            }

            return records_affected;
        }

        //public async Task<int> SaveChangesAsync()
        //{
        //    int records_affected = 0;
        //    OleDbCommand command = new OleDbCommand();
        //    try
        //    {
        //        command.Connection = this.connection;
        //        this.connection.Open();

        //        foreach (var item in inserted)
        //        {
        //            command.Parameters.Clear();
        //            item.CreateSql(item.Entity, command);
        //            records_affected += await command.ExecuteNonQueryAsync();

        //            command.CommandText = "Select @@Identity";
        //            item.Entity.Id = (int)command.ExecuteScalarAsync().Result;
        //        }

        //        foreach (var item in updated)
        //        {
        //            command.Parameters.Clear();
        //            item.CreateSql(item.Entity, command);
        //            records_affected += await command.ExecuteNonQueryAsync();
        //        }

        //        foreach (var item in deleted)
        //        {
        //            command.Parameters.Clear();
        //            item.CreateSql(item.Entity, command);
        //            records_affected += await command.ExecuteNonQueryAsync();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL:" + command.CommandText);
        //    }
        //    finally
        //    {
        //        inserted.Clear();
        //        updated.Clear();
        //        deleted.Clear();

        //        if (connection.State == ConnectionState.Open) connection.Close();
        //    }

        //    return records_affected;
        //}
        protected virtual BaseEntity CreateModel(BaseEntity entity)
        {
            entity.Id = (int)reader["ID"];
            return entity;
        }
    }
}