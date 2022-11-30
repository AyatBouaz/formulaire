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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace fotmul
{
    public partial class Form1 : Form
    {
        static string chaine = @"Data Source=DESKTOP-OFLO969\SQLEXPRESS;Initial Catalog=biblio;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\App_Data\VotreBD.mdf;Integrated Security=True;User Instance=True"
        //"Server=.\SQLEXPRESS; DataBase=VotreBD;USER ID=sa; PASSWORD="
        static SqlConnection cnx = new SqlConnection(chaine);
        static SqlCommand cmd = new SqlCommand();
        static SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            annuler.Enabled = false;
            afficher.Enabled = false;
            modifier.Enabled = false;
            ajouter.Enabled = true;
            supprimer.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ajouter_Click(object sender, EventArgs e)
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "insert into aya values('" + textBox1.Text + "','" + textBox2.Text + "') ";
            cmd.ExecuteNonQuery();
            cnx.Close();
            textBox1.Clear();
            textBox2.Clear();

            annuler.Enabled = true;
            afficher.Enabled = true;
            modifier.Enabled = true;
            ajouter.Enabled = true;
            supprimer.Enabled = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void afficher_Click(object sender, EventArgs e)
        {
            cnx.Open();
            cmd.CommandText = "select * from aya ";
            cmd.Connection = cnx;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            cnx.Close();
        }

        private void modifier_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "update aya set nom ='" + textBox1.Text + "' where prenom='" + textBox2.Text + "' ";
            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        private void annuler_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

            annuler.Enabled = false;
            modifier.Enabled = false;
            ajouter.Enabled = true;
            supprimer.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }

        private void supprimer_Click(object sender, EventArgs e)
        {
            string box_msg = "confirmer la suppression";

            string box_title = "confiramtion";



            if (MessageBox.Show(box_msg, box_title, MessageBoxButtons.YesNo) == DialogResult.Yes)

            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }

                cnx.Open();
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                cnx.Open();
                cmd.Connection = cnx;
                cmd.CommandText = "delete from aya where nom='" + textBox1.Text + "' ";
                cmd.ExecuteNonQuery();
                cnx.Close();
                textBox1.Clear();
                textBox2.Clear();
            }


    }
}
}

