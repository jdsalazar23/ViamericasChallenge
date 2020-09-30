using System;
using System.Runtime.Serialization;

namespace ViamericasChallenge.Server.Common.Exceptions
{
    [Serializable]
    public class TokenException : Exception
    {
        private Exception e;

        public TokenException()
        {
        }

        public TokenException(Exception e)
        {
            this.e = e;
        }

        public TokenException(string message) : base(message)
        {
        }

        public TokenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TokenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}