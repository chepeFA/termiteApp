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
    public class CostumerRepository :ICostumerRepository
    {
        private readonly IConfiguration _configuration;

        public CostumerRepository(IConfiguration configuration)
        {
            _configuration = (configuration != null) ? configuration : throw new ArgumentNullException(nameof(configuration));
        }

        public Costumer GetCostumer(Costumer model)
        {
            Costumer newModel = null;
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    string query = "SELECT ctmId, cmtName, cmtLastName, cmtEmail, cmtPhoneNumber, cmtAgencyRealtor FROM Custumer WHERE ctmId = @ctmId ";
                    con.Open();
                    using (SqlTransaction sqlTran = con.BeginTransaction())
                    {
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Transaction = sqlTran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("ctmId", model.ctmId);

                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    newModel = new Costumer()
                                    {
                                        ctmId = (sdr["ctmId"] != null) ? int.Parse(sdr["ctmId"].ToString()) : 0,
                                        ctmName = sdr["cmtName"].ToString(),
                                        ctmLastName = sdr["cmtLastName"].ToString(),
                                        ctmEmail = sdr["cmtName"].ToString(),
                                        ctmPhoneNumber = sdr["cmtPhoneNumber"].ToString(),
                                        ctmAgency = sdr["cmtAgencyRealtor"].ToString()
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


        public Costumer InsertCostumer(Costumer model)
        {
            Costumer newModel = null;
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
                            cmd.CommandText = "insertCustomer";
                            cmd.Transaction = sqltran;
                            cmd.Connection = con; //parameter has to be exact as the parameters in the database
                            cmd.Parameters.AddWithValue("ctmName", model.ctmName);
                            cmd.Parameters.AddWithValue("ctmLastName", model.ctmLastName);
                            cmd.Parameters.AddWithValue("ctmEmail", model.ctmEmail);
                            cmd.Parameters.AddWithValue("ctmPhoneNumber", model.ctmPhoneNumber);
                            cmd.Parameters.AddWithValue("ctmAgencyRealtor", model.ctmAgency);
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

        public Costumer UpdateCostumer(Costumer model)
        {
            Costumer newModel = null;
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
                            cmd.CommandText = "updateCustomer";
                            cmd.Transaction = sqltran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("cmtName", model.ctmName);
                            cmd.Parameters.AddWithValue("cmtLastName", model.ctmLastName);
                            cmd.Parameters.AddWithValue("cmtEmail", model.ctmEmail);
                            cmd.Parameters.AddWithValue("cmtPhoneNumber", model.ctmPhoneNumber);
                            cmd.Parameters.AddWithValue("cmtAgencyRealtor", model.ctmAgency);
                            cmd.Parameters.AddWithValue("ctmId", model.ctmId);
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

        public IEnumerable<Costumer> ObtainCostumer()
        {
            List<Costumer> list = new List<Costumer>();
            Costumer model = null;
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {

                    string query = "SELECT ctmId, cmtName, cmtLastName, cmtEmail, cmtPhoneNumber, cmtAgencyRealtor FROM Custumer";
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
                                    list.Add(new Costumer()
                                    {
                                        ctmId = (sdr["ctmId"] != null) ? int.Parse(sdr["ctmId"].ToString()) : 0,
                                        ctmName = sdr["cmtName"].ToString(),
                                        ctmLastName = sdr["cmtLastName"].ToString(),
                                        ctmEmail = sdr["cmtEmail"].ToString(),
                                        ctmPhoneNumber = sdr["cmtPhoneNumber"].ToString(),
                                        ctmAgency = sdr["cmtAgencyRealtor"].ToString(),

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

        /*
        public Costumer DeleteCostumer(Costumer model)
        {
            Costumer newModel = null;
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
                            cmd.CommandText = "deleteCostumer";
                            cmd.Transaction = sqlTran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("ctmId", model.ctmId);
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

        */

    }
}
