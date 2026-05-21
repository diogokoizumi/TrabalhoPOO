using System;
using System.Collections.Generic;

namespace TrabalhoPOO
{
    internal class Baralho
    {
        // Alterado de _cartas (private) para uma Propriedade Pública, 
        // assim o seu Form consegue saber quantas cartas restam, se precisar.
        public List<Carta> Cartas { get; private set; }

        public Baralho()
        {
            Cartas = new List<Carta>();

            // Usando as mesmas listas de valores e naipes da sua classe Carta
            string[] naipes = { "Paus", "Copas", "Espadas", "Ouros" };
            string[] valores = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            // Cria todas as 52 cartas
            foreach (string naipe in naipes)
            {
                foreach (string valor in valores)
                {
                    // A própria classe Carta já vai definir o Peso e o Path
                    Carta novaCarta = new Carta(valor, naipe);
                    Cartas.Add(novaCarta);
                }
            }

            Embaralhar();
        }

        public void Embaralhar()
        {
            Random rnd = new Random();
            int n = Cartas.Count;

            // Algoritmo Fisher-Yates para garantir um embaralhamento perfeito
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                Carta value = Cartas[k];
                Cartas[k] = Cartas[n];
                Cartas[n] = value;
            }
        }

        // Método auxiliar para você usar no seu jogo de 21
        public Carta ComprarCarta()
        {
            if (Cartas.Count > 0)
            {
                Carta cartaPuxada = Cartas[0];
                Cartas.RemoveAt(0); // Tira do baralho para não ser puxada de novo
                return cartaPuxada;
            }

            // Retorna nulo se não houver mais cartas (você pode tratar isso no Form)
            return null;
        }
    }
}