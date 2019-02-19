using ScriptCycle.Prototypes.Data;
using ScriptCycle.Prototypes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ScriptCycle.Prototypes.Repo {

    public class DrugRepo : RepoBase {
        public DrugRepo(ScriptCycleContext ctx) : base(ctx) { }

        public List<DrugSearchResult> FindByGPI(string gpi) {
            var results = new List<DrugSearchResult>();
            var parm1 = new SqlParameter("GPI", gpi);
            results = _ctx.Database.SqlQuery<DrugSearchResult>("FindByGPI @GPI", new SqlParameter[] { parm1 }).ToList();
            return results;
        }

        public List<DrugSearchResult> FindByName(string name) {
            var results = new List<DrugSearchResult>();
            var parm1 = new SqlParameter("Name", name);
            results = _ctx.Database.SqlQuery<DrugSearchResult>("FindByName @Name", new SqlParameter[] { parm1 }).ToList();
            return results;
        }

        public List<string> GetDrugNames() {
            var results = new List<string>();
            results = _ctx.Database.SqlQuery<string>("select distinct drug_name from mf2name_f").ToList();
            return results;
        }

        public List<DrugSearchResult> FindByNDC(string ndc) {
            var results = new List<DrugSearchResult>();
            var parm1 = new SqlParameter("NDC", ndc);
            results = _ctx.Database.SqlQuery<DrugSearchResult>("FindByNDC @NDC", new SqlParameter[] { parm1 }).ToList();
            return results;
        }

        public List<GPIDto> GetPartialGPINames(List<string> partialGPIs) {
            var list = new List<GPIDto>();
            var conn = (SqlConnection)_ctx.Database.Connection;
            try {
                var dataTable = new DataTable();
                dataTable.Columns.Add(new DataColumn("GPI", typeof(string)));
                partialGPIs.ForEach(gpi => {
                    dataTable.Rows.Add(gpi);
                });
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                var cmd = new SqlCommand("GetGPIDisplayNames", conn) {
                    CommandType = CommandType.StoredProcedure
                };

                var parm = new SqlParameter("@List", SqlDbType.Structured) {
                    TypeName = "dbo.GPIList",
                    Value = dataTable
                };
                cmd.Parameters.Add(parm);
                using (var rdr = cmd.ExecuteReader()) {
                    while(rdr.Read()) {
                        var item = new GPIDto {
                            GPI = rdr.GetString(0),
                            DisplayName = rdr.GetString(1)
                        };
                        list.Add(item);
                    }
                }
            }
            catch(Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return list;
        }

    }
}