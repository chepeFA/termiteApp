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
    public class SectionRepository : ISectionRepository
    {
        private readonly IConfiguration _configuration;

        //constructor

        public SectionRepository(IConfiguration configuration)
        {
            _configuration = (configuration != null) ? configuration : throw new ArgumentNullException(nameof(configuration));
        }

        public Section GetSection(Section model)
        {
            Section newModel = null;
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    string query = "SELECT sctId, sctName, sctDescription FROM Section WHERE sctId = @sctId ";
                    con.Open();
                    using (SqlTransaction sqlTran = con.BeginTransaction())
                    {
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Transaction = sqlTran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("sctId", model.SctId);

                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    newModel = new Section();
                                    {
                                        model.SctId = (sdr["sctId"] != null) ? int.Parse(sdr["sctId"].ToString()) : 0;
                                        model.SctName = sdr["sctName"].ToString();
                                        model.SctDescription = sdr["sctDescription"].ToString();
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

        public Section InsertSection(Section model)
        {
            Section newModel = null;
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
                            cmd.CommandText = "insertSection";
                            cmd.Transaction = sqltran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("sctName", model.SctName);
                            cmd.Parameters.AddWithValue("sctDescription", model.SctDescription);
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

        public Section UpdateSection(Section model)
        {
            Section newModel = null;
            try
            {
                using(SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    con.Open();
                    using(SqlTransaction sqltran = con.BeginTransaction())
                    {
                        using(SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "updateSection";
                            cmd.Transaction = sqltran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("sctName", model.SctName);
                            cmd.Parameters.AddWithValue("sctDescription", model.SctDescription);
                            cmd.Parameters.AddWithValue("sctId", model.SctId);
                            int result = cmd.ExecuteNonQuery();
                            sqltran.Commit();
                            newModel = model;

                        }
                    }
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }
            return newModel;
        }

        public IEnumerable<Section> ObtainSection()
        {
            List<Section> list = new List<Section>();
            Section model = null;
            try
            {
                using(SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"))) 
                    {

                    string query = "SELECT sctId, sctName, sctDescription FROM Section";
                    con.Open();
                    using (SqlTransaction sqltran = con.BeginTransaction())
                    {
                        using(SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Transaction = sqltran;
                            cmd.Connection = con;
                            using(SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while(sdr.Read())
                                {
                                    list.Add(new Section()
                                        {
                                        SctId = (sdr["sctId"] != null) ? int.Parse(sdr["sctId"].ToString()) : 0,
                                        SctName = sdr["sctName"].ToString(),
                                        SctDescription = sdr["sctDescription"].ToString(),


                                    });
                                }
                            }
                            sqltran.Commit();
                        }
                    }
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.ToString());
            }

            return list;
        }


        public Section deleteSection(Section model)
        {
            Section newModel = null;
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
                            cmd.CommandText = "deleteSection";
                            cmd.Transaction = sqlTran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("SctId", model.SctId);
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
