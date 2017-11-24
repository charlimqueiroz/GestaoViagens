using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Viajante.Negocio.Fabrica;
using Viajante.Transporte.Cadastros;
using Viajante.Transporte.IControles;

namespace Viajante.Interface.Telas
{
    public partial class FCadastroVeiculo : Form
    {
        private ICVeiculo cVeiculo = FabricaDeControles<ICVeiculo>.Instancia;
        private DataTable dataTableVeiculos = new DataTable();
        private TVeiculo tVeiculo = new TVeiculo();

        public FCadastroVeiculo()
        {
            InitializeComponent();

            Inicializar();

        }

        private void Inicializar()
        {
            CriarDataTable();
            CarregarGrid();
            LimparTela();
        }

        private void CriarDataTable()
        {
            dataTableVeiculos.Columns.Add("Id", typeof(long));
            dataTableVeiculos.Columns.Add("Placa", typeof(string));
            dataTableVeiculos.Columns.Add("Chassi", typeof(string));
            dataTableVeiculos.Columns.Add("Marca", typeof(string));
            dataTableVeiculos.Columns.Add("Modelo", typeof(string));
            dataTableVeiculos.Columns.Add("AnoModelo", typeof(int));
            dataTableVeiculos.Columns.Add("AnoFabricacao", typeof(int));

            dgvVeiculos.DataSource = dataTableVeiculos;
        }

        private void CarregarGrid()
        {
            dataTableVeiculos.Clear();
            IList<TVeiculo> tVeiculos = cVeiculo.BuscarTosdos();

            Parallel.ForEach(tVeiculos, veiculo =>
            {
                dataTableVeiculos.Rows.Add(new object[] { veiculo.Id, veiculo.Placa, veiculo.Chassi, veiculo.Marca, veiculo.Modelo, veiculo.AnoModelo, veiculo.AnoFabricacao });
            });
        }

        private void toolStripButton1_Click(object sender, System.EventArgs e)
        {
            TelaParaTransporte();
            cVeiculo.Salvar(tVeiculo);
            LimparTela();
            CarregarGrid();
        }

        private void LimparTela()
        {
            tbPlaca.Clear();
            tbChassi.Clear();
            tbMarca.Clear();
            tbModelo.Clear();
            nudAnoModelo.Value = DateTime.Now.Year;
            nudAnoFabricacao.Value = DateTime.Now.Year;
        }

        private TVeiculo TelaParaTransporte()
        {
            tVeiculo.Id = 0;
            tVeiculo.Placa = tbPlaca.Text;
            tVeiculo.Chassi = tbChassi.Text;
            tVeiculo.Marca = tbMarca.Text;
            tVeiculo.Modelo = tbModelo.Text;
            tVeiculo.AnoModelo = (int)nudAnoModelo.Value;
            tVeiculo.AnoFabricacao = (int)nudAnoFabricacao.Value;

            return tVeiculo;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dgvVeiculos.CurrentRow != null)
            {
                DataRowCollection rows = dataTableVeiculos.Rows;

                var dtRow = rows[dgvVeiculos.CurrentRow.Index];
                long id = (long)dtRow["Id"];

                if (id != 0)
                    cVeiculo.Excluir(id);

                dataTableVeiculos.Rows.Remove(dtRow);
            }
        }

        private void GridToTela()
        {
            if (dgvVeiculos.CurrentRow != null)
            {
                DataRowCollection rows = dataTableVeiculos.Rows;

                var dtRow = rows[dgvVeiculos.CurrentRow.Index];
                long id = (long)dtRow["Id"];
                tbPlaca.Text = dtRow["Placa"].ToString();
                tbChassi.Text = dtRow["Chassi"].ToString();
                tbMarca.Text = dtRow["Marca"].ToString();
                tbModelo.Text = dtRow["Modelo"].ToString();
                nudAnoModelo.Value = (int)dtRow["AnoModelo"];
                nudAnoFabricacao.Value = (int)dtRow["AnoModelo"];
            }
        }

        private void dgvVeiculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GridToTela();
        }
    }
}
