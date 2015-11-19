using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;


namespace CodePathsCSF
{
    public partial class memberjson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

       
           string connectionString = ConfigurationManager.ConnectionStrings["SQLAzureConnection"].ConnectionString;
            string queryString = "SELECT * FROM Member where ID=1 ;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    Response.Write("{\"Records\":[");

                    int x = 0;
                    int MemberID;
                    string patient_name = "";
                    string DOB = "";
                    string Subscriber = "";
                    string Relationship = "";
                    string Fmembers = "";
                    while (reader.Read()) 
                    //Convert.ToInt32(rdr["Id"]);
                    {

                        MemberID = Convert.ToInt32(reader[0]);
                        patient_name = reader[1] + " " + reader[2];
                        //DOB = DateTime.Parse(reader[3].ToString()).ToString("MM/dd/yyyy");
                        DOB = Convert.ToDateTime(reader[3]).ToString("MM/dd/yyyy");
                        Subscriber = reader[4].ToString();
                        Relationship = reader[5].ToString();
                        Fmembers = reader[6].ToString();
                        Response.Write("{");
                        Response.Write(String.Format("\"MemberID\":\"{0}\"", MemberID));
                        Response.Write(",");
                        Response.Write(String.Format("\"patient_name\":\"{0}\"", patient_name));
                        Response.Write(",");
                        Response.Write(String.Format("\"DOB\":\"{0}\"", DOB));
                        Response.Write(",");
                        Response.Write(String.Format("\"Subscriber\":\"{0}\"", Subscriber));
                        Response.Write(",");
                        Response.Write(String.Format("\"Relationship\":\"{0}\"", Relationship));
                        Response.Write(",");
                        Response.Write(String.Format("\"Fmembers\":\"{0}\"", Fmembers));
                        Response.Write("}");
                        Response.Write("]");
                        Response.Write("}");


                        //                        Response.Write(String.Format("{2}{3}{0}{3}:{3}{1}{3}{4}", reader[0], reader[1], "{", "\"", "}"));


                        //format should look like this: ,{“sql01”:”sql02”}

                        //                            Response.Write(String.Format(",{2}{3}{0}{3}:{3}{1}{3}{4}", reader[0], reader[1], "{", "\"", "}"));
                        x = x + 1;


                    }
                }
            
                //format should look like this: ]}   

                //                    Response.Write(String.Format("{0} {1}", "]", "}")); }

                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            }

        }
    }
