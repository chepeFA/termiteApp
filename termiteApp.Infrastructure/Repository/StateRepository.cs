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
   public class StateRepository : IStateRepository
    {
        private readonly IConfiguration _configuration;

        //constructor

        public StateRepository(IConfiguration configuration)
        {
            _configuration = (configuration != null) ? configuration : throw new ArgumentNullException(nameof(configuration));
        }

        public State GetState(State model)
        {
            State newModel = null;
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    string query = "SELECT staId, staName FROM State WHERE staId = @staId ";
                    con.Open();
                    using (SqlTransaction sqlTran = con.BeginTransaction())
                    {
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Transaction = sqlTran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("staId", model.staId);

                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    newModel = new State()
                                    {
                                        staId = (sdr["staId"] != null) ? int.Parse(sdr["staId"].ToString()) : 0,
                                        staName = sdr["staName"].ToString()
                                       
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

        public State InsertState(State model)
        {
            State newModel = null;
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
                            cmd.CommandText = "insertState";
                            cmd.Transaction = sqltran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("staName", model.staName);
                            
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

        public State UpdateState(State model)
        {
            State newModel = null;
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
                            cmd.CommandText = "updateState";
                            cmd.Transaction = sqltran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("staName", model.staName);
                         
                            cmd.Parameters.AddWithValue("staId", model.staId);
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

        public IEnumerable<State> ObtainState()
        {
            List<State> list = new List<State>();
            State model = null;
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {

                    string query = "SELECT staId, staName FROM State";
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
                                    list.Add(new State()
                                    {
                                        staId = (sdr["staId"] != null) ? int.Parse(sdr["staId"].ToString()) : 0,
                                        staName = sdr["staName"].ToString(),
                                       


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


        public State DeleteState(State model)
        {
            State newModel = null;
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
                            cmd.CommandText = "deleteState";
                            cmd.Transaction = sqlTran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("staId", model.staId);
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
