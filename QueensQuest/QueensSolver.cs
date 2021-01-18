using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("QueensQuestTests")]
namespace QueensQuest
{
    public class QueensSolver
    {
        internal bool[,] _chessMatrix;
        internal bool[,] _queensPositions;
        internal int _size;
        public QueensSolver(int size)
        {
            _size = size;
            GenerateMatrix(ref _chessMatrix);
            GenerateMatrix(ref _queensPositions);
        }
        internal void GenerateMatrix(ref bool[,] arr)
        {
            arr = new bool[_size, _size];
            for(int i = 0; i < _size; i++)
                for(int j = 0; j < _size; j++)
                    arr[i,j] = false;
        }
        internal bool IsPositionSafe(int row, int col, out List<int[]> tempArr)
        {
            tempArr = new List<int[]>();
            for(int i = 0; i < _size; ++i)
            {
                tempArr.Add(new int[] { row, i });
                tempArr.Add(new int[] { i, row });
                if (_queensPositions[row, i] || _queensPositions[i, col])
                    return false;
            }
            
            for(int i = row, j = col; i < _size && j < _size; ++i, ++j)
            {
                tempArr.Add(new int[] { i, j });
                if (_queensPositions[i,j])
                    return false;
            }
            
            for(int i = row, j = col; i >= 0 && j >= 0; --i, --j)
            {
                tempArr.Add(new int[] { i, j });
                if (_queensPositions[i,j])
                    return false;
            }

            for(int i = row, j = col; i < _size && j >= 0; ++i, --j)
            {
                tempArr.Add(new int[] { i, j });
                if (_queensPositions[i,j])
                    return false;
            }

            for(int i = row, j = col; i >= 0 && j < _size; --i, ++j)
            {
                tempArr.Add(new int[] { i, j });
                if (_queensPositions[i,j])
                    return false;
            }
            
            return true;
        }
        public bool[][,] Solve()
        {
            List<bool[,]> solutions = new List<bool[,]>();

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    SolveQueens(j, i);
                    bool[,] temp = (bool[,])_queensPositions.Clone();
                    if (CalculateQueens(temp) == _size)
                        solutions.Add(temp);
                    GenerateMatrix(ref _chessMatrix);
                    GenerateMatrix(ref _queensPositions);
                }
            }

            return solutions.ToArray();
        }
        internal int CalculateQueens(bool[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (arr[i, j] == true) sum++;
                }
            }
            return sum;
        }
        internal void SolveQueens(int row, int col)
        {
            if (row == _size - 1 && col == _size - 1)
                return;
            int[] nextPos;
            if (_chessMatrix[row, col])
            {
                nextPos = NextPosition();
                if (nextPos.Length == 0) return;
                SolveQueens(nextPos[0], nextPos[1]);
                return;
            }
            List<int[]> lockedValues;
            if (IsPositionSafe(row, col, out lockedValues))
            {
                _queensPositions[row, col] = true;
                foreach (int[] pos in lockedValues)
                {
                    _chessMatrix[pos[0], pos[1]] = true;
                }
            }
            _chessMatrix[row, col] = true;

            nextPos = NextPosition();
            if (nextPos.Length == 0) return;
            SolveQueens(nextPos[0], nextPos[1]);
        }

        internal int[] NextPosition()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (!_chessMatrix[j, i])
                        return new int[] { j, i };
                }
            }

            return new int[0];
        }
    }
}