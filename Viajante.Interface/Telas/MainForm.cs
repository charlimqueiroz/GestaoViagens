using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Viajante.Interface.Telas
{
    public partial class MainForm : Form
    {
        //LogDoSistema GravarLog = new LogDoSistema();

        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = false;
            Text = Text + " - Versão: ";// + Auxiliar.VersaoSistema;
        }

        #region Ações dos Botões

        protected Dictionary<Type, Form> digForms = new Dictionary<Type, Form>();

        void CarregaTela<T>() where T : new()
        {
            bool carregou = true;

            try
            {
                Form f;

                if (digForms.ContainsKey(typeof(T)))
                {
                    if (digForms.TryGetValue(typeof(T), out f))
                    {
                        if (!f.IsDisposed)
                        {
                            f.Focus();
                            carregou = false;
                        }
                        else
                        {
                            digForms.Remove(typeof(T));
                        }
                    }
                }

                if (carregou)
                {
                    Cursor = Cursors.WaitCursor;
                    f = (Form)(object)new T();
                    digForms.Add(typeof(T), f);
                    f.MdiParent = this;
                    f.Show();
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(null, "Não foi possivel carregar o objeto [ " + typeof(T) + " ] " + e.Message, "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        #endregion


        private void veículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaTela<FCadastroVeiculo>();
        }
    }
}
