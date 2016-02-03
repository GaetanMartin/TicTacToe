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

        public TicTacToe()
        {
            grid = new int[3,3];
        }

        public void play(int row, int column)
        {
            MessageBox.Show(row + " - " + column);
        }
    }
}
