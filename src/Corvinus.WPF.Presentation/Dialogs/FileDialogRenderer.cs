// <copyright file="FileDialogRenderer.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Presentation.Dialogs
{
    using System.Collections.Generic;
    using Corvinus.WPF.Presentation.Windows;
    using Microsoft.Win32;

    /// <summary>
    /// FileDialogRenderer class.
    /// </summary>
    public sealed class FileDialogRenderer : IFileDialogRenderer
    {
        /// <summary>
        /// Dialog owner window provider.
        /// </summary>
        private readonly IWindowProvider ownerWindowProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileDialogRenderer"/> class.
        /// </summary>
        /// <param name="ownerWindowProvider">Dialog owner window provider.</param>
        internal FileDialogRenderer(IWindowProvider ownerWindowProvider)
        {
            this.ownerWindowProvider = ownerWindowProvider;
        }

        /// <summary>
        /// Shows "Open File" dialog.
        /// </summary>
        /// <param name="title">Dialog title.</param>
        /// <param name="defaultExtension">Default file extension.</param>
        /// <param name="filters">The list of file filters represented as pairs of (filter caption, file extension).</param>
        /// <returns>Selected file path or null if none selected.</returns>
        public string OpenFile(string title, string defaultExtension, IEnumerable<(string, string)> filters)
        {
            string filterString = string.Empty;

            foreach (var f in filters)
            {
                if (!string.IsNullOrEmpty(filterString))
                {
                    filterString += "|";
                }

                filterString += $"{f.Item1}|{f.Item2}";
            }

            return this.OpenFileInternal(title, defaultExtension, filterString);
        }

        /// <summary>
        /// Shows "Open File" dialog.
        /// </summary>
        /// <param name="title">Dialog title.</param>
        /// <param name="defaultExtension">Default file extension.</param>
        /// <param name="defaultFilterName">Default file extension name.</param>
        /// <returns>Selected file path or null if none selected.</returns>
        public string OpenFile(string title, string defaultExtension, string defaultFilterName)
        {
            return this.OpenFileInternal(
                title,
                defaultExtension,
                $"{defaultFilterName} |*{defaultExtension}|All Files (*.*)|*.*");
        }

        /// <summary>
        /// Shows "Save File" dialog.
        /// </summary>
        /// <param name="title">Dialog title.</param>
        /// <param name="defaultExtension">Default file extension.</param>
        /// <param name="defaultFilterName">Default file extension name.</param>
        /// <param name="defaultFileName">Default file name.</param>
        /// <returns>Selected file path or null if none selected.</returns>
        public string SaveFile(
            string title,
            string defaultExtension,
            string defaultFilterName,
            string defaultFileName = null)
        {
            var dlg = new Microsoft.Win32.SaveFileDialog
            {
                Title = title,
                DefaultExt = defaultExtension,
                Filter = $"{defaultFilterName} |*{defaultExtension}|All Files (*.*)|*.*",
                FileName = defaultFileName,
            };

            if (dlg.ShowDialog(this.ownerWindowProvider.Window) != true)
            {
                return null;
            }

            return dlg.FileName;
        }

        /// <summary>
        /// Shows "Open File" dialog.
        /// </summary>
        /// <param name="title">Dialog title.</param>
        /// <param name="defaultExtension">Default file extension.</param>
        /// <param name="filter">File filter.</param>
        /// <returns>Selected file path or null if none selected.</returns>
        private string OpenFileInternal(string title, string defaultExtension, string filter)
        {
            var dlg = new OpenFileDialog
            {
                Title = title,
                DefaultExt = defaultExtension,
                Filter = filter,
            };

            if (dlg.ShowDialog(this.ownerWindowProvider.Window) != true)
            {
                return null;
            }

            return dlg.FileName;
        }
    }
}
