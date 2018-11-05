// <copyright file="ISingleInstanceApp.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Microsoft.Shell
{
    using System.Collections.Generic;

    /// <summary>
    /// ISingleInstanceApp interface.
    /// </summary>
    public interface ISingleInstanceApp
    {
        /// <summary>
        /// Interface Member for SignalExternalCommandlineArgs.
        /// </summary>
        /// <param name="args">List of Args.</param>
        /// <returns>true or false.</returns>
        bool SignalExternalCommandLineArgs(IList<string> args);
    }
}
