using P06BibliotekaPolaczenieZBaza;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03SQLInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PolaczenieZBaza pzb = new PolaczenieZBaza();

             string niebezpiecznyCiag = "pol','20200101',90, 180) delete zawodnicy--";
            //string niebezpiecznyCiag = "pol";

            SqlParameter parametr = new SqlParameter();
            parametr.ParameterName = "@parametrKraj";
            parametr.Value = niebezpiecznyCiag; 
            parametr.SqlDbType = System.Data.SqlDbType.VarChar;

            string sqlInjectionInsert =
                string.Format("insert into zawodnicy values ({0},'{1}','{2}',{3},'{4}',{5},{6})",
                0,
                "jan",
                "haker",
                "@parametrKraj",
                "20220101",
                91,
                181
                );

            pzb.WyslijPolecenieSQL(sqlInjectionInsert, parametr);

        }
    }
}
