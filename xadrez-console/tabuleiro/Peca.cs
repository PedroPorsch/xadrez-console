using System;
namespace tabuleiro
{
	public abstract class Peca
	{
		public Posicao Posicao { get; set; }
		public Cor Cor { get; protected set; }
		public int QuantidadeMovimentos { get; protected set; }
		public Tabuleiro tab { get; protected set; }

		public Peca(Tabuleiro tab, Cor cor )
		{
			Posicao = null;
			this.tab = tab;
			Cor = cor;
			QuantidadeMovimentos = 0;

		}


		public bool ExisteMovimentosPossiveis()
		{
			bool[,] mat = MovimentosPossiveis();
			for(int i = 0; i < tab.Linhas; i++)
			{
				for(int j = 0; j < tab.Colunas; j++)
				{
					if (mat[i, j])
					{
						return true;
					}
				}
			}
			return false;
		}

		public void IncrementarMovimentos()
		{
			QuantidadeMovimentos++;
		}


		public bool PodeMoverPara(Posicao pos)
		{
			return MovimentosPossiveis()[pos.Linha, pos.Coluna];
		}

		public abstract bool[,] MovimentosPossiveis();
		
	}
}

