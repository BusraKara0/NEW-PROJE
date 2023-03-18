using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BankaProje
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BMF26BV;Initial Catalog=BankaProje;Integrated Security=True");
		public static string adsoyad = " ";
		private void BtnGiris_Click(object sender, EventArgs e)
		{
			baglanti.Open();
			SqlCommand komut = new SqlCommand("SELECT * FROM BANKAGİRİS WHERE KULLANICIADSOYAD=@P1 AND SIFRE=@P2", baglanti);
			komut.Parameters.AddWithValue("@P1", TxtAdSoyad.Text);
			komut.Parameters.AddWithValue("@P2", TxtSifre.Text);
			SqlDataReader sqlDataReader = komut.ExecuteReader();
			if (sqlDataReader.Read())
			{
				MusteriIslem MusteriIslem = new MusteriIslem();
				MusteriIslem.Show();
				this.Hide();
			}
			else
			{
				MessageBox.Show("Hatalı Kullanıcı & Şifre");
			}
			baglanti.Close();
		}
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			FrmSifremiUnuttum frmSifremiUnuttum = new FrmSifremiUnuttum();
			frmSifremiUnuttum.Show();
		}
	}
}
