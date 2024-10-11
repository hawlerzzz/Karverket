namespace Karverket.Models
{
    public class EmailExists : Exception
    {
        public EmailExists(string message) : base(message)
        {
        }
    }

    public class WrongPassword : Exception
    {
        public WrongPassword(string message) : base(message)
        {
        }
    }
    public class ShortPassword : Exception
    {
        public ShortPassword(string message) : base(message)
        {
        }
    }
    public class ShortName : Exception
    {
        public ShortName(string message) : base(message)
        {
        }
    }
    public class UserDoesNotExist : Exception
    {
        public UserDoesNotExist(string message) : base(message)
        {
        }
    }

}
