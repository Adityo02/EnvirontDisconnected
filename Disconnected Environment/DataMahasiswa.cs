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
    public partial class DataMahasiswa : Form
    {
        private string stringConnection = "data source=LAPTOP-BULL8R5L\\MSSQLSERVER12;" + "database=activity6;User ID=sa;Password=123";
        private SqlConnection koneksi;
        private string nim, nama, alamat, jk, prodi;
        private DateTime tgl;

        private void button3_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void refreshform()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            comboBox1.Enabled = false;
            textBox4.Enabled = false;
            dateTimePicker1.Enabled = false;
            comboBox2.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            clearBinding();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            koneksi.Open();
            string StringConnection = "select id_prodi, nama_prodi from dbo.Prodi";
            SqlCommand cmd = new SqlCommand(StringConnection, koneksi);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            koneksi.Close();
            comboBox2.DisplayMember = "nama_prodi";
            comboBox2.ValueMember = "id_prodi";
            comboBox2.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            comboBox1.Enabled = true;
            textBox4.Enabled = true;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker1.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nim = textBox1.Text.Trim();
            nama = textBox2.Text.Trim();
            alamat = textBox4.Text.Trim();
            jk = comboBox1.SelectedItem.ToString();
            prodi = comboBox2.SelectedValue.ToString();
            tgl = dateTimePicker1.Value;
            if (string.IsNullOrEmpty(nim) || string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(alamat) || string.IsNullOrEmpty(jk) || string.IsNullOrEmpty(prodi))
            {
                MessageBox.Show("Please fill in all identity fields!");
            }
            else
            {
                koneksi.Open();
                string str = "INSERT INTO mahasiswa (nim, nama_mahasiswa, alamat, jenis_kelamin, id_prodi, tgl_lahir) VALUES (@nim, @nama_mahasiswa, @alamat, @jenis_kelamin, @id_prodi, @tgl_lahir)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.Parameters.AddWithValue("@nim", nim);
                cmd.Parameters.AddWithValue("@nama_mahasiswa", nama);
                cmd.Parameters.AddWithValue("@jenis_kelamin", jk);
                cmd.Parameters.AddWithValue("@alamat", alamat);
                cmd.Parameters.AddWithValue("@tgl_lahir", tgl);
                cmd.Parameters.AddWithValue("@id_prodi", prodi);
                cmd.ExecuteNonQuery();

                koneksi.Close();

                MessageBox.Show("Data Berhasil Disimpan");
            }
        }

        BindingSource customersBindingSource = new BindingSource();
        public DataMahasiswa()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            customersBindingSource = new BindingSource();
            refreshform();
        }

        private void clearBinding()
        {
            this.textBox1.DataBindings.Clear();
            this.textBox2.DataBindings.Clear();
            this.textBox4.DataBindings.Clear();
            this.comboBox1.DataBindings.Clear();
            this.dateTimePicker1.DataBindings.Clear();
            this.comboBox2.DataBindings.Clear();
        }

        private void FormDataMahasiswa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void DataMahasiswa_Load(object sender, EventArgs e)
        {

        }
    }
}
