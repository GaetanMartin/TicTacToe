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
        private int[,] gridIA;
        public int rowIA;
        public int colIA;
        //Joueur X = 1
        //joueur O = 2

        int playerRound = 1; // Joueur 1 en premier X

        public TicTacToe()
        {
            grid = new int[3,3];
            gridIA = new int[3, 3];
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
            if (playerWin(playerRound)) MessageBox.Show("Joueur numéro "+playerRound+" a gagné.");

            playerRound += (playerRound == 1 ? 1 : -1);
            //MessageBox.Show(row + " - " + col);

            return symbol;
        }

        public String playIA()
        {
           
            String symbol = playerRound == 1 ? "X" : "O";
            initGridIA();
            playCaseIA();
            grid[rowIA, colIA] = playerRound;
            if (playerWin(playerRound)) { MessageBox.Show("Joueur numéro " + playerRound + " a gagné."); }
            playerRound += (playerRound == 1 ? 1 : -1);
            return symbol;
        }

        public void playCaseIA()
        {
            for (int indice = 1; indice <= 5; indice++)
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if(gridIA[row,col] == indice)
                        {
                            //On place le pion dans cette case.
                            rowIA = row;
                            colIA = col;
                            return;
                        }
                    }
                }
            }
            return;
        }

        public void initGridIA()
        {
            int indice;
            for(int row=0; row<3; row++)
            {
                for(int col=0; col<3; col++)
                {
                    //Si c'est une case deja occupé on mais IA a 0
                    if (grid[row, col] != 0) indice = 0;
                    //Si le joueur qui joue et gagnant 
                    else if (caseWinner(row, col)) indice = 1;
                    //Si le joueur qui joue et perdant au prochain tour si il ne joue pas dans cette case
                    else if (caseLoser(row, col)) indice = 2;
                    //Sinon si c'est la case du milieu on mais IA a 3
                    else if (row == 1 && col == 1) indice = 3;
                    //Sinon si c'est une case dans un angle on mais a 4
                    else if (row == col || (row == 2 && col == 0) || (row == 0 && col == 2)) indice = 4;
                    //SInon si c'est un bord on mais a 5
                    else indice = 5;
                    gridIA[row, col] = indice;
                    //MessageBox.Show("Indice de case (" + row + "," + col + "), indice = " + indice);
                    //Indice placé dans l'ordre d'importance de jeu 
                    //Indice 1 et 2 pour joueur qui va gagner
                    //Il est plus importante de jouer au milieu que dans un coin d'ou l'ordre...
                }
            }
        }

        public bool caseWinner(int r, int c)
        {
            grid[r, c] = playerRound;
            if (playerWin(playerRound))
            {
                grid[r, c] = 0;
                return true;
            }
            grid[r, c] = 0;
            return false;
        }

        public bool caseLoser(int r, int c)
        {
            //On teste si l'autre joueur joue dans cette case si il gagne
            playerRound += (playerRound == 1 ? 1 : -1);
            grid[r, c] = playerRound;
            if (playerWin(playerRound))
            {
                grid[r, c] = 0;
                playerRound += (playerRound == 1 ? 1 : -1);
                return true;
            }
            grid[r, c] = 0;
            playerRound += (playerRound == 1 ? 1 : -1);
            return false;
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
