// <copyright file="HybridWebViewRenderer.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using Android.Content;
using Android.Graphics;
using Drastic.Common.Forms.Controls;
using Drastic.Forms.Android.Renderers;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]

namespace Drastic.Forms.Android.Renderers
{
    /// <summary>
    /// Hybrid WebView Renderer.
    /// </summary>
    public class HybridWebViewRenderer : WebViewRenderer
    {
        private const string JavascriptFunction = "function invokeCSharpAction(data){jsBridge.invokeAction(data);}";
        private readonly Context context;

        /// <summary>
        /// Initializes a new instance of the <see cref="HybridWebViewRenderer"/> class.
        /// </summary>
        /// <param name="context">Android Context.</param>
        public HybridWebViewRenderer(Context context)
            : base(context)
        {
            this.context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);

            if (e == null)
            {
                return;
            }

            // Setting the background as transparent
            this.Control.SetBackgroundColor(Color.Transparent);

            if (e.OldElement != null)
            {
                this.Control.RemoveJavascriptInterface("jsBridge");
                ((HybridWebView)this.Element).Cleanup();
            }

            if (e.NewElement != null)
            {
                this.Control.SetWebViewClient(new JavascriptWebViewClient($"javascript: {JavascriptFunction}"));
                this.Control.AddJavascriptInterface(new JsBridge(this), "jsBridge");
            }
        }
    }
}