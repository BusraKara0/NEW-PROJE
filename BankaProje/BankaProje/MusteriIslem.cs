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

namespace BankaProje
{
	public partial class MusteriIslem : Form
	{
		public MusteriIslem()
		{
			InitializeComponent();
		}
		SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BMF26BV;Initial Catalog=BankaProje;Integrated Security=True");
		void liste()
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM KARTLARIM", baglanti);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			dataGridView1.DataSource = dataTable;
		}
		private void BtnOdemeler_Click(object sender, EventArgs e)
		{
			Odemeler odemeler = new Odemeler();
			odemeler.Show();
		}

		private void BtnParaGonder_Click(object sender, EventArgs e)
		{
			FrmParaGonder frmParaGonder = new FrmParaGonder();
			frmParaGonder.Show();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			FrmHesapHareketleri frmHesapHareketleri = new FrmHesapHareketleri();
			frmHesapHareketleri.Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			liste();
		}
		private void button3_Click_1(object sender, EventArgs e)
		{
			baglanti.Open();
			SqlCommand komut = new SqlCommand("INSERT INTO KARTLARIM (CALISMADURUMU,MESLEK,EGITIMDUZEYI,AYLIKGELIR) VALUES (@P1,@P2,@P3,@P4)", baglanti);
			komut.Parameters.AddWithValue("@P1", TxtCalısmaDurumu.Text);
			komut.Parameters.AddWithValue("@P2", TxtMeslek.Text);
			komut.Parameters.AddWithValue("@p3", TxtEgitimDuzey.Text);
			komut.Parameters.AddWithValue("@p4", MskAylıkGelir.Text);
			komut.ExecuteNonQuery();
			baglanti.Close();
			MessageBox.Show("Kartınız Başarı ile Eklendi");
		}

		private void button4_Click(object sender, EventArgs e)
		{
			FrmBakiyeBorc frmBakiyeBorc = new FrmBakiyeBorc();
			frmBakiyeBorc.Show();
		}

		private void BtnBasvurular_Click(object sender, EventArgs e)
		{
			FrmBasvurular frmBasvurular = new FrmBasvurular();
			frmBasvurular.Show();
		}

		private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form1 form1 = new Form1();
			form1.Show();
			this.Hide();
		}

		private void MusteriIslem_Load(object sender, EventArgs e)
		{
		}

		private void BtnParaCek_Click(object sender, EventArgs e)
		{
			FrmParaCek frmParaCek = new FrmParaCek();
			frmParaCek.Show();
		}
	}
}
