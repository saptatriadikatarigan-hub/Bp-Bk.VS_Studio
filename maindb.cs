using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace BasisData01
{
    class db
    {
        public static MySqlConnection koneksi = new MySqlConnection
        ("server=127.0.0.1; username=root; password=; database=db_bp_bk");
        public static DataSet ds = new DataSet();
        public static MySqlDataAdapter da;
        public static MySqlCommand perintah;

        public static void crud(string kuery)
        {
            Console.WriteLine(kuery);
            ds.Tables.Clear();
            perintah = new MySqlCommand(kuery, koneksi);
            da = new MySqlDataAdapter(perintah);
            da.Fill(ds);
        }
    }
}
