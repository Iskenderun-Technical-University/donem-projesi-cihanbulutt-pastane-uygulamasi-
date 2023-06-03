using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            MalzemeListe();
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
    }
}