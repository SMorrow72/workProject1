namespace MCAT_PCAT_FindApplicants.Reports {
    using LECOM;
    using System;
    using System.Data;
    
    public partial class DataSet1 {

        partial class McatPcatDataTable
        {
            public void Fill(SqlConnection conn)
            {
                conn.Execute("dbo.LecomUpdateMcatPcatMatches", SQLTypes.StoredProcedure);

                string commandText = "SELECT * FROM LECOM_MCAT_PCAT_TABLE ORDER BY [LECOM] DESC";

                AddRows(conn.FetchTable(commandText, SQLTypes.Text));
            }

            private void AddRows(System.Data.DataTable dt)
            {
                this.Clear();
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var row = (McatPcatRow)(this.NewRow());

                        row["LECOM"] = dr["LECOM"].ToString().NullToEmptyString(true);
                        row["aamc_id"] = dr["aamc_id"].ToString().NullToEmptyString(true);
                        row["Lname"] = dr["lname"].ToString().NullToEmptyString(true);
                        row["Fname"] = dr["fname"].ToString().NullToEmptyString(true);
                        row["City"] = dr["city"].ToString().NullToEmptyString(true);
                        row["State_cd"] = dr["state-cd"].ToString().NullToEmptyString(true);
                        row["Email"] = dr["email"].ToString().NullToEmptyString(true);

                        this.Rows.Add(row);
                    }
                }
                                
            }

        }         
    }
}
