// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TechnicalException.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.Common.Exeptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TechnicalException : Exception
    {
        public string TramaBroker { get; }

        public TechnicalException(string message) : base(message)
        {
        }

        public TechnicalException(string message, string tramaBroker) : base(message)
        {
            TramaBroker = tramaBroker == null ? string.Empty : tramaBroker;
        }

        public TechnicalException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TechnicalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TechnicalException()
        {
        }
    }
}
