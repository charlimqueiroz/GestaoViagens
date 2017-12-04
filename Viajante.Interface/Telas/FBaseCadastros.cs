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
    public partial class FBaseCadastros : Form
    {
        #region Propriedades

        #endregion

        #region Construtor/Inicialização
        public FBaseCadastros()
        {
            InitializeComponent();
        }

        #endregion

        #region Métodos da Interface

        protected void tsbSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        protected void tsbExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        #endregion

        #region Métodos Virtuais
        virtual public void Excluir() { throw new Exception("Método Excluir não implementado"); }
        virtual public bool Salvar() { throw new Exception("Método Salvar não implementado"); }
        #endregion
    }
}
