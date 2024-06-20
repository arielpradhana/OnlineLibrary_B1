using System;
using System.Windows.Forms;
using System.Xml.Linq;
using static projectPBO.model;


namespace projectPBO.view
{
    public partial class FormTambahPengguna : Form
    {
        private PenggunaRepository penggunaRepository;

        public FormTambahPengguna()
        {
            InitializeComponent();
            penggunaRepository = new PenggunaRepository();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMemberId.Text) || string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.TryParse(txtMemberId.Text, out int MemberId))
            {
                Pengguna pengguna = new Pengguna
                {
                    MemberId = MemberId,
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text
                };
                penggunaRepository.AddPengguna(pengguna);
                MessageBox.Show("Pengguna added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMemberId.Text = "";
                txtName.Text = "";
                txtAddress.Text = "";
                txtPhone.Text = "";

                DataBook dataBook = new DataBook();
                dataBook.ShowDialog();
                this.Close();
            }

            else
            {
                MessageBox.Show("Please enter a valid Book ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
           

        private void FormTambahPengguna_Load(object sender, EventArgs e)
        {

        }

        private void bntDataBuku_Click(object sender, EventArgs e)
        {
            DataBook dataBook = new DataBook();
            dataBook.ShowDialog();
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
