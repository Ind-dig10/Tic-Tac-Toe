using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private E_ChipsType[] playerStatus;
        private bool mPlayer1Turn;
        private bool mGameEnded;
        private int[] AIa;
       
        #region Конструктор
        public MainWindow()
        {

            InitializeComponent();
            NewGame();
        }
        #endregion

        private void NewGame()
        {
            playerStatus = new E_ChipsType[9];
            AIa = new int[9];
            
            for(var i = 0; i<playerStatus.Length; i++)
            {
                playerStatus[i] = E_ChipsType.None;
            }


            mPlayer1Turn = true;

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            mGameEnded = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(mGameEnded)
            {
                NewGame();
                return;
            }

            var button = (Button)sender;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            if (playerStatus[index] != E_ChipsType.None)
                return;

            if (mPlayer1Turn)
            {
                playerStatus[index] = E_ChipsType.Cross;
                button.Content = "X";
             //   AI(index, button);
            }
            else
            {
                playerStatus[index] = E_ChipsType.Zero;
                button.Content = "O";
                button.Foreground = Brushes.Red;
            }

      

            mPlayer1Turn ^= true;
            CheckWin();
        }

        private void CheckWin()
        {
            #region rows variable
            bool row_1 = (playerStatus[0] & playerStatus[1] & playerStatus[2]) == playerStatus[0];
            bool row_2 = (playerStatus[3] & playerStatus[4] & playerStatus[5]) == playerStatus[3];
            bool row_3 = (playerStatus[6] & playerStatus[7] & playerStatus[8]) == playerStatus[6];
            #endregion

            #region columns variable
            bool column_1 = (playerStatus[0] & playerStatus[3] & playerStatus[6]) == playerStatus[0];
            bool column_2 = (playerStatus[1] & playerStatus[4] & playerStatus[7]) == playerStatus[1];
            bool column_3 = (playerStatus[2] & playerStatus[5] & playerStatus[6]) == playerStatus[2];
            #endregion

            #region diagonal variable
            bool diagonal_1 = (playerStatus[2] & playerStatus[4] & playerStatus[6]) == playerStatus[2];
            bool diagonal_2 = (playerStatus[0] & playerStatus[4] & playerStatus[8]) == playerStatus[0];
            #endregion

            if (playerStatus[0] != E_ChipsType.None && row_1)
            {
                Victory();
            }
            
            if (playerStatus[3] != E_ChipsType.None && row_2)
            {
                Victory();
            }

            if (playerStatus[6] != E_ChipsType.None && row_3)
            {
                Victory();
            }

            if (playerStatus[0] != E_ChipsType.None && column_1)
            {
                Victory();
            }

            if (playerStatus[1] != E_ChipsType.None && column_2)
            {
                Victory();
            }

            if (playerStatus[2] != E_ChipsType.None && column_3)
            {
                Victory();
            }

            if(playerStatus[2] != E_ChipsType.None && diagonal_1)
            {
                Victory();
            }

            if (playerStatus[0] != E_ChipsType.None && diagonal_2)
            {
                Victory();
            }



            if (!playerStatus.Any(result => result == E_ChipsType.None))
            {
                mGameEnded = true;

                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                //    button.Content = string.Empty;
                    button.Background = Brushes.White;

                });
            }
        }

        private void Victory()
        {
            mGameEnded = true;
            MessageBox.Show("Win");
        }

        private void AI(int i, Button sender)
        {


            for(int j = 0; j<9; j++)
            {
                if (playerStatus[j] == E_ChipsType.None)
                    AIa[j] = 0;

                if (playerStatus[j] == E_ChipsType.Cross)
                    AIa[j] = -1;

                if (playerStatus[j] == E_ChipsType.Zero)
                    AIa[j] = 1;
            }
            
            if(playerStatus[4] == E_ChipsType.None)
            {
                playerStatus[i] = E_ChipsType.Zero;
                sender.Content = "O";
                sender.Foreground = Brushes.Red;
            }


            //Container.Children.Cast<Button>().ToList
            //for(int j = 0; j<9; j++)
            //{
            //    if(playerStatus[j] == E_ChipsType.None)
            //    {
            //        playerStatus[i] = E_ChipsType.Zero;
            //        sender.Content = "O";
            //        sender.Foreground = Brushes.Red;
            //    }
            //}

            mPlayer1Turn = false;
        }
    }
}
