using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraBasica
{
    public class Calculadora
    {
        public double Valor1 { get; set; }
        public double Valor2 { get; set; }
        public string Operacao { get; set; }
        public bool DivisaoPorZero { get; set; }

        public double Calcular()
        {
            DivisaoPorZero = false;

            switch (Operacao)
            {
                case "+": return Valor1 + Valor2;
                case "-": return Valor1 - Valor2;
                case "x": return Valor1 * Valor2;
                case "/":
                    if (Valor2 == 0)
                    {
                        DivisaoPorZero = true;
                        return double.NaN;
                    }
                    return Valor1 / Valor2;
                case "^":
                    return Math.Pow(Valor1, Valor2);
                default:
                    return Valor2;
            }
        }
    }
}
