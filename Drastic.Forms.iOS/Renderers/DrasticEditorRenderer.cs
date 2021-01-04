// <copyright file="DrasticEditorRenderer.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drastic.Common.Forms.Controls;
using Drastic.Forms.iOS.Renderers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(DrasticEditor), typeof(DrasticEditorRenderer))]

#pragma warning disable SA1300 // Element should begin with upper-case letter
namespace Drastic.Forms.iOS.Renderers
#pragma warning restore SA1300 // Element should begin with upper-case letter
{
    /// <summary>
    /// Awful Editor Renderer.
    /// </summary>
    public class DrasticEditorRenderer : EditorRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrasticEditorRenderer"/> class.
        /// </summary>
        public DrasticEditorRenderer()
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
                if (this.TextView != null)
                {
                    this.TextView.SelectionChanged += this.TextView_SelectionChanged;
                }
            }
            else
            {
                if (this.TextView != null)
                {
                    this.TextView.SelectionChanged -= this.TextView_SelectionChanged;
                }
            }
        }

        private void TextView_SelectionChanged(object sender, System.EventArgs e)
        {
            if (this.Element is DrasticEditor editor)
            {
                var start = this.TextView.GetOffsetFromPosition(this.TextView.BeginningOfDocument, this.TextView.SelectedTextRange.Start);
                var end = this.TextView.GetOffsetFromPosition(this.TextView.BeginningOfDocument, this.TextView.SelectedTextRange.End);
                editor.SelectedTextStart = (int)start;
                editor.SelectedTextEnd = (int)end;
                editor.SelectedTextLength = (int)(end - start);
                editor.SelectedText = this.TextView.TextInRange(this.TextView.SelectedTextRange);
            }
        }
    }
}