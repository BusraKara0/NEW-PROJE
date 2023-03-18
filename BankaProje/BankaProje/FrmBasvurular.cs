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
	public partial class FrmBasvurular : Form
	{
		public FrmBasvurular()
		{
			InitializeComponent();
		}
		SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BMF26BV;Initial Catalog=BankaProje;Integrated Security=True");
		void liste()
		{
			{
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM BASVURULAR", baglanti);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				dataGridView1.DataSource = dataTable;
			}
		}
		private void BtnListele_Click(object sender, EventArgs e)
		{
			liste();
		}

		private void BtnEkle_Click(object sender, EventArgs e)
		{
			baglanti.Open();
			SqlCommand komut = new SqlCommand("INSERT INTO BASVURULAR (ADI,SOYADI,CALISMADURUMU,MESLEK,TC) VALUES (@P1,@P2,@P3,@P4,@P5)", baglanti);
			komut.Parameters.AddWithValue("@P1", TxtAd.Text);
			komut.Parameters.AddWithValue("@P2", TxtSoyad.Text);
			komut.Parameters.AddWithValue("@P3", TxtCalismaDurumu.Text);
			komut.Parameters.AddWithValue("@P4", TxtMeslek.Text);
			komut.Parameters.AddWithValue("@P5", MskTC.Text);
			komut.ExecuteNonQuery();
			baglanti.Close();
			MessageBox.Show("Başvurunuz Eklenmiştir.");
		}

		private void BtnGuncelle_Click(object sender, EventArgs e)
		{
			baglanti.Open();
			SqlCommand komut1 = new SqlCommand("UPDATE BASVURULAR SET ADI=@P1,SOYADI=@P2,CALISMADURUMU=@P3,MESLEK=@P4,TC=@P5 WHERE ID=@P6", baglanti);
			komut1.Parameters.AddWithValue("@P1", TxtAd.Text);
			komut1.Parameters.AddWithValue("@P2", TxtSoyad.Text);
			komut1.Parameters.AddWithValue("@P3", TxtCalismaDurumu.Text);
			komut1.Parameters.AddWithValue("@P4", TxtMeslek.Text);
			komut1.Parameters.AddWithValue("@P5", MskTC.Text);
			komut1.Parameters.AddWithValue("@P6", TxtId.Text);
			komut1.ExecuteNonQuery();
			baglanti.Close();
			MessageBox.Show("Başvurunuz Güncellenmiştir");
		}
		
		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
				int secilensatir = dataGridView1.SelectedCells[0].RowIndex;
				TxtId.Text = dataGridView1.Rows[secilensatir].Cells[0].Value.ToString();
				TxtAd.Text = dataGridView1.Rows[secilensatir].Cells[1].Value.ToString();
				TxtSoyad.Text = dataGridView1.Rows[secilensatir].Cells[2].Value.ToString();
				TxtCalismaDurumu.Text = dataGridView1.Rows[secilensatir].Cells[3].Value.ToString();
				TxtMeslek.Text = dataGridView1.Rows[secilensatir].Cells[4].Value.ToString();
				MskTC.Text = dataGridView1.Rows[secilensatir].Cells[5].Value.ToString();
		}

		private void BtnSil_Click(object sender, EventArgs e)
		{
			baglanti.Open();
			SqlCommand komut2 = new SqlCommand("DELETE FROM BASVURULAR WHERE ID=@P1", baglanti);
			komut2.Parameters.AddWithValue("@P1", TxtId.Text);
			komut2.ExecuteNonQuery();
			baglanti.Close();
			MessageBox.Show("Başvurunuz Silinmiştir");
		}
	}
}
