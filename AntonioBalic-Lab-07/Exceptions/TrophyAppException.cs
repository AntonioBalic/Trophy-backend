namespace AntonioBalic_Lab_07.Exceptions
{
    public class TrophyAppException : Exception
    {
        public TrophyAppException(string message) : base(message)
        {
        }
    }

    public class TrophyAppException_UserError : TrophyAppException
    {
        public TrophyAppException_UserError(string message) : base(message)
        {
        }
    }

    public class TrophyAppException_InternalError : TrophyAppException
    {
        TrophyAppException_InternalError(string message) : base(message)
        {
        }
    }
}
