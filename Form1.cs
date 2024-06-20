using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using projectPBO.view;

namespace projectPBO
{
    public partial class Form1 : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=110601;Database=UAS_PBO;";

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }
        private void InitializeCustomComponents()
        {
            Button btnCreatePeminjaman = new Button();
            btnCreatePeminjaman.Text = "Create Peminjaman";
            btnCreatePeminjaman.Location = new Point(10, 10);
            btnCreatePeminjaman.Click += btnCreatePeminjaman_Click;
            this.Controls.Add(btnCreatePeminjaman);
        }
        private void ReadPeminjaman()
        {
            List<Peminjaman> peminjaman = new List<Peminjaman>();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = @"
                SELECT p.checkout_id, p.member_id, p.book_id, p.checkout_date, p.due_date, p.return_date, b.title, b.status
                FROM peminjaman p
                JOIN buku b ON p.book_id = b.book_id
                WHERE p.return_date < @today";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@today", DateTime.Now);

                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    peminjaman.Add(new Peminjaman
                    {
                        CheckoutId = reader.GetInt32(0),
                        MemberId = reader.GetInt32(1),
                        BookId = reader.GetInt32(2),
                        CheckoutDate = reader.GetDateTime(3),
                        DueDate = reader.GetDateTime(4),
                        ReturnDate = reader.GetDateTime(5),
                        BookTitle = reader.GetString(6), // Read the book title
                        BookStatus = reader.GetString(7)
                    });
                }
            }

            dataGridView1.DataSource = peminjaman;

            // Add update button
            if (dataGridView1.Columns["Update"] == null)
            {
                DataGridViewButtonColumn updateButtonColumn = new DataGridViewButtonColumn();
                updateButtonColumn.Name = "Update";
                updateButtonColumn.HeaderText = "Update";
                updateButtonColumn.Text = "Update";
                updateButtonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(updateButtonColumn);
            }

            // Add delete button
            if (dataGridView1.Columns["Delete"] == null)
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.Name = "Delete";
                deleteButtonColumn.HeaderText = "Delete";
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(deleteButtonColumn);
            }
        }
        private void UpdatePeminjaman(int checkoutId, string newStatus)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = @"
                UPDATE buku
                SET status = @newStatus
                FROM peminjaman
                WHERE peminjaman.book_id = buku.book_id
                AND peminjaman.checkout_id = @checkout_id"; ;
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@newStatus", newStatus);
                command.Parameters.AddWithValue("@checkout_id", checkoutId);

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                    MessageBox.Show("Peminjamman updated successfully.");
                else
                    MessageBox.Show("Error updating Peminjaman.");
            }
        }

        private void DeletePeminjaman(int checkoutId)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "DELETE FROM peminjaman WHERE checkout_id = @checkout_id";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@checkout_id", checkoutId);


                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                    MessageBox.Show("Peminjaman deleted successfully.");
                else
                    MessageBox.Show("Error deleting peminjaman.");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadPeminjaman();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            Form1 dataLaporan = new Form1();
            dataLaporan.ShowDialog();
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void bntDataBuku_Click(object sender, EventArgs e)
        {
            DataBook dataBook = new DataBook();
            dataBook.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Update"].Index && e.RowIndex >= 0)
            {
                // Handle Update button click
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int checkoutId = Convert.ToInt32(row.Cells["CheckoutId"].Value);
                string currentStatus = row.Cells["BookStatus"].Value.ToString().Trim();
                string newStatus = currentStatus == "Tersedia" ? "Returned" : "Tersedia"; // Set the new status you want to update
                UpdatePeminjaman(checkoutId, newStatus);
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                // Handle Delete button click
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int checkoutId = Convert.ToInt32(row.Cells["CheckoutId"].Value);
                DeletePeminjaman(checkoutId);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            {
                ReadPeminjaman();
            }
        }

        private void btnCreatePeminjaman_Click(object sender, EventArgs e)
        {
            FormCreatePeminjaman formCreatePeminjaman = new FormCreatePeminjaman();
            formCreatePeminjaman.FormClosed += (s, args) => ReadPeminjaman(); // Refresh data when the form is closed
            formCreatePeminjaman.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormPengguna pengguna = new FormPengguna();
            pengguna.ShowDialog();
            this.Close();
        }
    }
    public class Peminjaman
    {
        public int CheckoutId { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string BookTitle { get; set; } // New property for book title
        public string BookStatus { get; set; }
    }
}
