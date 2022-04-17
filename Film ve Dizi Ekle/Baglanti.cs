using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Film_ve_Dizi_Ekle
{
    public class Baglanti
    {
        readonly string bsatir = "Server=localhost;Database=medyalar;Uid=root;Pwd=;CharSet=utf8;";

        public DataTable VeriGetir(string sql, List<MySqlParameter> ogeler = null, bool hatagoster = true)
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlConnection con = new MySqlConnection(bsatir);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandTimeout = 99999;
                if (ogeler != null)
                    cmd.Parameters.AddRange(ogeler.ToArray());
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                con.Open();
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                if (hatagoster)
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public int VeriEkleSilGuncelle(string sql, List<MySqlParameter> ogeler = null, bool hatagoster = true)
        {
            int id = -1;
            try
            {
                MySqlConnection con = new MySqlConnection(bsatir);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                if (ogeler != null)
                    cmd.Parameters.AddRange(ogeler.ToArray());
                con.Open();
                cmd.ExecuteNonQuery();
                id = Convert.ToInt32(cmd.LastInsertedId);
                con.Close();
                return id;
            }
            catch (Exception ex)
            {
                if (hatagoster)
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return id;
            }
        }
    }
}