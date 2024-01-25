using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace TesteRistretto.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        protected List<T> GetAll(string query, SQLiteParameter[] sqlParameters = null)
        {
            List<T> list = new List<T>();

            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SQLiteConnection sqlConnection = new SQLiteConnection(strCon))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, sqlConnection))
                {
                    command.CommandType = CommandType.Text;
                    if (sqlParameters != null)
                        command.Parameters.AddRange(sqlParameters);

                    try
                    {
                        sqlConnection.Open();

                        using (SQLiteDataReader reader = command.ExecuteReader(CommandBehavior.Default))
                        {
                            while (reader.Read())
                            {
                                list.Add(ReaderToEntity(reader));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    return list;
                }
            }

        }

        protected T GetById(string query, int id, SQLiteParameter sqlParameter)
        {
            T entity = null;

            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SQLiteConnection sqlConnection = new SQLiteConnection(strCon))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, sqlConnection))
                {
                    command.CommandType = CommandType.Text;

                    command.Parameters.Add(sqlParameter);

                    try
                    {
                        sqlConnection.Open();

                        using (SQLiteDataReader reader = command.ExecuteReader(CommandBehavior.Default))
                        {
                            while (reader.Read())
                            {
                                entity = ReaderToEntity(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    return entity;
                }
            }
        }

        protected int Add(string query, T entity, SQLiteParameter[] sqlParameters)
        {
            object id = 0;

            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            query += "; SELECT last_insert_rowid(); ";

            using (SQLiteConnection conn = new SQLiteConnection(strCon))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                {
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddRange(sqlParameters);

                    try
                    {
                        conn.Open();

                        id = command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    return Convert.ToInt32(id);
                }
            }
        }

        protected int Update(string query, T entity, SQLiteParameter[] sqlParameters)
        {
            int rowsUpdated = 0;

            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SQLiteConnection conn = new SQLiteConnection(strCon))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                {
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddRange(sqlParameters);

                    try
                    {
                        conn.Open();

                        rowsUpdated = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    return rowsUpdated;
                }
            }
        }

        protected bool Delete(string query, int id, SQLiteParameter sqlParameter)
        {
            int rowsUpdated = 0;

            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SQLiteConnection conn = new SQLiteConnection(strCon))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                {
                    command.CommandType = CommandType.Text;

                    command.Parameters.Add(sqlParameter);

                    try
                    {
                        conn.Open();

                        rowsUpdated = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    return rowsUpdated == 1;
                }
            }
        }

        protected abstract T ReaderToEntity(SQLiteDataReader reader);
    }
}
