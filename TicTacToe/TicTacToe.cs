using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    class TicTacToe
    {

        private int[,] grid;

        int playerTurn = 1; // Joueur 1 en premier

        public TicTacToe()
        {
            grid = new int[3,3];
        }

        public String play(int row, int column)
        {
            String symbol = playerTurn == 1 ? "X" : "O";
            // playerTurn = (playerTurn + 1) % 2 + 1;
            MessageBox.Show(row + " - " + column);
            return symbol;
        }
    }
}
