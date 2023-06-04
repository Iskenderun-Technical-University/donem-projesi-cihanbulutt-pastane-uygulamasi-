using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Resources.Extensions;
using System.Security.Cryptography.Pkcs;

namespace Maliyet_Test

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-NO3TP88;Initial Catalog=TESTMALÝYET;Integrated Security=True");

        void MalzemeListe()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From tblmalzemeler", baglanti);
            DataTable dt = new DataTable();

            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }
        void UrunListesi()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from tblurunler", baglanti);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;


        }
        void Kasa()
        {
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from tblkasa", baglanti);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView1.DataSource = dt3;
        }
        void Urunler()
        {
            baglanti.Open();

            SqlDataAdapter da = new SqlDataAdapter("Select * From TblUrunler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbUrun.ValueMember = "URUNID";
            CmbUrun.DisplayMember = "AD";
            CmbUrun.DataSource = dt;


          
            baglanti.Close();
        }
        
        void    Malzemeler()      
            
        {
            baglanti.Open();

            SqlDataAdapter da = new SqlDataAdapter("Select * From tblmalzemeler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbMalzemeler.ValueMember = "MALZEMEID";
            CmbMalzemeler.DisplayMember = "AD";
            CmbMalzemeler.DataSource = dt;

            baglanti.Close();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            MalzemeListe();

            Urunler();

            Malzemeler();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void BtnUrunListesi_Click(object sender, EventArgs e)
        {
            UrunListesi();
        }

        private void BtnMalzemeListesi_Click(object sender, EventArgs e)
        {
            MalzemeListe();
        }

        private void BtnKasa_Click(object sender, EventArgs e)
        {
            Kasa();
        }

        private void BtnMalzemeEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblmalzemeler(ad,stok,fýyat,notlar) values (@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtMalzemeAd.Text);
            komut.Parameters.AddWithValue("@p2", decimal.Parse(TxtMalzemeStok.Text));
            komut.Parameters.AddWithValue("@P3", decimal.Parse(TxtMalzemeFiyat.Text));
            komut.Parameters.AddWithValue("@p4", TxtMalzemeNot.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Malzeme Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MalzemeListe();
        }

        private void BtnUrunEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblurunler (ad) values (@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1",TxtUrunAd.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UrunListesi();

        }

        private void BtnUrunOlustur_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblfýrýn (urunýd,malzemeýd,mýktar,malýyet) values (@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", CmbUrun.SelectedValue);
            komut.Parameters.AddWithValue("@p2", CmbMalzemeler.SelectedValue);
            komut.Parameters.AddWithValue("@p3", decimal.Parse (TxtMýktar.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse (TxtMalýyet.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Malzeme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                


        }

        private void TxtMýktar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}