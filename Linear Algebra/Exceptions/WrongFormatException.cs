using System;

namespace Linear_Algebra.Exceptions
{
    /// <summary>
    /// Exception used to indicate illegal matrix operations on matrices that do not 
    /// match the formats that are needed to perform certain mathematical operations.
    /// </summary>
    [Serializable]
    class WrongFormatException : Exception
    {
        /// <summary>
        /// Constructor with a message
        /// </summary>
        /// <param name="message"></param>
        public WrongFormatException(string message) : base(message)
        {
        }
    }
}
