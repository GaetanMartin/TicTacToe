using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class F_TicTacToe : Form
    {

        Button[] buttons;

        TicTacToe ticTacToe;
        Minimax minimax;

        public F_TicTacToe()
        {
            InitializeComponent();
            //ticTacToe = new TicTacToe();
            minimax = new Minimax();
            buttons = new Button[9];
            initButtons();
        }

        public void initButtons()
        {
            int index = 0;
            for (int col = 0; col < tlp.ColumnCount; col ++)
            {
                for (int row = 0; row < tlp.RowCount; row ++)
                {
                    Control control = tlp.GetControlFromPosition(col, row);
                    if (control is Button)
                    {
                        Button button = (Button)control;
                        button.Text = "";
                        button.Click += buttonClick;
                        buttons[index] = button;
                        index ++;
                    }
                }
            }
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            TableLayoutPanel t = (TableLayoutPanel)button.Parent;
            TableLayoutPanelCellPosition position = t.GetPositionFromControl(button);
            int colIndex = position.Column;
            int rowIndex = position.Row;
            button.Text = minimax.play(rowIndex, colIndex);
            button.Enabled = false;

            
            String s= minimax.playIA();
            Control control = tlp.GetControlFromPosition(minimax.colIA, minimax.rowIA);
            if (control is Button)
            {
                Button b = (Button)control;
                b.Text = s;
                b.Enabled = false;
            }
            
        }

        public void resetButtons()
        {
            int index = 0;
            for (int col = 0; col < tlp.ColumnCount; col++)
            {
                for (int row = 0; row < tlp.RowCount; row++)
                {
                    Control control = tlp.GetControlFromPosition(col, row);
                    if (control is Button)
                    {
                        Button button = (Button)control;
                        button.Text = "";
                        button.Enabled = true;
                        buttons[index] = button;
                        index++;
                    }
                }
            }
        }

        private void restart_Click(object sender, EventArgs e)
        {
            minimax.initGrid();
            resetButtons();
        }
    }
}
