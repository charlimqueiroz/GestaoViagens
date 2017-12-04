using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Viajante.Negocio.Fabrica;
using Viajante.Transporte.Cadastros;
using Viajante.Transporte.IControles;

namespace Viajante.Interface
{
    public partial class FCadastroCliente : Viajante.Interface.Telas.FBasePessoa
    {
        #region Propriedades
        private ICCliente cCliente = FabricaDeControles<ICCliente>.Instancia;
        private TCliente tCliente = new TCliente();

        #endregion
        public FCadastroCliente()
        {
            InitializeComponent();
        }
    }
}
