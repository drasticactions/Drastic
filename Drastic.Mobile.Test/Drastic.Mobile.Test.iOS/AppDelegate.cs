﻿// <copyright file="AppDelegate.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Drastic.Common.Interfaces;
using Drastic.Forms.iOS;
using Foundation;
using UIKit;

#pragma warning disable SA1300 // Element should begin with upper-case letter
namespace Drastic.Mobile.Test.iOS
#pragma warning restore SA1300 // Element should begin with upper-case letter
{
    /// <summary>
    /// The UIApplicationDelegate for the application. This class is responsible for launching the
    /// User Interface of the application, as well as listening (and optionally responding) to
    /// application events from iOS.
    /// </summary>
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        /// <inheritdoc/>
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            var builder = new ContainerBuilder();
            builder.RegisterType<iOSPlatformProperties>().As<IPlatformProperties>();
            this.LoadApplication(new App(builder));
            return base.FinishedLaunching(app, options);
        }
    }
}
