// <copyright file="DrasticEditorRenderer.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Drastic.Common.Forms.Controls;
using Drastic.Forms.Android.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(DrasticEditor), typeof(DrasticEditorRenderer))]

namespace Drastic.Forms.Android.Renderers
{
    /// <summary>
    /// Awful Editor Renderer.
    /// </summary>
    public class DrasticEditorRenderer : EditorRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrasticEditorRenderer"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        public DrasticEditorRenderer(Context context)
            : base(context)
        {
        }

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
                    this.Control.LayoutChange += this.Control_LayoutChange;
                }
            }
            else
            {
                if (this.EditText != null)
                {
                    this.Control.LayoutChange -= this.Control_LayoutChange;
                }
            }
        }

        private void Control_LayoutChange(object sender, LayoutChangeEventArgs e)
        {
            if (this.Element is DrasticEditor editor && this.Control != null)
            {
                int start = this.Control.SelectionStart;
                int end = this.Control.SelectionEnd;
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