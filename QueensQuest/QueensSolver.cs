
namespace QueensQuest
{
    public class QueensSolver
    {
        private bool[,] _chessMatrix;
        private int _size;
        public QueensSolver(int size)
        {
            _size = size;
            GenerateMatrix();
        }
        private void GenerateMatrix()
        {
            _chessMatrix = new bool[_size, _size];
            for(int i = 0; i < _size; i++)
                for(int j = 0; j < _size; j++)
                    _chessMatrix[i,j] = false;
        }
        private bool IsPositionSafe(int row, int col)
        {
            for(int i = 0; i < _size; ++i)
                if(_chessMatrix[row, i] || _chessMatrix[i, col])
                    return false;
            
            for(int i = row, j = col; i < _size && j < _size; ++i, ++j)
                if(_chessMatrix[i,j])
                    return false;
            
            for(int i = row, j = col; i >= 0 && j >= 0; --i, --j)
                if(_chessMatrix[i,j])
                    return false;

            for(int i = row, j = col; i < _size && j >= 0; ++i, --j)
                if(_chessMatrix[i,j])
                    return false;

            for(int i = row, j = col; i >= 0 && j < _size; --i, ++j)
                if(_chessMatrix[i,j])
                    return false;
            
            return true;
        }
    }
}