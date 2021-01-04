// <copyright file="JsBridge.cs" company="Drastic Actions">
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
using Android.Webkit;
using Android.Widget;
using Drastic.Common.Forms.Controls;
using Java.Interop;

namespace Drastic.Forms.Android.Renderers
{
    /// <summary>
    /// Javascript Bridge.
    /// </summary>
    public class JsBridge : Java.Lang.Object
    {
        private readonly WeakReference<HybridWebViewRenderer> hybridWebViewMainRenderer;

        public JsBridge(HybridWebViewRenderer hybridRenderer)
        {
            this.hybridWebViewMainRenderer = new WeakReference<HybridWebViewRenderer>(hybridRenderer);
        }

        [JavascriptInterface]
        [Export("invokeAction")]
        public void InvokeAction(string data)
        {
            if (this.hybridWebViewMainRenderer != null && this.hybridWebViewMainRenderer.TryGetTarget(out var hybridRenderer))
            {
                ((HybridWebView)hybridRenderer.Element).InvokeAction(data);
            }
        }
    }
}