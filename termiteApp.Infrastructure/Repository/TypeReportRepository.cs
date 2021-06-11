using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using termiteApp.Core.Domain;
using termiteApp.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace termiteApp.Infrastructure
{
   public class TypeReportRepository: ITypeReportRepository
    {
        private readonly IConfiguration _configuration;

        //constructor
        public TypeReportRepository(IConfiguration configuration)
        {
            _configuration = (configuration != null) ? configuration : throw new ArgumentNullException(nameof(configuration));
        }

        public TypeReport GetTypeReport(TypeReport model)
        {
            TypeReport newModel = null;
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    string query = "SELECT trpId, trpName, trpDescription FROM TypeReport WHERE trpId = @trpId ";
                    con.Open();
                    using (SqlTransaction sqlTran = con.BeginTransaction())
                    {
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Transaction = sqlTran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("trpId", model.trpId);

                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    newModel = new TypeReport()
                                    {
                                        trpId = (sdr["trpId"] != null) ? int.Parse(sdr["trpId"].ToString()) : 0,
                                        trpName = sdr["trpName"].ToString(),
                                        trpDescription = sdr["trpDescription"].ToString()
                                    };

                                }
                            }
                            sqlTran.Commit();
                        }
                    }
                    con.Close();
                }
            }

            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }
            return newModel;
        }

        //method to insert type of report
        public TypeReport InsertTypeReport(TypeReport model)
        {
            TypeReport newModel = null;
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {

                    con.Open();
                    using (SqlTransaction sqltran = con.BeginTransaction())
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "insertTypeReport";
                            cmd.Transaction = sqltran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("trpName", model.trpName);
                            cmd.Parameters.AddWithValue("trpDescription", model.trpDescription);
                            int result = cmd.ExecuteNonQuery();
                            sqltran.Commit();
                            newModel = model;

                        }
                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }
            return newModel;
        }

        public TypeReport UpdateTypeReport(TypeReport model)
        {
            TypeReport newModel = null;
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    con.Open();
                    using (SqlTransaction sqltran = con.BeginTransaction())
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "updateTypeReport";
                            cmd.Transaction = sqltran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("trpName", model.trpName);
                            cmd.Parameters.AddWithValue("trpDescription", model.trpDescription);
                            cmd.Parameters.AddWithValue("trpId", model.trpId);
                            int result = cmd.ExecuteNonQuery();
                            sqltran.Commit();
                            newModel = model;

                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }
            return newModel;
        }

        //get report
        public IEnumerable<TypeReport> ObtainTypeReport()
        {
            List<TypeReport> list = new List<TypeReport>();
            TypeReport model = null;
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {

                    string query = "SELECT trpId, trpName, trpDescription FROM TypeReport";
                    con.Open();
                    using (SqlTransaction sqltran = con.BeginTransaction())
                    {
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Transaction = sqltran;
                            cmd.Connection = con;
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    list.Add(new TypeReport()
                                    {
                                        trpId = (sdr["trpId"] != null) ? int.Parse(sdr["trpId"].ToString()) : 0,
                                        trpName = sdr["trpName"].ToString(),
                                        trpDescription = sdr["trpDescription"].ToString(),


                                    });
                                }
                            }
                            sqltran.Commit();
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }

            return list;
        }

        //delete typereport
        public TypeReport DeleteTypeReport(TypeReport model)
        {
            TypeReport newModel = null;
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    con.Open();
                    using (SqlTransaction sqlTran = con.BeginTransaction())
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "deleteTypeReport";
                            cmd.Transaction = sqlTran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("trpId", model.trpId);
                            int result = cmd.ExecuteNonQuery();
                            sqlTran.Commit();
                            newModel = model;
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }
            return newModel;
        }




    }
}
