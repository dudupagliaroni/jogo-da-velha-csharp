using JogoDaVelha.Jogo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        EstadoDoJogo estadoDoJogo = EstadoDoJogo.JOGANDO;
        Tabuleiro tabuleiro = new Tabuleiro();
        Jogador jogador1 = new Jogador(TipoJogador.HUMANO, NumeroJogador.JOGADOR_1, "Eduardo");
        Jogador jogador2 = new Jogador(TipoJogador.HUMANO, NumeroJogador.JOGADOR_2, "Bot");
        private int pontosJogador1 = 0;
        private int pontosJogador2 = 0;
        Jogador jogadorAtual;

        private PictureBox[] posicoes = { };
        public Form1()
        {
            InitializeComponent();
            jogadorAtual = jogador1;

            UpdateTabuleiro();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoopJogada(0);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoopJogada(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LoopJogada(2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            LoopJogada(3);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            LoopJogada(4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            LoopJogada(5);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            LoopJogada(6);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            LoopJogada(7);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            LoopJogada(8);
        }

        public void UpdateTabuleiro()
        {
            for (int i = 0; i < GetTodasPosicoes().Length; i++)
            {
                switch (tabuleiro.GetTabuleiro()[i])
                {
                    case MarcaJogador.E:
                        GetTodasPosicoes()[i].Image = Properties.Resources.vazio;
                        break;
                    case MarcaJogador.X:
                        GetTodasPosicoes()[i].Image = Properties.Resources.x_image;
                        break;
                    case MarcaJogador.O:
                        GetTodasPosicoes()[i].Image = Properties.Resources.o_image;
                        break;
                }
            }
        }

        public Jogador ProximoJogador(Jogador jogador)
        {
            if (jogador.GetNumeroJogador() == NumeroJogador.JOGADOR_1)
            {
                Console.WriteLine("É a vez do jogador 2");
                return jogador2;
            }
            else
            {
                Console.WriteLine("É a vez do jogador 1");
                return jogador1;
            }
            return jogador1;
        }

        private PictureBox[] GetTodasPosicoes()
        {
            PictureBox[] posicoes = { this.pictureBox1, this.pictureBox2, this.pictureBox3, this.pictureBox4, this.pictureBox5, this.pictureBox6, this.pictureBox7, this.pictureBox8, this.pictureBox9 };
            return posicoes;
        }

        public int EscolhaBot()
        {
            Bot bot = new Bot();
            return bot.EscolherPosicao(this.tabuleiro);
        }

        public void MostrarVencedor()
        {
            estadoDoJogo = tabuleiro.CheckTabuleiro();
            switch (tabuleiro.CheckTabuleiro())
            {
                case EstadoDoJogo.O_WIN:
                    pontosJogador2++;
                    labelMensagem.Text = "Jogador 2 venceu!";
                    labelMensagem.Visible = true;
                    labelScoreJogador2.Text = pontosJogador2.ToString();
                    break;
                case EstadoDoJogo.X_WIN:
                    pontosJogador1++;
                    labelMensagem.Text = "Jogador 1 venceu!";
                    labelMensagem.Visible = true;
                    labelScoreJogador1.Text = pontosJogador1.ToString();
                    break;
                case EstadoDoJogo.EMPATE:
                    labelMensagem.Text = "Empate!";
                    labelMensagem.Visible = true;
                    break;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            estadoDoJogo = EstadoDoJogo.JOGANDO;
            labelMensagem.Visible = false;
            this.tabuleiro.IniciaTabuleiro();
            UpdateTabuleiro();
        }

        private void LoopJogada(int p)
        {
            if (estadoDoJogo == EstadoDoJogo.JOGANDO)
            {
                tabuleiro.UpdateTabuleiro(p, jogadorAtual);
                UpdateTabuleiro();
                MostrarVencedor();
                if (tabuleiro.TemPosicaoLivre() && estadoDoJogo == EstadoDoJogo.JOGANDO)
                {
                    tabuleiro.UpdateTabuleiro(EscolhaBot(), jogador2);
                    UpdateTabuleiro();
                    MostrarVencedor();
                }

            }
            else
            {
                return;
            }

        }
    }
}
