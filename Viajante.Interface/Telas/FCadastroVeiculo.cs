using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Viajante.Negocio.Fabrica;
using Viajante.Transporte.Cadastros;
using Viajante.Transporte.IControles;

namespace Viajante.Interface.Telas
{
    public partial class FCadastroVeiculo : Form
    {
        #region Propriedades
        private ICVeiculo cVeiculo = FabricaDeControles<ICVeiculo>.Instancia;
        private DataTable dataTableVeiculos = new DataTable();
        private TVeiculo tVeiculo = new TVeiculo();

        #endregion

        #region Construtor/Inicialização
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

        #endregion

        #region Métodos de Controle
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
                nudAnoFabricacao.Value = (int)dtRow["AnoFabricacao"];
            }
        }

        private void dgvVeiculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GridToTela();
        }

        #endregion

        #region Métodos da Interface
        private void toolStripButton1_Click(object sender, System.EventArgs e)
        {
            if (tbPlaca.Text.Count() != 7)
            {
                MessageBox.Show("A placa do veículo deve possuir 7 caracteres.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tbPlaca.Text.Count() != 17)
            {
                MessageBox.Show("O chassi do veículo deve possuir 17 caracteres.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tbMarca.Text.Count() == 0)
            {
                MessageBox.Show("A Marca do veículo deve ser informada.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tbModelo.Text.Count() == 0)
            {
                MessageBox.Show("O Modelo do veículo deve ser informado.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nudAnoModelo.Value == 0)
            {
                MessageBox.Show("O ano do modelo do veículo não pode ser igual a 0.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nudAnoFabricacao.Value == 0)
            {
                MessageBox.Show("O ano de fabricação do veículo não pode ser igual a 0.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tbPlaca.Text.Substring(0, 3).Where(c => char.IsLetter(c)).Count() != 3)
            {
                MessageBox.Show("A placa do veículo deve possuir letras nos 3 primeiros caracteres.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            if (tbPlaca.Text.Substring(3, 4).Where(c => char.IsNumber(c)).Count() != 4)
            {
                MessageBox.Show("A placa do veículo deve possuir numeros nas posições de 4 a 7.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TelaParaTransporte();
            cVeiculo.Salvar(tVeiculo);
            LimparTela();
            CarregarGrid();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("Confirma a exclusão do veículo?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;

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

        #endregion
    }
}
