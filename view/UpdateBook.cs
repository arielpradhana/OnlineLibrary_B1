using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static projectPBO.controller;
using static projectPBO.model;

namespace projectPBO.view
{
    public partial class UpdateBook : Form
    {
        private int book_Id;
        private BookController bookController;

        public UpdateBook(int bookId, string title, string author, string publisher, DateTime yearPublished)
        {
            InitializeComponent();

            bookController = new BookController();

            this.book_Id = bookId;
            txtTitle.Text = title;
            txtAuthor.Text = author;
            txtPublisher.Text = publisher;
            dtpYearPublished.Value = yearPublished;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string author = txtAuthor.Text;
            string publisher = txtPublisher.Text;
            DateTime yearPublished = dtpYearPublished.Value;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(publisher))
            {
                MessageBox.Show("Input cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Book book = new Book
            {
                bookId = this.book_Id,
                title = title,
                author = author,
                publisher = publisher,
                yearPublished = yearPublished
            };

            bookController.UpdateBook(book);

            MessageBox.Show("Book updated successfully.");
            this.DialogResult = DialogResult.OK;
            this.Close();

            DataBook dataBook = new DataBook();
            dataBook.ShowDialog();
            this.Close();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {

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
