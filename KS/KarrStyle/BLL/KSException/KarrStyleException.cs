using System;
using System.Runtime.Serialization;

namespace KarrStyle.BLL.KSException
{
    public class KarrStyleException : ApplicationException, ISerializable
    {
        #region public enum
        public enum ExceptionLevel
        {
            None,
            System,
            Critical,
            Error,
            Warning,
            Information
        }

        #endregion

        #region auto public properties
        public ExceptionLevel Level
        {
            get;
            set;
        }

        public string UserFriendlyMessage
        {
            get;
            set;
        }

        #endregion

        #region Public Methods
        public KarrStyleException(string userFriendlyMessage, string message, ExceptionLevel level) : base(message)
		{
            Level = level;
            UserFriendlyMessage = userFriendlyMessage;
		}
        public KarrStyleException(string userFriendlyMessage, System.Exception innerException, ExceptionLevel level)
            : base(innerException.Message, innerException)
		{
            Level = level;
            UserFriendlyMessage = userFriendlyMessage;
		}
        public KarrStyleException(string userFriendlyMessage, string message, System.Exception innerException, ExceptionLevel level)
            : base(message, innerException)
		{
            Level = level;
            UserFriendlyMessage = userFriendlyMessage;
		}
		
        #endregion
    }
}
