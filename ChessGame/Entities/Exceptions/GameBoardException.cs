using System;

namespace ChessGame.Entities.Exceptions
{
    class GameBoardException : ApplicationException
    {
        public GameBoardException(string message) : base (message)
        {
        }
    }
}
