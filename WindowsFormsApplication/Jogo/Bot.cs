using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha.Jogo
{
    class Bot
    {
        private int posicaoDoBot = 0;

        public int EscolherPosicao(Tabuleiro tabuleiro)
        {

            posicaoDoBot = EscolherPosicaoAleatoria(tabuleiro.GetTodasAsPosicoes(), tabuleiro);
            posicaoDoBot = EscolherPosicaoSeALinhaFoiIniciada(tabuleiro);
            posicaoDoBot = EscolherPosicaoSeALinhaEstiverPerdendo(tabuleiro);
            posicaoDoBot = EscolherPosicaoSeALinhaEstiverGanhando(tabuleiro);

            return posicaoDoBot;

        }

        private int EscolherPosicaoSeALinhaEstiverGanhando(Tabuleiro tabuleiro)
        {
            int posicaoEscolhida = posicaoDoBot;
            foreach (int[] linha in tabuleiro.GetTodasAsLinhas())
            {
                if (CheckSeALinhaEstaGanhando(linha, tabuleiro))
                {
                    posicaoEscolhida = EscolherPosicaoAleatoria(linha, tabuleiro);
                }
            }
            return posicaoEscolhida;
        }

        private bool CheckSeALinhaEstaGanhando(int[] linha, Tabuleiro tabuleiro)
        {
            bool linhaEstaGanhando = false;
            int numMarcasJogador1 = 0;
            int numMarcasJogador2 = 0;

            for (int i = 0; i < linha.Length; i++)
            {
                int index = linha[i];
                if (tabuleiro.GetTabuleiro()[index] == MarcaJogador.X)
                {
                    numMarcasJogador1++;
                }
                if (tabuleiro.GetTabuleiro()[index] == MarcaJogador.O)
                {
                    numMarcasJogador2++;
                }
            }
            if (numMarcasJogador2 == 2 && numMarcasJogador1 == 0)
            {
                linhaEstaGanhando = true;
            }
            return linhaEstaGanhando;
        }

        private int EscolherPosicaoSeALinhaEstiverPerdendo(Tabuleiro tabuleiro)
        {
            int posicaoEscolhida = posicaoDoBot;
            foreach (int[] linha in tabuleiro.GetTodasAsLinhas())
            {
                if (CheckSeALinhaEstaPerdendo(linha, tabuleiro))
                {
                    posicaoEscolhida = EscolherPosicaoAleatoria(linha, tabuleiro);
                }
            }
            return posicaoEscolhida;
        }

        private bool CheckSeALinhaEstaPerdendo(int[] linha, Tabuleiro tabuleiro)
        {
            bool linhaPerdendo = false;
            bool linhaSalva = false;

            for (int i = 0; i < linha.Length; i++)
            {
                int index = linha[i];
                if (tabuleiro.GetTabuleiro()[index] == MarcaJogador.O)
                {
                    linhaSalva = true;
                    break;
                }
            }

            if (!linhaSalva)
            {
                int numMarcas = 0;
                for (int j = 0; j < linha.Length; j++)
                {
                    int index = linha[j];
                    if (tabuleiro.GetTabuleiro()[index] == MarcaJogador.X)
                    {
                        numMarcas++;
                    }
                }
                if (numMarcas == 2)
                {
                    linhaPerdendo = true;
                }
            }
            return linhaPerdendo;
        }

        private int EscolherPosicaoSeALinhaFoiIniciada(Tabuleiro tabuleiro)
        {
            int posicaoEscolhida = posicaoDoBot;
            foreach (int[] linha in tabuleiro.GetTodasAsLinhas())
            {
                if (CheckSeLinhaFoiIniciada(linha, tabuleiro))
                {
                    posicaoEscolhida = EscolherPosicaoAleatoria(linha, tabuleiro);
                    break;
                }
            }
            return posicaoEscolhida;
        }

        private bool CheckSeLinhaFoiIniciada(int[] linha, Tabuleiro tabuleiro)
        {
            bool linhaFoiIniciada = false;
            int numMarcasJogador1 = 0;
            int numMarcasJogador2 = 0;
            for (int i = 0; i < linha.Length; i++)
            {
                int index = linha[i];
                if (tabuleiro.GetTabuleiro()[index] == MarcaJogador.X)
                {
                    numMarcasJogador1++;
                }
                if (tabuleiro.GetTabuleiro()[index] == MarcaJogador.O)
                {
                    numMarcasJogador2++;
                }
            }
            if (numMarcasJogador2 == 1 && numMarcasJogador1 == 0)
            {
                linhaFoiIniciada = true;
            }
            return linhaFoiIniciada;

        }

        private int EscolherPosicaoAleatoria(int[] posicoes, Tabuleiro tabuleiro)
        {
            Random rnd = new Random();
            int rndPos = 0;
            int index = 0;
            bool isEmpty = false;

            while (!isEmpty)
            {
                rndPos = rnd.Next(posicoes.Length);
                index = posicoes[rndPos];
                if (tabuleiro.GetTabuleiro()[index] == MarcaJogador.E)
                {
                    isEmpty = true;
                }
            }
            return index;
        }
    }
}
