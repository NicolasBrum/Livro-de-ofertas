using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Livro_de_ofertas
{
    internal class LivroOfertas
    {
        public List<Produto> Lista = new List<Produto>();

        public void processaInformacao(string informacao)
        {
            string[] info = informacao.Split(',');

            int posicao = int.Parse(info[0]);
            int acao = int.Parse(info[1]);
            double preco = double.Parse(info[2], CultureInfo.InvariantCulture);
            int quantidade = int.Parse(info[3]);

            if (!verificaSinalNegativo(posicao, preco, quantidade))
            {
                switch (acao)
                {
                    case 0:
                        inserirNaLista(posicao, preco, quantidade);
                        break;
                    case 1:
                        modificarNaLista(posicao, preco, quantidade);
                        break;
                    case 2:
                        removerNaLista(posicao);
                        break;
                    default:
                        Console.WriteLine("Nenhuma opcao disponivel");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ha numeros negativos na solicitação");
            }
        }

        public void inserirNaLista(int posicao, double valor, int quantidade)
        {
                Produto produto = new Produto(posicao, valor, quantidade);
                bool posicaoOcupada = false;

                for (int a = 0; a < Lista.Count; a++)
                {
                    if (Lista[a].Posicao == posicao)
                    {
                        posicaoOcupada = true;
                        Lista[a] = produto;
                        break;
                    }
                }

                if (!posicaoOcupada)
                {
                    Lista.Add(produto);
                }
        }

        public void modificarNaLista(int posicao, double valor, int quantidade)
        {
            for (int a = 0; a < Lista.Count; a++)
            {
                if (Lista[a].Posicao == posicao)
                {
                    Lista[a].Preco = valor;
                    Lista[a].Quantidade = quantidade;
                }
            }
        }
        public void removerNaLista(int posicao)
        {
            for(int a = 0; a < Lista.Count; a++)
            {
                if(Lista[a].Posicao == posicao)
                {
                    Lista.RemoveAll(x => x.Posicao == posicao);
                };
            }
        }
        public void ordenarLista()
        {
            for (int a = 0; a < Lista.Count; a++)
            {
                for(int b = 0; b < Lista.Count - 1; b++)
                {
                    if (Lista[b].Preco > Lista[b + 1].Preco)
                    {
                        Produto temp = Lista[b];
                        Lista[b] = Lista[b + 1];
                        Lista[b + 1] = temp;
                    }
                }
            }
        }
        public void mostrarLista()
        {
            foreach (Produto product in Lista)
            {
                Console.WriteLine(product + "\n");
            }
        }
        public bool verificaSinalNegativo(int posicao, double preco, int quantidade)
        {
            if(posicao < 0 || preco < 0 || quantidade < 0)
            {
                return true;
            }

            return false;
        }
    }
}
