using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace Livro_de_ofertas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantidadeAtualizacao = int.Parse(Console.ReadLine());
            LivroOfertas livroOfertas = new LivroOfertas();

            for (int a = 0; a < quantidadeAtualizacao; a++)
            {
                string response = Console.ReadLine();

                livroOfertas.processaInformacao(response);
            }

            Console.WriteLine();
            livroOfertas.ordenarLista();
            livroOfertas.mostrarLista();
        }
    }
}
