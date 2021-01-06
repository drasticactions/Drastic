// <copyright file="DrasticApp.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Autofac;
using Drastic.Common.Interfaces;
using Xamarin.Forms;

namespace Drastic.Common.Forms
{
    /// <summary>
    /// Drastic App.
    /// </summary>
    public class DrasticApp : Application
    {
        /// <summary>
        /// Autofac Container.
        /// </summary>
#pragma warning disable CA2211 // Non-constant fields should not be visible
#pragma warning disable SA1401 // Fields should be private
        public static IContainer Container;
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore CA2211 // Non-constant fields should not be visible

        /// <summary>
        /// Initializes a new instance of the <see cref="DrasticApp"/> class.
        /// </summary>
        /// <param name="builder">Container Builder.</param>
        public DrasticApp(ContainerBuilder builder)
        {
            Device.SetFlags(new string[] { "MediaElement_Experimental", "Shell_UWP_Experimental", "AppTheme_Experimental", "CollectionView_Experimental", "Shapes_Experimental" });
            builder = Drastic.Common.Tools.CommonContainerBuilder.AddDefaultsToContainer(builder);
            builder = Drastic.Common.Tools.CommonFormsContainerBuilder.AddDefaultsToContainer(builder);
            Container = builder.Build();
            this.MainPage = new ContentPage();
#if DEBUG
            Xamarin.Forms.Xaml.Diagnostics.VisualDiagnostics.VisualTreeChanged += this.VisualDiagnostics_VisualTreeChanged;
#endif
        }

        /// <summary>
        /// Sets initial page on Drastic App load.
        /// </summary>
        protected virtual void SetInitialMainPage()
        {
        }

        /// <inheritdoc/>
        protected override void OnStart()
        {
            base.OnStart();
        }

        private void VisualDiagnostics_VisualTreeChanged(object sender, Xamarin.Forms.Xaml.Diagnostics.VisualTreeChangeEventArgs e)
        {
            var parentSourInfo = Xamarin.Forms.Xaml.Diagnostics.VisualDiagnostics.GetXamlSourceInfo(e.Parent);
            var childSourInfo = Xamarin.Forms.Xaml.Diagnostics.VisualDiagnostics.GetXamlSourceInfo(e.Child);
            Debug.WriteLine($"VisualTreeChangeEventArgs {e.ChangeType}:" +
                $"{e.Parent}:{parentSourInfo?.SourceUri}:{parentSourInfo?.LineNumber}:{parentSourInfo?.LinePosition}-->" +
                $" {e.Child}:{childSourInfo?.SourceUri}:{childSourInfo?.LineNumber}:{childSourInfo?.LinePosition}");
        }
    }
}
