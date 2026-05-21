using System;
using System.Collections.Generic;

namespace TrabalhoPOO
{
    internal class Jogador
    {
        private List<Carta> _mao = new List<Carta>();

        public List<Carta> Mao { get => _mao; }

        public void ReceberCarta(Carta carta)
        {
            _mao.Add(carta);
        }

        public void LimparMao()
        {
            _mao.Clear();
        }

        public int CalcularPontos()
        {
            int total = 0;
            int quantidadeAses = 0;

            foreach (Carta carta in _mao)
            {
                total += carta.Peso;
                if (carta.Valor == "A") quantidadeAses++;
            }

            // Se estourou 21 e tem Ás valendo 11, transforma em 1 (subtrai 10)
            while (total > 21 && quantidadeAses > 0)
            {
                total -= 10;
                quantidadeAses--;
            }

            return total;
        }
    }
}