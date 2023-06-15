namespace Polyathlon.Db.Common;

/// <summary>
/// The database-independent exception used in Data Layer and View Model Layer to handle database errors.
/// </summary>
public class DbException : Exception
{
    public string? Reason { get; }

    public DbException()
    { }

    public DbException(string message) : base(message)
    {
    }

    public DbException(string message, Exception? innerException) : base(message, innerException)
    {
    }

    public DbException(string message, Exception? innerException, string reason) : base(message, innerException)
    {
        Reason = reason;
    }
}