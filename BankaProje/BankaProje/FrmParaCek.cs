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
	public partial class FrmParaCek : Form
	{
		public FrmParaCek()
		{
			InitializeComponent();
		}
		SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BMF26BV;Initial Catalog=BankaProje;Integrated Security=True");
		private void button1_Click(object sender, EventArgs e)
		{
			float bakiye = FrmBakiyeBorc.bakiye;
			float sayi = float.Parse(maskedTextBox1.Text);
			if (sayi > FrmBakiyeBorc.bakiye)
			{
				MessageBox.Show("Yetersiz Bakiye" , "Para Çekme İşlemi");
			}
		}
	}
}
