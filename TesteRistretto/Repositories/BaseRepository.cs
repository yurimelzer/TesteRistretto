using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteRistretto.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        protected List<T> GetAll(string query, SqlParameter[] sqlParameters = null)
        {
            List<T> list = new List<T>();

            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.CommandType = CommandType.Text;
                    if(sqlParameters != null)
                     command.Parameters.AddRange(sqlParameters);

                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(ReaderToEntity(reader));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    return list;
                }
            }
        }

        protected T GetById(string query, int id, SqlParameter sqlParameter)
        {
            T entity = null;

            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.CommandType = CommandType.Text;

                    command.Parameters.Add(sqlParameter);

                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                entity = ReaderToEntity(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    return entity;
                }
            }
        }

        protected int Add(string query, T entity, SqlParameter[] sqlParameters)
        {
            int id = 0;

            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            query += " SELECT cast(scope_identity() as int); ";

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddRange(sqlParameters);

                    try
                    {
                        conn.Open();

                        id = (int)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    return id;
                }
            }
        }

        protected int Update(string query, T entity, SqlParameter[] sqlParameters)
        {
            int rowsUpdated = 0;

            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
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
                        throw ex;
                    }

                    return rowsUpdated;
                }
            }
        }

        protected bool Delete(string query, int id, SqlParameter sqlParameter)
        {
            int rowsUpdated = 0;

            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
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
                        throw ex;
                    }

                    return rowsUpdated == 1;
                }
            }
        }

        protected abstract T ReaderToEntity(SqlDataReader reader);
    }
}
