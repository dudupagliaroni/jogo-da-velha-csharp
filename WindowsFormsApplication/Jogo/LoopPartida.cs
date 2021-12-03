using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha.Jogo
{
    class LoopPartida
    {
        EstadoDoJogo estadoDoJogo = EstadoDoJogo.JOGANDO;
        Jogador jogador1;
        Jogador jogador2;
        Tabuleiro tabuleiro;
        Jogador jogadorAtual;

        public LoopPartida(Jogador jogador1, Jogador jogador2, Tabuleiro tabuleiro)
        {
            this.jogador1 = jogador1;
            this.jogador2 = jogador2;
            this.tabuleiro = tabuleiro;
        }

        public void JogarPartida()
        {
            jogadorAtual = jogador1;
            while (estadoDoJogo == EstadoDoJogo.JOGANDO)
            {

                tabuleiro.UpdateTabuleiro(jogadorAtual.MovimentoJogador(this.tabuleiro, this.jogadorAtual), jogadorAtual);                    
                tabuleiro.ImprimeTabuleiro();
                estadoDoJogo = tabuleiro.CheckTabuleiro();
                FalarGanhador(estadoDoJogo);
                jogadorAtual = ProximoJogador(jogadorAtual);
            }
        }

        public Jogador ProximoJogador(Jogador jogador)
        {
            if (jogador.GetNumeroJogador() == NumeroJogador.JOGADOR_1)
            {
                Console.WriteLine("É a vez do jogador 2");
                return jogador2;
            } else
            {
                Console.WriteLine("É a vez do jogador 1");
                return jogador1;
            }
            return jogador1;
        }

        public void FalarGanhador(EstadoDoJogo estadoDoJogo)
        {
            if (estadoDoJogo == EstadoDoJogo.O_WIN)
            {
                Console.WriteLine("O JOGADOR 2 GANHOU");
            }
            if (estadoDoJogo == EstadoDoJogo.X_WIN)
            {
                Console.WriteLine("O JOGADOR 1 GANHOU");
            }
        }
    }
}
