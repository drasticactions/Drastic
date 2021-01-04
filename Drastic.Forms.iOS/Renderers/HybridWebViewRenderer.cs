// <copyright file="HybridWebViewRenderer.cs" company="Drastic Actions">
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
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]

#pragma warning disable SA1300 // Element should begin with upper-case letter
namespace Drastic.Forms.iOS.Renderers
#pragma warning restore SA1300 // Element should begin with upper-case letter
{
    /// <summary>
    /// Hybrid WebView Renderer.
    /// </summary>
    public class HybridWebViewRenderer : WkWebViewRenderer, IWKScriptMessageHandler
    {
        private const string JavaScriptFunction = "function invokeCSharpAction(data){window.webkit.messageHandlers.invokeAction.postMessage(data);}";
        private WKUserContentController userController;

        /// <summary>
        /// Initializes a new instance of the <see cref="HybridWebViewRenderer"/> class.
        /// </summary>
        public HybridWebViewRenderer()
            : this(new WKWebViewConfiguration())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HybridWebViewRenderer"/> class.
        /// </summary>
        /// <param name="config">WKWebViewConfiguration.</param>
        public HybridWebViewRenderer(WKWebViewConfiguration config)
            : base(config)
        {
            if (config == null)
            {
                throw new System.ArgumentNullException(nameof(config));
            }

            this.userController = config.UserContentController;
            using var script = new WKUserScript(new NSString(JavaScriptFunction), WKUserScriptInjectionTime.AtDocumentEnd, false);
            this.userController.AddUserScript(script);
            this.userController.AddScriptMessageHandler(this, "invokeAction");
        }

        /// <inheritdoc/>
        public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
        {
            if (message == null)
            {
                throw new System.ArgumentNullException(nameof(message));
            }

            ((HybridWebView)this.Element).InvokeAction(message.Body.ToString());
        }

        /// <inheritdoc/>
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e == null)
            {
                throw new System.ArgumentNullException(nameof(e));
            }

            // Setting the background as transparent
            this.Opaque = false;
            this.BackgroundColor = Color.Transparent.ToUIColor();

            if (e.OldElement != null)
            {
                this.userController.RemoveAllUserScripts();
                this.userController.RemoveScriptMessageHandler("invokeAction");
                HybridWebView hybridWebViewMain = e.OldElement as HybridWebView;
                hybridWebViewMain?.Cleanup();
            }
        }
    }
}