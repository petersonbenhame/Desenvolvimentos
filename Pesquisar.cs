using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace controleMaquinas_1._0
{
    public partial class Pesquisar : Form
    {
        public Pesquisar()
        {
            InitializeComponent();
        }

        private void pesquisarButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conecxao = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ControleEstoque;Data Source=DESKTOP-HNDR4A5\\SQLEXPRESS");

                SqlDataAdapter instrucao = new SqlDataAdapter("select * from tblEstoque where ID like '" + PesquisaTextBox.Text + " %'", conecxao);

                DataTable tabela = new DataTable();

                instrucao.Fill(tabela);

                tabela.Columns[0].ColumnName = "ID";
                tabela.Columns[1].ColumnName = "Tag";
                tabela.Columns[2].ColumnName = "Modelo";

                resultadoDataGridView.DataSource = tabela;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            




        }

        private void Pesquisar_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'controleEstoqueDataSet.tblEstoque'. Você pode movê-la ou removê-la conforme necessário.
            this.tblEstoqueTableAdapter.Fill(this.controleEstoqueDataSet.tblEstoque);

        }
    }
}
