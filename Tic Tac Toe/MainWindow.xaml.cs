using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool playerOneTurn;

        // 0 = free
        // 1 = X
        // 2 = O
        private int[] values;

        public MainWindow()
        {
            InitializeComponent();

            newGame();
        }

        private void newGame()
        {
            values = new int[9];

            mainGrid.Children.Cast<Button>().ToList().ForEach(x => x.Content = null);

            playerOneTurn = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn.Content != null)
                return;

            btn.Content = playerOneTurn ? "X" : "O";

            var col = Grid.GetColumn(btn);
            var row = Grid.GetRow(btn);

            var i = col + row * 3;

            values[i] = btn.Content.ToString() == "X" ? 1 : 2;

            playerOneTurn = !playerOneTurn;

            checkBoard();
        }

        private void checkBoard()
        {
            var result = values.Where(x => x == 0).ToList();

            if (result.Count == 0)
            {
                //Tapos na
                MessageBox.Show("Walang nanalo", "Game Ended");
                newGame();
            }

            //Check Horizontal
            checkHorizontal(0);
            checkHorizontal(1);
            checkHorizontal(2);

            //Check Vertical
            checkVertical(0);
            checkVertical(1);
            checkVertical(2);

            //0 4 8
            //2 4 6
            if (values[0] != 0 && (values[0] & values[4] & values[8]) == values[0])
            {
                //Tapos na
                MessageBox.Show(!playerOneTurn ? "Player One Won" : "Player Two Won", "Game Ended");
                newGame();
            }

            if (values[2] != 0 && (values[2] & values[4] & values[6]) == values[2])
            {
                //Tapos na
                MessageBox.Show(!playerOneTurn ? "Player One Won" : "Player Two Won", "Game Ended");
                newGame();
            }
        }

        private void checkHorizontal(int row)
        {
            var col = row * 3;
            if (values[col] != 0 && (values[col] & values[col + 1] & values[col + 2]) == values[col])
            {
                //Tapos na
                MessageBox.Show(!playerOneTurn ? "Player One Won" : "Player Two Won", "Game Ended");
                newGame();
            }
        }

        private void checkVertical(int col)
        {
            // 0 3 6
            // 1 4 7
            // 2 5 8
            if (values[col] != 0 && (values[col] & values[col + 3] & values[col + 6]) == values[col])
            {
                //Tapos na
                MessageBox.Show(!playerOneTurn ? "Player One Won" : "Player Two Won", "Game Ended");
                newGame();
            }
        }
    }
}
