using System;
using System.Windows.Forms;
using static projectPBO.controller;
using static projectPBO.model;

namespace projectPBO.view
{
    public partial class TambahBuku : Form
    {
        private BookController bookController;
        public TambahBuku()
        {
            InitializeComponent();
            bookController = new BookController();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBookId.Text, out int bookId))
            {
                Book book = new Book
                {
                    bookId = bookId,
                    title = txtTitle.Text,
                    author = txtAuthor.Text,
                    publisher = txtPublisher.Text,
                    yearPublished = dtpYearPublished.Value,
                    status = txtStatus.Text,
                };
                bookController.AddBook(book);
                MessageBox.Show("Book added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBookId.Text = "";
                txtTitle.Text = "";
                txtAuthor.Text = "";
                txtPublisher.Text = "";
                dtpYearPublished.Value = DateTime.Now;
                txtStatus.Text = "";

                DataBook dataBook = new DataBook();
                dataBook.ShowDialog();
                this.Close();
            }

            else
            {
                MessageBox.Show("Please enter a valid Book ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bntDataBuku_Click(object sender, EventArgs e)
        {
            DataBook dataBook = new DataBook();
            dataBook.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormPengguna pengguna = new FormPengguna();
            pengguna.ShowDialog();
            this.Close();
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            Form1 dataLaporan = new Form1();
            dataLaporan.ShowDialog();
            this.Close();
        }
    }
}
