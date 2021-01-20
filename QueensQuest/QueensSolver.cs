using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;
using System;

[assembly: InternalsVisibleTo("QueensQuestTests")]
namespace QueensQuest
{
    public class QueensSolver
    {
        internal List<int[,]> _queensPositions;
        internal int _size;
        public QueensSolver(int size)
        {
            _queensPositions = new List<int[,]>();
            _size = size;
        }
        internal bool IsPositionSafe(int[,] board, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                if (board[i, col] == 1)
                    return false;
            }
            
            for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1)
                    return false;
            }

            for (int i = row, j = col; i >= 0 && j < _size; i--, j++)
            {
                if (board[i, j] == 1)
                    return false;
            }

            return true;
        }
        public int[][,] Solve()
        {
            int[,] board = new int[_size, _size];

            SolveQueens(board, 0);

            return _queensPositions.ToArray();
        }
        internal bool SolveQueens(int[,] board, int row)
        {
            if(row == _size)
            {
                _queensPositions.Add(board.Clone() as int[,]);

                return true;
            }

            bool res = false;
            for (int i = 0; i < _size; i++)
            {
                if ( IsPositionSafe(board, row, i))
                {
                    board[row, i] = 1;

                    res = SolveQueens(board, row + 1) || res;

                    board[row, i] = 0;
                }
            }

            return res;
        }
    }
}