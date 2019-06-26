using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TratamentoExcecoes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Pessoa bacana = new Pessoa();
            try
            {
                // VALIDACAO DO CAMPO NOME
                if (txtNome.Text.Length < 1)
                    throw new ValidacaoException("O campo nome é de preenchimento obrigatório", txtNome);
                bacana.Nome = txtNome.Text;

                // VALIDACAO DO CAMPO IDADE
                byte num = Convert.ToByte(txtIdade.Text);
                if (num < 1 || num > 110)
                    throw new ValidacaoException("O campo idade deve ser preenchido com um valor entre 1 e 110", txtIdade);
                bacana.Idade = num;
            }
            catch (ValidacaoException ve)
            {
                DialogResult resp = MessageBox.Show(ve.Message,
                    "Validação de Dados",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error);
                if (resp == DialogResult.OK)
                    ve.Focus();
                else
                    this.Close();
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Verifique se os campos foram preenchidos com os tipos dados corretos"
                    + Environment.NewLine
                    + "Erro: " + fe.Message);
            }
            catch (OverflowException oe)
            {
                MessageBox.Show("Verifique o intervalo permitido nos campos numéricos"
                    + Environment.NewLine
                    + "Erro: " + oe.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha do sistema. Tente novamente."
                    + Environment.NewLine
                    + "Erro: " + ex.Message);
            }
        }
    }
}
