﻿using System;
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

        public F_TicTacToe()
        {
            InitializeComponent();
            ticTacToe = new TicTacToe();
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
            ticTacToe.play(rowIndex, colIndex);            
        }
    }
}