using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraBasica
{
    public partial class Form1 : Form
    {
        private Calculadora calculadora = new Calculadora();
        private bool novoNumero = true;
        private string expressao = "";

        public Form1()
        {
            InitializeComponent();
            txtVisor.Text = "0";
            txtVisor.TextAlign = HorizontalAlignment.Right;
        }

        private void btnNumero_Click(object sender, EventArgs e)
        {
            Button botao = (Button)sender;

            if (novoNumero && botao.Text != ".")
            {
                expressao += botao.Text;
                novoNumero = false;
            }
            else
            {
                expressao += botao.Text;
            }

            txtVisor.Text = expressao;
        }

        private void btnOperacao_Click(object sender, EventArgs e)
        {
            Button botao = (Button)sender;

            calculadora.Valor1 = double.Parse(txtVisor.Text.Split(' ').Last());
            calculadora.Operacao = botao.Text;

            expressao += " " + botao.Text + " ";
            txtVisor.Text = expressao;

            novoNumero = true;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(expressao))
                return;

            string[] partes = expressao.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string ultimoNumero = partes.Last();
            if (!double.TryParse(ultimoNumero, out double valor2))
            {
                MessageBox.Show("Erro: expressão incompleta.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            calculadora.Valor2 = valor2;

            double resultado = calculadora.Calcular();

            if (calculadora.DivisaoPorZero)
            {
                MessageBox.Show("Erro: Divisão por zero não é permitida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVisor.Text = "0";
                expressao = "";
            }
            else
            {
                txtVisor.Text = resultado.ToString();
                expressao = resultado.ToString();
            }

            novoNumero = true;
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            txtVisor.Text = "0";
            expressao = "";
            calculadora = new Calculadora();
            novoNumero = true;
        }


        private void btnRaiz_Click(object sender, EventArgs e)
        {
            double valor = double.Parse(txtVisor.Text);
            if (valor < 0)
            {
                MessageBox.Show("Erro: Raiz quadrada de número negativo não é permitida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVisor.Text = "0";
            }
            else
            {
                double resultado = Math.Sqrt(valor);
                txtVisor.Text = resultado.ToString();
                novoNumero = true;
            }
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (novoNumero)
            {
                txtVisor.Text = "0";
                novoNumero = false;
            }
            if (!txtVisor.Text.Contains("."))
            {
                txtVisor.Text += ".";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
