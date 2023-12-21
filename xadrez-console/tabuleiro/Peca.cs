using System;
namespace tabuleiro
{
	public class Peca
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



	}
}

