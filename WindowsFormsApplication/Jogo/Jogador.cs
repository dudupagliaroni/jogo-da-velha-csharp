using System;

namespace JogoDaVelha.Jogo
{
    public enum NumeroJogador
    {
        JOGADOR_1, JOGADOR_2
    }

    public enum TipoJogador
    {
        HUMANO, BOT
    }

    public class Jogador
    {
        private TipoJogador tipoJogador;
        private NumeroJogador numeroJogador;
        private MarcaJogador marcaJogador;
        private int pontos;
        private string nome;


        public Jogador(TipoJogador tipoJogador, NumeroJogador numeroJogador, string nome)
        {
            this.nome = nome;
            this.numeroJogador = numeroJogador;
            this.tipoJogador = tipoJogador;
            this.pontos = 0;
        }

        public int MovimentoJogador(Tabuleiro tabuleiro, Jogador jogador)
        {

            switch (jogador.tipoJogador)
            {
                case TipoJogador.HUMANO:
                    return EscolherPosicaoHumano(tabuleiro);


                case TipoJogador.BOT:
                    Bot bot = new Bot();
                    return bot.EscolherPosicao(tabuleiro);

            }
            return 0;
        }
          
        public int EscolherPosicaoHumano(Tabuleiro tabuleiro)
        {
            int posicao = int.Parse(Console.ReadLine()) - 1;
            while (!tabuleiro.PosicaoEstaLivre(posicao))
            {
                posicao = int.Parse(Console.ReadLine()) - 1;
            }
            return posicao;
        }



        public MarcaJogador GetMarcaJogador()
        {
            if (numeroJogador == NumeroJogador.JOGADOR_1)
            {
                return MarcaJogador.X;
            }
            else
            {
                return MarcaJogador.O;
            }
        }

        public NumeroJogador GetNumeroJogador()
        {
            return this.numeroJogador;
        }

        public TipoJogador GetTipoJogador()
        {
            return this.tipoJogador;
        }
    }
}
