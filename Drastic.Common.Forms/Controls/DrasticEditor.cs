// <copyright file="DrasticEditor.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using Drastic.Common.Forms.Tools;
using Drastic.Common.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Drastic.Common.Forms.Controls
{
    /// <summary>
    /// Drastic Editor.
    /// </summary>
    public class DrasticEditor : Editor, IDrasticEditor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrasticEditor"/> class.
        /// </summary>
        public DrasticEditor()
        {
            this.Text = string.Empty;
        }

        /// <inheritdoc/>
        public bool IsTextSelected => !string.IsNullOrEmpty(this.SelectedText);

        /// <summary>
        /// Gets or sets the selected text in a view.
        /// </summary>
        public string SelectedText { get; set; }

        /// <summary>
        /// Gets or sets the selected text start point.
        /// </summary>
        public int SelectedTextStart { get; set; }

        /// <summary>
        /// Gets or sets the selected text end point.
        /// </summary>
        public int SelectedTextEnd { get; set; }

        /// <summary>
        /// Gets or sets the selected text length.
        /// </summary>
        public int SelectedTextLength { get; set; }

        /// <summary>
        /// Update Text.
        /// </summary>
        /// <param name="content">Content to Update.</param>
        public void UpdateText(string content)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                // If user has selected text, replace it.
                // Or else, add it to whereever they have the cursor.
                if (this.IsTextSelected)
                {
                    this.Text = this.Text.ReplaceAt(this.SelectedTextStart, this.SelectedTextLength, content);
                }
                else
                {
                    this.Text = this.Text.Insert(this.SelectedTextStart, content);
                }
            });
        }

        /// <inheritdoc/>
        void IDrasticEditor.Focus()
        {
            Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() => this.Focus());
        }
    }
}
