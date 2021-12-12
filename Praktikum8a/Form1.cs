using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Praktikum8a
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ABD7H3A;Initial Catalog=masak;Integrated Security=True");

        private void resetdata()
        {
            txtid.Text = "";
            txtnama.Text = "";
            txtvoucher.Text = "";
        }

        private void showdata()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM customer ORDER BY idCustomer ASC";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "customer");
            dgvcustomer.DataSource = ds;
            dgvcustomer.DataMember = "customer";
            dgvcustomer.ReadOnly = true;
        }



        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resetdata();
            showdata();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" | txtnama.Text == "" | txtvoucher.Text == "")
            {
                MessageBox.Show("Semua data harus diisi", "Peringatan");
                goto berhenti;
            }

            int num;

            bool isNum = int.TryParse(txtvoucher.Text.ToString(), out num);

            if (!isNum)
            {
                MessageBox.Show("Isi voucher harus angka", "peringatan");
                goto berhenti;
            }

            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO customer values('" + txtid.Text + "','" + txtnama.Text + "'," + int.Parse(txtvoucher.Text) + ")";
            cmd.ExecuteNonQuery();
            con.Close();

            resetdata();

        berhenti:
            ;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if(txtid.Text == "" | txtnama.Text == "" | txtvoucher.Text == "")
            {
                MessageBox.Show("Semua data harus diisi", "Peringaran");
                goto berhenti;
            }

            int num;
            bool isNum = int.TryParse(txtvoucher.Text.ToString(), out num);

            if (!isNum)
            {
                MessageBox.Show("Isi voucher harus angka", "Peringatan");
                goto berhenti;
            }

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE customer SET namaCustomer = '" + txtnama.Text + "', nominalIsi=" + txtvoucher.Text + "WHERE idCustomer = '" + txtid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            resetdata();

        berhenti:
            ;



        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(txtid.Text == "")
            {
                MessageBox.Show("Isi dengan customer yang akan dihapus");
                goto berhenti;
            }

            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM customer WHERE idCustomer = '" + txtid.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            resetdata();

        berhenti:
            ;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM customer WHERE namaCustomer like '%" + txtcarinama.Text + "%'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "customer");
            dgvcustomer.DataSource = ds;
            dgvcustomer.DataMember = "customer";
            dgvcustomer.ReadOnly = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            showdata();

        }
    }
}
