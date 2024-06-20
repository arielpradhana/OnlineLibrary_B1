using System;
using System.Windows.Forms;
using Npgsql;

namespace projectPBO
{
    public partial class FormCreatePeminjaman : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=110601;Database=UAS_PBO;";

        public FormCreatePeminjaman()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int checkoutId = int.Parse(txtCheckoutId.Text);
            int memberId = int.Parse(txtMemberId.Text);
            int bookId = int.Parse(txtBookId.Text);
            DateTime checkoutDate = dtpCheckoutDate.Value;
            DateTime dueDate = dtpDueDate.Value;
            DateTime returnDate = dtpReturnDate.Value;

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "INSERT INTO peminjaman (checkout_id, member_id, book_id, checkout_date, due_date, return_date) VALUES (@checkout_id, @member_id, @book_id, @checkout_date, @due_date, @return_date)";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@checkout_id", checkoutId);
                command.Parameters.AddWithValue("@member_id", memberId);
                command.Parameters.AddWithValue("@book_id", bookId);
                command.Parameters.AddWithValue("@checkout_date", checkoutDate);
                command.Parameters.AddWithValue("@due_date", dueDate);
                command.Parameters.AddWithValue("@return_date", returnDate);

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Peminjaman created successfully.");
                    this.Close(); // Close the form after successful creation
                }
                else
                {
                    MessageBox.Show("Error creating peminjaman.");
                }
            }
        }

        private void txtCheckoutId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
