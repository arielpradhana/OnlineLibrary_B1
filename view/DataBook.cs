using projectPBO.view;
using System;
using System.Data;
using System.Windows.Forms;
using static projectPBO.controller;

namespace projectPBO
{
    public partial class DataBook : Form
    {
        private BookController bookController;

        public DataBook()
        {
            InitializeComponent();
            bookController = new BookController();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var books = bookController.GetAllBooks();
                DataTable dt = new DataTable();
                dt.Columns.Add("book_id");
                dt.Columns.Add("title");
                dt.Columns.Add("author");
                dt.Columns.Add("publisher");
                dt.Columns.Add("year_published");
                dt.Columns.Add("status");

                foreach (var book in books)
                {
                    dt.Rows.Add(book.bookId, book.title, book.author, book.publisher, book.yearPublished, book.status);
                }

                dgvBooks.DataSource = dt;

                DataGridViewButtonColumn updateButtonColumn = new DataGridViewButtonColumn();
                updateButtonColumn.Name = "updateButton";
                updateButtonColumn.HeaderText = "Update";
                updateButtonColumn.Text = "Update";
                updateButtonColumn.UseColumnTextForButtonValue = true;

                if (dgvBooks.Columns["updateButton"] == null)
                {
                    dgvBooks.Columns.Add(updateButtonColumn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvBooks.Columns["updateButton"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBooks.Rows[e.RowIndex];
                int bookId = int.Parse(row.Cells["book_id"].Value.ToString());
                string title = row.Cells["title"].Value.ToString();
                string author = row.Cells["author"].Value.ToString();
                string publisher = row.Cells["publisher"].Value.ToString();
                DateTime yearPublished = DateTime.Parse(row.Cells["year_published"].Value.ToString());
                string status = row.Cells["status"].Value.ToString();

                using (UpdateBook updateForm = new UpdateBook(bookId, title, author, publisher, yearPublished))
                {
                    if (updateForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TambahBuku addBook = new TambahBuku();
            addBook.ShowDialog();
            this.Close();
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            Form1 dataLaporan = new Form1();
            dataLaporan.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormPengguna pengguna = new FormPengguna();
            pengguna.ShowDialog();
            this.Close();
        }
    }
}
