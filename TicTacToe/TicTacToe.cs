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
        //Joueur X = 1
        //joueur O = 2

        int playerRound = 1; // Joueur 1 en premier X

        public TicTacToe()
        {
            grid = new int[3,3];
            initGrid();
        }

        public void initGrid()
        {
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    grid[i, j] = 0;
                }
            }
        }

        public String play(int row, int col)
        {
            String symbol = playerRound == 1 ? "X" : "O";
            grid[row, col] = playerRound;
            if (playerWin(playerRound)) MessageBox.Show("Vous avez gagné");

            playerRound += (playerRound == 1 ? 1 : -1);
            //MessageBox.Show(row + " - " + col);

            return symbol;
        }

        public String playIA()
        {
            int col=0, row = 0;
            String symbol = playerRound == 1 ? "X" : "O";
            //Il faut maintenant determiner ou placer le pion




            grid[row, col] = playerRound;
            playerRound += (playerRound != 1 ? 1 : -1);
            return symbol;
        }


        
        public bool playerWinDiag(int player)
        {
            if((grid[1,1]==player) && ((player == grid[2, 0] && player==grid[0,2]) || (player == grid[0, 0] && player == grid[2, 2])))
            {
                return true;
            }
            return false;
        }

        public bool playerWinRow(int player)
        {
            for(int row = 0; row <= 2; row++)
            {
                if (grid[row, 0] == player && grid[row, 1] == player && grid[row, 2] == player) return true;
            }
            return false;
        }

        public bool playerWinCol(int player)
        {
            for (int col = 0; col <= 2; col++)
            {
                if (grid[0, col] == player && grid[1, col] == player && grid[2, col] == player) return true;
            }
            return false;
        }

        public bool playerWin(int player)
        {
            if (playerWinCol(player) || playerWinRow(player) || playerWinDiag(player)) return true;
            return false;
        }

    }
}
