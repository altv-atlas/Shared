using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace AltV.Atlas.Shared.Extensions;

/// <summary>
/// A class that contains some useful methods for tasks
/// </summary>
public static class TaskExtensions
{
    /// <summary>
    /// Ensures task exceptions are handled properly
    /// Thanks deluvas &lt;3
    /// </summary>
    /// <param name="task">The task that throws the exception</param>
    /// <param name="logger">A logger instance</param>
    /// <param name="error">An additional error message to show in console</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void HandleException(this Task task, ILogger logger, string error)
    {
        task.ContinueWith(t =>
        {
            if (!t.IsFaulted) return;
            logger.LogError(t.Exception, "Task faulted with error: {ErrorMessage}", error);
        });
    }
}