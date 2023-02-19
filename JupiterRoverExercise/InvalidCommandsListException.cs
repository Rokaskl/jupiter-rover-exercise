using System.Runtime.Serialization;

namespace JupiterRoverExercise
{
    [Serializable]
    public class InvalidCommandsListException : Exception
    {
        public InvalidCommandsListException()
        {
        }

        public InvalidCommandsListException(string? message) : base(message)
        {
        }

        public InvalidCommandsListException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidCommandsListException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}