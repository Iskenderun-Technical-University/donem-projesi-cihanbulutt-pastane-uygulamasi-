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

        private void Form1_Load(object sender, EventArgs e)
        {
            MalzemeListe();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}