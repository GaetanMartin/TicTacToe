using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    class Minimax
    {
        public enum Piece { Empty = 0, X = 1, O = 2 };


        int playerRound;
        private int[,] grid;
        private int[,] gridIA;
        public int rowIA;
        public int colIA;

        public Minimax()
        {
            grid = new int[3, 3];
            gridIA = new int[3, 3];
            initGrid();
            this.playerRound = 1;

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
            if (checkGameWin(grid,(playerRound))) MessageBox.Show("Joueur numéro " + playerRound + " a gagné.");

            playerRound = switchPiece(1);
            //MessageBox.Show(row + " - " + col);

            return symbol;
        }

        public String playIA()
        {
            String symbol = playerRound == 1 ? "X" : "O";
            minimax(cloneGrid(grid), 2);
            grid = makeGridMove(grid, 2, rowIA, colIA);
            if (checkGameWin(grid, playerRound)) { MessageBox.Show("Joueur numéro " + playerRound + " a gagné."); }
            playerRound = switchPiece(2);
            return symbol;
        }



        public void SetPlayer(int Player)
        {
            this.playerRound = Player;
        }

        int minimax(int[,] InputGrid, int Player)
        {
            int[,] Grid = cloneGrid(InputGrid);

            if (checkScore(Grid, Player) != 0)
                return checkScore(Grid, 2);
            else if (checkGameEnd(Grid)) return 0;

            List<int> scores = new List<int>();
            List<int> row = new List<int>();
            List<int> col = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Grid[i,j] == 0)
                    {
                        scores.Add(minimax(makeGridMove(Grid, Player, i,j), switchPiece(Player)));
                        row.Add(i);
                        col.Add(j);
                    }
                }
       
            }

            if (Player == 2)
            {
                int MaxScoreIndex = scores.IndexOf(scores.Max());
                this.rowIA = row[MaxScoreIndex];
                this.colIA = col[MaxScoreIndex];
                return scores.Max();
            }
            else
            {
                int MinScoreIndex = scores.IndexOf(scores.Min());
                this.rowIA = row[MinScoreIndex];
                this.colIA = col[MinScoreIndex];
                return scores.Min();
            }
        }

        public int checkScore(int[,] grid, int Player)
        {
            if (checkGameWin(grid, Player)) return 10;

            else if (checkGameWin(grid, switchPiece(Player))) return -10;

            else return 0;
        }

        public bool checkGameWin(int[,] grid, int player)
        {
            if (playerWinCol(grid, player) || playerWinRow(grid, player) || playerWinDiag(grid, player)) return true;
            return false;
        }

        public bool playerWinDiag(int[,] grid, int player)
        {
            if ((grid[1, 1] == player) && ((player == grid[2, 0] && player == grid[0, 2]) || (player == grid[0, 0] && player == grid[2, 2])))
            {
                return true;
            }
            return false;
        }

        public bool playerWinRow(int[,] grid, int player)
        {
            for (int row = 0; row <= 2; row++)
            {
                if (grid[row, 0] == player && grid[row, 1] == player && grid[row, 2] == player) return true;
            }
            return false;
        }

        public bool playerWinCol(int[,] grid, int player)
        {
            for (int col = 0; col <= 2; col++)
            {
                if (grid[0, col] == player && grid[1, col] == player && grid[2, col] == player) return true;
            }
            return false;
        }

        static bool checkGameEnd(int[,] grid)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[i, j] == 0)
                        return false;
                }
            }
            return true;
        }

        public int switchPiece(int player)
        {
            if (player == 1)
            {
                return 2;
            }
            return 1;
        }

        static int[,] cloneGrid(int[,] grid)
        {
            int[,] clone = new int[3,3];
            for(int i=0;i<3; i++)
            {
                for (int j = 0; j < 3; j++)
                    clone[i, j] = grid[i, j];
            }

            return clone;
        }

        static int[,] makeGridMove(int[,] grid, int player, int row, int col)
        {
            int[,] newGrid = cloneGrid(grid);
            newGrid[row, col] = player;
            return newGrid;
        }
    }
}
