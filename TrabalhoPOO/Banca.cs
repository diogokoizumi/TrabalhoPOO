using System;

namespace TrabalhoPOO
{
    internal class Banca : Jogador  // herda tudo do Jogador
    {
        public void ExecutarJogada(Baralho baralho, int pontosDoJogador)
        {
            // Se jogador estourou, banca não precisa jogar
            if (pontosDoJogador > 21) return;

            while (CalcularPontos() <= 21)
            {
                int pontos = CalcularPontos();

                // Para se tiver 17 ou mais E já superou ou empatou com o jogador
                if (pontos >= 17 && pontos >= pontosDoJogador) break;

                ReceberCarta(baralho.ComprarCarta());
            }
        }
    }
}