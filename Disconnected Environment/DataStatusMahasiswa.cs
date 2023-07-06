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
    public partial class DataStatusMahasiswa : Form
    {
        private string stringConnection = "data source=LAPTOP-BULL8R5L\\MSSQLSERVER12;" + "database=activity6;User ID=sa;Password=123";
        private SqlConnection koneksi;
        public DataStatusMahasiswa()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void refreshform()
        {
            comboBox1.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox1.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            label5.Visible = false;
            button4.Enabled = false;
            button3.Enabled = false;
            button2.Enabled = true;
        }

        private void dataGridView()
        {
            koneksi.Open();
            string str = "select * from dbo.status_mahasiswa";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[8];
            koneksi.Close();
        }

        private void DataStatusMahasiswa_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            koneksi.Open();
            string str = "select nama_mahasiswa from dbo.Mahasiswa where " +
                "not EXISTS(select id_status from dbo.status_mahasiswa where " +
                "status_mahasiswa.nim = mahasiswa.nim";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteReader();
            koneksi.Close();

            comboBox1.DisplayMember = "nama_mahasiswa";
            comboBox1.ValueMember = "NIM";
            comboBox1.DataSource = ds.Tables[0];
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int y = DateTime.Now.Year - 2010;
            string[] type = new string[y];
            int i = 0;
            for (i = 0; i < type.Length; i++)
            {

                if (1 == 0)
                {
                    comboBox4.Items.Add("2010");
                }
                else
                {

                    int l = 2010 + i;
                    comboBox4.Items.Add(1.ToString());
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView();
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox4.Enabled = true;
            comboBox1.Enabled = true;
            comboBox3.Enabled = true;
            label5.Visible = true;
            comboBox4.Enabled = true;
            comboBox1.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button2.Enabled = false;
        }
    }
}
