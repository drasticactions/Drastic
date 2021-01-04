// <copyright file="HybridWebView.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using Drastic.Common.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Drastic.Common.Forms.Controls
{
    /// <summary>
    /// Hybrid WebView.
    /// </summary>
    public class HybridWebView : WebView, IDrasticWebView
    {
        private Action<string> action;

        /// <summary>
        /// Register Javascript Action.
        /// </summary>
        /// <param name="callback">Callback.</param>
        public void RegisterAction(Action<string> callback)
        {
            this.action = callback;
        }

        /// <summary>
        /// Cleanup Javascript Action.
        /// </summary>
        public void Cleanup()
        {
            this.action = null;
        }

        /// <summary>
        /// Invoke Action.
        /// </summary>
        /// <param name="data">Data used to invoke.</param>
        public void InvokeAction(string data)
        {
            if (this.action == null || data == null)
            {
                return;
            }

            this.action.Invoke(data);
        }

        /// <inheritdoc/>
        public void SetSource(string html)
        {
            var source = new HtmlWebViewSource();
            source.Html = html;
            MainThread.BeginInvokeOnMainThread(() => this.Source = source);
        }
    }
}
