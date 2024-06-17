using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Livro_de_ofertas
{
    internal class Produto
    {
        public int Posicao { get; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }

        public Produto(int posicao, double preco, int quantidade)
        {
            this.Posicao = posicao;
            this.Preco = preco;
            this.Quantidade = quantidade;
        }

        public override string ToString()
        {
            return Posicao.ToString() + ',' + Preco.ToString(CultureInfo.InvariantCulture) + ',' + Quantidade.ToString();
        }
    }
}
