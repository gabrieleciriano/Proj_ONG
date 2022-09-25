using System;
using System.Runtime.Serialization;

namespace Proj_ONG
{
    [Serializable]
    internal class SqlExeption : Exception
    {
        public SqlExeption()
        {
        }

        public SqlExeption(string message) : base(message)
        {
        }

        public SqlExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SqlExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}