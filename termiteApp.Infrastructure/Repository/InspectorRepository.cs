using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using termiteApp.Core.Domain;
using termiteApp.Core.Interfaces;
using termiteApp.Core.AuxClasses;
using Microsoft.Extensions.Configuration;

using System.IO;
using System.Data.SqlTypes;
using System.Text.Json;

namespace termiteApp.Infrastructure.Repository
{
    public class InspectorRepository :IInspectorRepository
    {
        private readonly IConfiguration _configuration;

        //constructor

        public InspectorRepository(IConfiguration configuration)
        {
            _configuration = (configuration != null) ? configuration : throw new ArgumentNullException(nameof(configuration));
        }

        //Search for an inspector in specific
        public Inspector GetInspector(Inspector model)
        {
            Inspector newModel = null;
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    string query = "SELECT inpId, inpName, inpName, inpLastName, inpSex, inpDob, inpLicenseNumber, inpSignature FROM Inspector WHERE inpId = @inpId ";
                    con.Open();
                    using (SqlTransaction sqlTran = con.BeginTransaction())
                    {
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Transaction = sqlTran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("inpId", model.inpId);

                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                while (sdr.Read())
                                {
                                    newModel = new Inspector()
                                    {
                                        inpId = (sdr["inpId"] != null) ? int.Parse(sdr["inpId"].ToString()) : 0,
                                        inpName = sdr["inpName"].ToString(),
                                        inpLastName = sdr["inpName"].ToString(),
                                        inpSex = Convert.ToBoolean(sdr["inpSex"]),//sdr["inpSex"].ToString(),
                                        inpDob = DateTime.Parse(sdr["inpDob"].ToString()),//sdr["inpDob"].ToString(),
                                        inpLicenseNumber = sdr["inpLicenseNumber"].ToString(),
                                        //inpSignature = Encoding.ASCII.GetBytes(sdr["inpSignature"].ToString())
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


        public Inspector InsertInspector(Inspector model)
        {
            Inspector newModel = null;

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
                            cmd.CommandText = "insertInspector";
                            cmd.Transaction = sqltran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("inpName", model.inpName);
                            cmd.Parameters.AddWithValue("inpLastName", model.inpLastName);
                            cmd.Parameters.AddWithValue("inpSex", model.inpSex);
                            cmd.Parameters.AddWithValue("inpDob", model.inpDob);
                            cmd.Parameters.AddWithValue("inpLicenseNumber", model.inpLicenseNumber);
                            cmd.Parameters.AddWithValue("inpSignature", model.inpSignature);
                            // cmd.Parameters.AddWithValue("inpSignature", SqlDbType.VarBinary).Value = (SqlBinary)model.inpSignature;

                            //cmd.Parameters.AddWithValue("inpSignature", JsonSerializer.Serialize(model.inpSignature));
                            //string signature = JsonSerializer.Serialize(model.inpSignature);
                            //   var bytes = System.Text.Encoding.UTF8.GetBytes(signature);
                            // cmd.Parameters.AddWithValue("inpSignature",bytes);
                            //  byte[] bytes = Encoding.ASCII.GetBytes(signature);
                            //foreach(byte b in bytes)
                            //{
                            //  model.inpSignature = b;
                            //}


                            //var b = new Conve();
                            //Utf8JsonWriter writer;
                            //  JsonSerializerOptions o;
                            //  cmd.Parameters.AddWithValue("inpSignature",b.Write(writer, model.inpSignature, o));
                            // cmd.Parameters.AddWithValue("inpSignature", Encoding.ASCII.GetBytes(model.inpSignature.ToString()));
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

        public Inspector UpdateInspector(Inspector model)
        {
            Inspector newModel = null;
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
                            cmd.CommandText = "updateInspector";
                            cmd.Transaction = sqltran;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("inpName", model.inpName);
                            cmd.Parameters.AddWithValue("inpLastName", model.inpLastName);
                            cmd.Parameters.AddWithValue("inpSex", model.inpSex);
                            cmd.Parameters.AddWithValue("inpDob", model.inpDob);
                            cmd.Parameters.AddWithValue("inpLicenseNumber", model.inpLicenseNumber);
                         //   cmd.Parameters.AddWithValue("inpSignature", model.inpSignature);
                            cmd.Parameters.AddWithValue("inpId", model.inpId);
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

        public IEnumerable<Inspector> ObtainInspector()
        {
            List<Inspector> list = new List<Inspector>();
            Inspector model = null;
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {

                    string query = "SELECT inpId, inpName, inpLastName, inpSex, inpDob, inpLicenseNumber, inpSignature FROM Inspector";
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
                                    list.Add(new Inspector()
                                    {
                                        inpId = (sdr["inpId"] != null) ? int.Parse(sdr["inpId"].ToString()) : 0,
                                        inpName = sdr["inpName"].ToString(),
                                        inpLastName = sdr["inpName"].ToString(),
                                        inpSex = Convert.ToBoolean(sdr["inpSex"]),//sdr["inpSex"].ToString(),
                                        inpDob = DateTime.Parse(sdr["inpDob"].ToString()),//sdr["inpDob"].ToString(),
                                        inpLicenseNumber = sdr["inpLicenseNumber"].ToString(),
                                        //inpSignature = Encoding.ASCII.GetBytes(sdr["inpSignature"].ToString())


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




    }
}
