namespace ApiComercial.Exceptions
{
    public class DuplicateResourceException : Exception
    {
        public DuplicateResourceException() { }
        public DuplicateResourceException(string message) : base(message) { }
        public DuplicateResourceException(string message, Exception inner) : base(message, inner) { }
    }
}
