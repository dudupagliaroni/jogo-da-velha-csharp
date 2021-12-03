using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha.Jogo
{


    public class Tabuleiro
    {
        private int[] centroECantos = { 0, 2, 4, 6, 8 };
        private int[] todasPosicoes = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

        private int[][] todasAsLinhas = {
            new int[]{ 0, 1, 2 }, //linha1
            new int[]{ 3, 4, 5 }, //linha2
            new int[]{ 6, 7, 8 }, //linha3
            new int[]{ 0, 3, 6 }, //coluna1
            new int[]{ 1, 4, 7 }, //coluna2
            new int[]{ 2, 5, 8 }, //coluna3
            new int[]{ 0, 4, 8 }, //diagonal1
            new int[]{ 2, 4, 6 }  //diagonal2
        };

        private MarcaJogador[] tabuleiro;

        public Tabuleiro()
        {
            IniciaTabuleiro();
        }


        public void UpdateTabuleiro(int posicao, Jogador jogador)
        {
            this.tabuleiro[posicao] = jogador.GetMarcaJogador();
        }

        public void IniciaTabuleiro()
        {
            this.tabuleiro = Enumerable.Repeat(MarcaJogador.E, 9).ToArray();
        }

        public MarcaJogador[] GetTabuleiro()
        {
            return this.tabuleiro;
        }

        public void ImprimeTabuleiro()
        {
            int k = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    switch (this.tabuleiro[k])
                    {
                        case MarcaJogador.E:
                            Console.Write(" _ ");
                            break;
                        case MarcaJogador.X:
                            Console.Write(" X ");
                            break;
                        case MarcaJogador.O:
                            Console.Write(" O ");
                            break;

                    }
                    k++;
                }
                Console.WriteLine();
                Console.WriteLine("---------");
            }
            Console.WriteLine();
        }

        public EstadoDoJogo CheckTabuleiro()
        {
            EstadoDoJogo estadoDoJogo = EstadoDoJogo.JOGANDO;
            estadoDoJogo = CheckEmpate();

            foreach (int[] linha in GetTodasAsLinhas())
            {
                int marcasJogador1 = 0;
                int marcasJogador2 = 0;

                foreach (int index in linha)
                {
                    if (GetTabuleiro()[index] == MarcaJogador.X)
                    {
                        marcasJogador1++;
                    }
                    if (GetTabuleiro()[index] == MarcaJogador.O)
                    {
                        marcasJogador2++;
                    }
                }

                if (marcasJogador1 == 3)
                {
                    estadoDoJogo = EstadoDoJogo.X_WIN;
                }
                if (marcasJogador2 == 3)
                {
                    estadoDoJogo = EstadoDoJogo.O_WIN;
                }
            }
            return estadoDoJogo;
        }

        public EstadoDoJogo CheckEmpate()
        {
            foreach (MarcaJogador posicao in this.tabuleiro)
            {
                if (posicao == MarcaJogador.E)
                {
                    return EstadoDoJogo.JOGANDO;
                }
            }
            return EstadoDoJogo.EMPATE;
        }

        public bool TemPosicaoLivre()
        {
            bool temPosicao = false;
            foreach (MarcaJogador marcaJogador in this.GetTabuleiro())
            {
                if (marcaJogador == MarcaJogador.E)
                {
                    temPosicao = true;
                }
            }
            return temPosicao;
        }

        public bool PosicaoEstaLivre(int posicao)
        {
            switch (this.tabuleiro[posicao])
            {
                case MarcaJogador.E:
                    return true;
                case MarcaJogador.O:
                    return false;
                case MarcaJogador.X:
                    return false;     
            }
            return false;
        }

        public int[][] GetTodasAsLinhas()
        {
            return todasAsLinhas;
        }

        public int[] GetTodasAsPosicoes()
        {
            return this.todasPosicoes;
        }
    }
}
