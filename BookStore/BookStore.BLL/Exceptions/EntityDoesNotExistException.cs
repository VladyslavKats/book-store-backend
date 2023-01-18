using System.Runtime.Serialization;

namespace BookStore.BLL.Exceptions
{
    public class EntityDoesNotExistException : BookStoreException
    {
        public EntityDoesNotExistException()
        {
        }

        public EntityDoesNotExistException(string message) : base(message)
        {
        }

        public EntityDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
