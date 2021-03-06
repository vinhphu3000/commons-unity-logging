﻿using System.Diagnostics;

namespace CreateAR.Commons.Unity.Logging
{
    /// <summary>
    /// Log target for diagnostics.
    /// </summary>
    public class DiagnosticsLogTarget : ILogTarget
    {
        /// <summary>
        /// Log formatter.
        /// </summary>
        private readonly ILogFormatter _formatter;

        /// <summary>
        /// Creates a new log target.
        /// </summary>
        /// <param name="formatter">A formatter with which to format logs.</param>
        public DiagnosticsLogTarget(ILogFormatter formatter)
        {
            _formatter = formatter;
        }

        /// <inheritdoc cref="ILogTarget"/>
        public void OnLog(LogLevel level, object caller, string message)
        {
            Debug.WriteLine(_formatter.Format(
                level,
                caller,
                message));
        }
    }
}