using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentEnrollmentSystem
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5KJ157N\MATTDATABASEPRO;Initial Catalog=studentdb;User ID=sa;Password=1234qwer");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            // SQL query for SELECT
            string query = "SELECT * FROM student_tab";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e) // Add Button
        {
            con.Open();

            // SQL query for INSERT with parameterized query
            string query = "INSERT INTO student_tab VALUES (@student_id, @student_name, @age, @email, @phone, @course)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@student_id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@student_name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@email", textBox4.Text);
            cmd.Parameters.AddWithValue("@phone", textBox5.Text);
            cmd.Parameters.AddWithValue("@course", textBox6.Text);

            cmd.ExecuteNonQuery();

            con.Close();

            BindData();

            MessageBox.Show("Record Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e) // New Button
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button3_Click(object sender, EventArgs e) // Delete Button
        {
            con.Open();

            // SQL query for DELETE with parameterized query
            string query = "DELETE FROM student_tab WHERE student_id=@student_id";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@student_id", int.Parse(textBox1.Text));

            cmd.ExecuteNonQuery();

            con.Close();

            BindData();

            MessageBox.Show("Record Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
