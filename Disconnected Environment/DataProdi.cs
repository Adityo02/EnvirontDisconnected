using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disconnected_Environment
{
    public partial class DataProdi : Form
    {
        private string stringConnection = "data source=LAPTOP-BULL8R5L\\MSSQLSERVER12;" + "database=activity6;User ID=sa;Password=123";
        private SqlConnection koneksi;
        public DataProdi()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
            //coba


            //coba commit


        }

        private void refreshform()
        {
            textBox1.Text = "";
            textBox1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void dataGridView()
        {
            koneksi.Open();
            string str = "select nama_prodi from dbo.Prodi";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void DataProdi_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormDataProdi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 hu = new Form1();
            hu.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView();
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nmProdi = textBox1.Text;

            if (nmProdi == "")
            {
                MessageBox.Show("Masukan Nama Prodi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "insert into dbo.Prodi (id_prodi,nama_prodi)" + "values(@id_prodi, @nama_prodi)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("nama_prodi", nmProdi));
                cmd.ExecuteNonQuery();

                koneksi.Close();
                MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView();
                refreshform();
            }
        }
    }
}
