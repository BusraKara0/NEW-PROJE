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
	public partial class FrmBakiyeBorc : Form
	{
		public FrmBakiyeBorc()
		{
			InitializeComponent();
		}
		SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BMF26BV;Initial Catalog=BankaProje;Integrated Security=True");
		private void FrmBakiyeBorc_Load(object sender, EventArgs e)
		{
			
		}
		public static float bakiye;
		private void BtnAra_Click(object sender, EventArgs e)
		{
			baglanti.Open();
			SqlCommand komut = new SqlCommand("SELECT KULLANICIAD,KULLANICISOYAD,BAKIYE,BORC FROM HESAPLAR WHERE ID=@P1", baglanti);
			komut.Parameters.AddWithValue("@p1", TxtID.Text);
			SqlDataReader sqlDataReader = komut.ExecuteReader();
			if (sqlDataReader.Read())
			{
				LblBakiye.Text = sqlDataReader["BAKIYE"].ToString();
				LblBorc.Text = sqlDataReader["BORC"].ToString();
				TxtAd.Text = sqlDataReader["KULLANICIAD"].ToString();
				TxtSoyad.Text = sqlDataReader["KULLANICISOYAD"].ToString();
			}
			else
			{
				MessageBox.Show(TxtID.Text + " " + "ID'li Kayıt Bulunamadı.");
			}
			baglanti.Close(); 
		}
	}
}
