// <copyright file="StringHelpers.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace Drastic.Common.Forms.Tools
{
    /// <summary>
    /// String Helpers.
    /// </summary>
    public static class StringHelpers
    {
        /// <summary>
        /// Replace String at indexes.
        /// </summary>
        /// <param name="str">The source string.</param>
        /// <param name="index">the start location to replace at (0-based).</param>
        /// <param name="length">The number of characters to be removed before inserting.</param>
        /// <param name="replace">The string that is replacing characters.</param>
        /// <returns>New string.</returns>
        public static string ReplaceAt(this string str, int index, int length, string replace)
        {
            return str.Remove(index, Math.Min(length, str.Length - index))
                    .Insert(index, replace);
        }
    }
}
