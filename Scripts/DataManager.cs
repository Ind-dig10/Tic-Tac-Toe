using System.Collections.Generic;

namespace TicTacToe
{
    public partial class MainWindow
    {
        public int[,] win = new int[,]
        {
            { 0, 0},
            { 0, 1},
            { 0, 2},
            { 1, 0},
            { 1, 1},
            { 1, 2},
            { 2, 1},
            { 2, 2}
        };

        public int[] arr= new int[]{0,0};
        public int[] arr2 = new int[] { 0, 1 };
        public int[] arr3 = new int[] { 0, 2 };
    }
}
