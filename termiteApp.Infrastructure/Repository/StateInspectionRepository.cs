using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using termiteApp.Core.Domain;
using termiteApp.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace termiteApp.Infrastructure.Repository
{
    public class StateInspectionRepository : IStateSectionRepository
    {

        private readonly IConfiguration _configuration;

        public StateInspectionRepository(IConfiguration configuration)
        {
            _configuration = (configuration != null) ? configuration : throw new ArgumentNullException(nameof(configuration));
        }

        public StateInspection GetStateInspection(StateInspection model)
        {
            StateInspection newModel = null;
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    string query = "SELECT sinsId, sinsName, sinsDescription FROM StateInspection WHERE sinsId = @sinsId ";
                    con.Open();
                    using (SqlTransaction sqlTran = con.BeginTransaction())
                    {
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Transaction = sqlTran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("sinsId", model.sinsId);

                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    newModel = new StateInspection()
                                    {
                                        sinsId = (sdr["sinsId"] != null) ? int.Parse(sdr["sinsId"].ToString()) : 0,
                                        sinsName = sdr["sinsName"].ToString(),
                                       sinsDescription = sdr["sinsDescription"].ToString()
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

        public StateInspection InsertStateInspection(StateInspection model)
        {
            StateInspection newModel = null;
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
                            cmd.CommandText = "insertStateInspection";
                            cmd.Transaction = sqltran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("sinsName", model.sinsName);
                            cmd.Parameters.AddWithValue("sinsDescription", model.sinsDescription);
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

        public StateInspection UpdateStateInspection(StateInspection model)
        {
            StateInspection newModel = null;
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
                            cmd.CommandText = "updateStateInspection";
                            cmd.Transaction = sqltran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("sinsName", model.sinsName);
                            cmd.Parameters.AddWithValue("sinsDescription", model.sinsDescription);
                            cmd.Parameters.AddWithValue("sinsId", model.sinsId);
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

        public IEnumerable<StateInspection> ObtainStateInspection()
        {
            List<StateInspection> list = new List<StateInspection>();
            StateInspection model = null;
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {

                    string query = "SELECT sinsId, sinsName, sinsDescription FROM StateInspection";
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
                                    list.Add(new StateInspection()
                                    {
                                        sinsId = (sdr["sinsId"] != null) ? int.Parse(sdr["sinsId"].ToString()) : 0,
                                        sinsName = sdr["sinsName"].ToString(),
                                        sinsDescription = sdr["sinsDescription"].ToString(),


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


        public StateInspection DeleteStateInspection(StateInspection model)
        {
            StateInspection newModel = null;
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
                            cmd.CommandText = "deleteStateInspection";
                            cmd.Transaction = sqlTran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("sinsId", model.sinsId);
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
