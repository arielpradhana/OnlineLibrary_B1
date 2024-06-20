using System;
using System.Windows.Forms;
using static projectPBO.model;

namespace projectPBO.view
{
    public partial class FormPengguna : Form
    {
        private PenggunaRepository penggunaRepository;

        public FormPengguna()
        {
            InitializeComponent();
            penggunaRepository = new PenggunaRepository();
        }

        private void FormPengguna_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var penggunaList = penggunaRepository.GetAllPengguna();
            dgvPengguna.DataSource = penggunaList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTambahPengguna tambahPengguna = new FormTambahPengguna();
            tambahPengguna.ShowDialog();
            this.Close();
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

        }
    }
}
