using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace BookStore.BLL.Exceptions
{
    public class BookStoreException : Exception
    {
        public BookStoreException()
        {
        }

        public BookStoreException(string message) : base(message)
        {
        }

        public BookStoreException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BookStoreException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
