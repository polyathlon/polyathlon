namespace Polyathlon.Db.Common; 

/// <summary>
/// The exception that is thrown when Connection to CouchDB return an error.
/// </summary>
internal class ConnectException : Exception {
    public string? Reason { get; }

    public ConnectException() { }

    public ConnectException(string message) : base(message) { }

    public ConnectException(string message, Exception? innerException) : base(message, innerException) { }

    public ConnectException(string message, Exception? innerException, string reason) : base(message, innerException) {
        Reason = reason;
    }           
}