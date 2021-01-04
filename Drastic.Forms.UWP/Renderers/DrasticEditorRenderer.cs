// <copyright file="DrasticEditorRenderer.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drastic.Common.Forms.Controls;
using Windows.UI.Xaml;
using Xamarin.Forms.Platform.UWP;

namespace Drastic.Forms.UWP.Renderers
{
    /// <summary>
    /// Drastic Editor Renderer.
    /// </summary>
    public class DrasticEditorRenderer : EditorRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrasticEditorRenderer"/> class.
        /// </summary>
        public DrasticEditorRenderer()
            : base()
        {
        }

        /// <inheritdoc/>
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Editor> e)
        {
            base.OnElementChanged(e);

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (e.NewElement is not null and DrasticEditor)
            {
                if (this.Control != null)
                {
                    this.Control.SelectionChanged += this.SelectionChanged;
                }
            }
            else
            {
                if (this.Control != null)
                {
                    this.Control.SelectionChanged -= this.SelectionChanged;
                }
            }
        }

        private void SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (this.Element is DrasticEditor editor && this.Control != null)
            {
                int start = this.Control.SelectionStart;
                int end = this.Control.SelectionStart + this.Control.SelectionLength;
                int selectionLength = end - start;
                if (end > 0 && end > start)
                {
                    string selection = this.Control.Text.Substring(start, selectionLength);
                    editor.SelectedTextStart = start;
                    editor.SelectedTextEnd = end;
                    editor.SelectedTextLength = selectionLength;
                    editor.SelectedText = selection;
                }
            }
        }
    }
}
