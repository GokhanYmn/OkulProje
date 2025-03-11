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

namespace OkulProje
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }
        
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-3HV2966;Initial Catalog=Okul;Integrated Security=True;TrustServerCertificate=True;");
        public string numara;
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("SELECT \r\n    TBLDERSLER.DERSAD, \r\n    TBLNOTLAR.SINAV1, \r\n    TBLNOTLAR.SINAV2, \r\n    TBLNOTLAR.SINAV3, \r\n    TBLNOTLAR.PROJE, \r\n    TBLNOTLAR.ORTALAMA, \r\n    TBLNOTLAR.DURUM \r\nFROM \r\n    TBLNOTLAR\r\nINNER JOIN \r\n    TBLDERSLER ON TBLNOTLAR.DERSID = TBLDERSLER.DERSID\r\nWHERE \r\n    TBLNOTLAR.OGRID = 1;", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
           SqlDataAdapter da =new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
