using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STOK_TAKİP_SON_HALİ
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
          
            string kitapAdi = textBox1.Text;
            string yazar = textBox2.Text;
            string isbn = textBox3.Text;
            string yayinevi = textBox4.Text;
            string yayinYili = textBox5.Text;
            string dili = textBox6.Text;
            string fiyat = textBox7.Text;
            string rafKodu = textBox8.Text;
            string kitapSayisi = textBox9.Text;

            string connectionString = "Data Source=MERMUTLU\\SQLEXPRESS;Initial Catalog=stokk;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

           
            string query = "INSERT INTO [Table] (KitapAdi, YazarAdi, ISBN, Yayinevi, YayinYili, Dili, Fiyat, RafKodu, KitapSayisi) " +
                           "VALUES (@KitapAdi, @YazarAdi, @ISBN, @Yayinevi, @YayinYili, @Dili, @Fiyat, @RafKodu, @KitapSayisi)";

          
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

               
                cmd.Parameters.AddWithValue("@KitapAdi", kitapAdi);
                cmd.Parameters.AddWithValue("@YazarAdi", yazar);
                cmd.Parameters.AddWithValue("@ISBN", isbn);
                cmd.Parameters.AddWithValue("@Yayinevi", yayinevi);
                cmd.Parameters.AddWithValue("@YayinYili", yayinYili);
                cmd.Parameters.AddWithValue("@Dili", dili);
                cmd.Parameters.AddWithValue("@Fiyat", fiyat);
                cmd.Parameters.AddWithValue("@RafKodu", rafKodu);
                cmd.Parameters.AddWithValue("@KitapSayisi", kitapSayisi);

               
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            dataGridView1.Rows.Clear();
            string selectQuery = "SELECT * FROM [Table]";
            

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(selectQuery, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    
                    dataGridView1.Rows.Add(
                        reader["KitapAdi"].ToString(),
                        reader["YazarAdi"].ToString(),
                        reader["ISBN"].ToString(),
                        reader["Yayinevi"].ToString(),
                        reader["YayinYili"].ToString(),
                        reader["Dili"].ToString(),
                        reader["Fiyat"].ToString(),
                        reader["RafKodu"].ToString(),
                        reader["KitapSayisi"].ToString()
                    );
                }
            }

            
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

       
    }
}
    






    


