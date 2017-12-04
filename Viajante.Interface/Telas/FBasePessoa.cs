using System;
using System.Collections.Generic;
using Viajante.Negocio.Fabrica;
using Viajante.Transporte.Cadastros;
using Viajante.Transporte.IControles;

namespace Viajante.Interface.Telas
{
    public partial class FBasePessoa : FBaseCadastros
    {
        #region Propriedades
        ICCliente cCliente = FabricaDeControles<ICCliente>.Instancia;
        ICUnidadeFederacao cUF = FabricaDeControles<ICUnidadeFederacao>.Instancia;

        #endregion

        #region Construtor/Inicialização
        public FBasePessoa()
        {
            InitializeComponent();
            Inicializar();
        }



        #endregion
        private void Inicializar()
        {
            cbEstadoCivil.DataSource = Enum.GetValues(typeof(EstadoCivil));
            cbGenero.DataSource = Enum.GetValues(typeof(TipoGenero));
            CarregarUnidadeFederacao();
        }

        private void CarregarUnidadeFederacao()
        {
            List<TUnidadeFederacao> tLista = (List<TUnidadeFederacao>)cUF.BuscarTodos();
            tLista.Sort(SortLista);

            cbUfIdentidade.BeginUpdate();

            cbUfIdentidade.DataSource = tLista;
            cbUfIdentidade.ValueMember = "Id";
            cbUfIdentidade.DisplayMember = "Sigla";

            cbUfIdentidade.SelectedIndex = -1;

            cbUfIdentidade.EndUpdate();
        }

        private int SortLista(TUnidadeFederacao filler1, TUnidadeFederacao filler2)
        {
            return filler1.Sigla.CompareTo(filler2.Sigla);
        }

        #region Métodos da Interface


        #endregion

        #region Métodos de Controle de Tela
        protected virtual void TransporteParaTela(TPessoa tPessoa)
        {

            if (tPessoa != null)
            {
                tbCodigo.Text = tPessoa.Codigo;
                tbRazaoSocial.Text = tPessoa.RazaoSocial;
                if (tPessoa.TipoPessoa == TipoPessoa.Fisica)
                    rbFisica.Checked = true;
                else
                    rbJuridica.Checked = true;
                tbCpfCnpj.Text = tPessoa.CpfCnpj;
                tbInscricaoEstadual.Text = tPessoa.InscricaoEstadual;
                tbInscricaoMunicipal.Text = tPessoa.InscricaoMunicipal;
                tbNome.Text = tPessoa.NomeFantasia;
                cbEstadoCivil.SelectedItem = tPessoa.EstadoCivil;
                cbGenero.SelectedItem = tPessoa.Genero;
                tbEmail.Text = tPessoa.Email;
                tbSite.Text = tPessoa.Site;
                tbNacionalidade.Text = tPessoa.Nacionalidade;
                tbProfissao.Text = tPessoa.Profissao;
                tbIdentidade.Text = tPessoa.NumeroIdentidade;
                tbOrgaoExpedidor.Text = tPessoa.OrgaoExpedidorIdentidade;
                cbUfIdentidade.SelectedItem = tPessoa.UnidadeFederacaoIdentidade;
            }

        }

        protected virtual void TelaParaTransporte(TPessoa tPessoa)
        {

            tPessoa.Codigo = tbCodigo.Text;
            tPessoa.RazaoSocial = tbRazaoSocial.Text;
            if (rbFisica.Checked)
                tPessoa.TipoPessoa = TipoPessoa.Fisica;
            else
                tPessoa.TipoPessoa = TipoPessoa.Juridica;
            tPessoa.CpfCnpj = tbCpfCnpj.Text;
            tPessoa.InscricaoEstadual = tbInscricaoEstadual.Text;
            tPessoa.InscricaoMunicipal = tbInscricaoMunicipal.Text;
            tPessoa.NomeFantasia = tbNome.Text;
            tPessoa.EstadoCivil = (EstadoCivil)cbEstadoCivil.SelectedItem;
            tPessoa.Genero = (TipoGenero)cbGenero.SelectedItem;
            tPessoa.Email = tbEmail.Text;
            tPessoa.Site = tbSite.Text;
            tPessoa.Nacionalidade = tbNacionalidade.Text;
            tPessoa.Profissao = tbProfissao.Text;
            tPessoa.NumeroIdentidade = tbIdentidade.Text;
            tPessoa.OrgaoExpedidorIdentidade = tbOrgaoExpedidor.Text;
            tPessoa.UnidadeFederacaoIdentidade = cUF.BuscarPeloId((long)cbUfIdentidade.SelectedValue);
        }

    }
    #endregion
}

