namespace MCAT_PCAT_FindApplicants.Reports {
    using LECOM;
    using System;
    using System.Data;
    
    public partial class DataSet1 {
        partial class PcatDataTable
        {
            public void Fill(SqlConnection conn)
            {
                conn.Execute("dbo.LecomMatchingUpdatePcatMatches", SQLTypes.StoredProcedure);

                string commandText = "SELECT * FROM LECOM_MATCHING_PCAT_TABLE ORDER BY [LECOM] DESC";

                AddRows(conn.FetchTable(commandText, SQLTypes.Text));
            }

            private void AddRows(System.Data.DataTable dt)
            {
                this.Clear();
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var row = (PcatRow)(this.NewRow());

                        row["LECOM"] = dr["LECOM"].ToString().NullToEmptyString(true);
                        row["LastName"] = dr["lname"].ToString().NullToEmptyString(true);
                        row["FirstName"] = dr["fname"].ToString().NullToEmptyString(true);
                        row["MI"] = dr["mi"].ToString().NullToEmptyString(true);
                        row["Email"] = dr["email"].ToString().NullToEmptyString(true);
                        row["Address1"] = dr["address1"].ToString().NullToEmptyString(true);
                        row["Address2"] = dr["address2"].ToString().NullToEmptyString(true);
                        row["City"] = dr["city"].ToString().NullToEmptyString(true);
                        row["State"] = dr["state"].ToString().NullToEmptyString(true);
                        row["Zip"] = dr["zip"].ToString().NullToEmptyString(true);
                        row["Country"] = dr["country"].ToString().NullToEmptyString(true);
                       

                        this.Rows.Add(row);
                    }
                }
            }
        }

        partial class McatDataTable
        {
           public void Fill(SqlConnection conn)
            {
                conn.Execute("dbo.LecomMatchingUpdateMcatMatches", SQLTypes.StoredProcedure);

                string commandText = "SELECT * FROM LECOM_MATCHING_MCAT_TABLE ORDER BY [LECOM] DESC";

                AddRows(conn.FetchTable(commandText, SQLTypes.Text));
            }

            private void AddRows(System.Data.DataTable dt)
            {
                this.Clear();
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var row = (McatRow)(this.NewRow());

                        row["LECOM"] = dr["LECOM"].ToString().NullToEmptyString(true);
                        row["legal_state_cd"] = dr["legal_state_cd"].ToString().NullToEmptyString(true);
                        row["aamc_id"] = dr["aamc_id"].ToString().NullToEmptyString(true);
                        row["test_date"] = dr["test_date"].ToString().NullToEmptyString(true);
                        row["Lname"] = dr["lname"].ToString().NullToEmptyString(true);
                        row["Fname"] = dr["fname"].ToString().NullToEmptyString(true);
                        row["mname"] = dr["mname"].ToString().NullToEmptyString(true);
                        row["suffix"] = dr["suffix"].ToString().NullToEmptyString(true);
                        row["address"] = dr["address"].ToString().NullToEmptyString(true);
                        row["City"] = dr["city"].ToString().NullToEmptyString(true);
                        row["State_cd"] = dr["state-cd"].ToString().NullToEmptyString(true);
                        row["postal_cd"] = dr["postal_cd"].ToString().NullToEmptyString(true);
                        row["country"] = dr["country"].ToString().NullToEmptyString(true);
                        row["Email"] = dr["email"].ToString().NullToEmptyString(true);
                        row["sex"] = dr["sex"].ToString().NullToEmptyString(true);
                        row["age_at_test"] = dr["age_at_test"];
                        row["major_cd"] = dr["major_cd"].ToString().NullToEmptyString(true);
                        row["major"] = dr["major"].ToString().NullToEmptyString(true);
                        row["primary_interest_cd"] = dr["primary_interest_cd"].ToString().NullToEmptyString(true);
                        row["primary_interest"] = dr["primary_interest"].ToString().NullToEmptyString(true);
                        row["cpbs_score"] = dr["cpbs_score"];
                        row["cpbs_cb_lower"] = dr["cpbs_cb_lower"];
                        row["cpbs_cb_upper"] = dr["cpbs_cb_upper"];
                        row["cpbs_percentile_rank"] = dr["cpbs_%ile_rank"];
                        row["cars_score"] = dr["cars_score"];
                        row["cars_cb_lower"] = dr["cars_cb_lower"];
                        row["cars_cb_upper"] = dr["cars_cb_upper"];
                        row["cars_percentile_rank"] = dr["cars_%ile_rank"];
                        row["bbfl_score"] = dr["bbfl_score"];
                        row["bbfl_cb_lower"] = dr["bbfl_cb_lower"];
                        row["bbfl_cb_upper"] = dr["bbfl_cb_upper"];
                        row["bbfl_percentile_rank"] = dr["bbfl_%ile_rank"];
                        row["psbb_score"] = dr["psbb_score"];
                        row["psbb_cb_lower"] = dr["psbb_cb_lower"];
                        row["psbb_cb_upper"] = dr["psbb_cb_upper"];
                        row["psbb_percentile_rank"] = dr["psbb_%ile_rank"];
                        row["total_score"] = dr["total_score"];
                        row["total_cb_lower"] = dr["total_cb_lower"];
                        row["total_cb_upper"] = dr["total_cb_upper"];
                        row["total_percentile_rank"] = dr["total_%ile_rank"];

                        this.Rows.Add(row);
                    }
                }
                                
            }

        }         
    }
}
