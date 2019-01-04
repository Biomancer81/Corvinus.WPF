// <copyright file="ThemeEngine.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Presentation.Theme
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;

    /// <summary>
    /// ThemeEngine class.
    /// </summary>
    public static class ThemeEngine
    {
        /// <summary>
        /// Apply Theme By Uri.
        /// </summary>
        /// <param name="app">Current Application.</param>
        /// <param name="skinDictionaryUri">Uri to Theme.</param>
        public static void ApplyTheme(this Application app, Uri skinDictionaryUri)
        {
            ResourceDictionary skinDictionary = Application.LoadComponent(skinDictionaryUri) as ResourceDictionary;

            Collection<ResourceDictionary> mergedDictionaries = app.Resources.MergedDictionaries;

            if (mergedDictionaries.Count > 0)
            {
                mergedDictionaries.Clear();
            }

            mergedDictionaries.Add(skinDictionary);
        }
    }
}
