// <copyright file="ISearchPage.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace Drastic.Common.Interfaces
{
    /// <summary>
    /// Search Page Interface.
    /// </summary>
    public interface ISearchPage
    {
        /// <summary>
        /// Search Bar Text Changed.
        /// </summary>
        event EventHandler<string> SearchBarTextChanged;

        /// <summary>
        /// On Search Bar Text Changed.
        /// </summary>
        /// <param name="text">Text that changed.</param>
        void OnSearchBarTextChanged(in string text);
    }
}
