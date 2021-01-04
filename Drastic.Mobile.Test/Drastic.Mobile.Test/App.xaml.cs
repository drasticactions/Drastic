// <copyright file="App.xaml.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Autofac;
using Drastic.Common.Forms;
using Drastic.Common.Forms.Pages;
using Drastic.Common.Forms.Tools;
using Drastic.Common.Forms.ViewModels;
using Drastic.Common.Interfaces;
using Drastic.Mobile.Test.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Drastic.Mobile.Test
{
    /// <summary>
    /// Test Application.
    /// </summary>
    public partial class App : DrasticApp
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        /// <param name="builder">Container Builder.</param>
        public App(ContainerBuilder builder)
            : base(builder)
        {
        }

        /// <inheritdoc/>
        protected override void SetInitialMainPage()
        {
            var navigation = Container.Resolve<INavigationHandler>();
            var resources = Container.Resolve<IResourceHelper>();
            var error = Container.Resolve<IErrorHandler>();
            var settings = new MainMenuItem()
            {
                Title = "Settings",
                Page = new SettingsPage(),
                IconImageSource = ImageSourceHelper.GenerateFontImageSource("FontAwesomeSolid", ""),
            };

            navigation.SetMainAppPage(new DrasticFlyoutPage(GenerateMenuItems(), error, navigation, settings));
        }

        /// <inheritdoc/>
        protected override void OnStart()
        {
            this.SetInitialMainPage();
        }

        /// <inheritdoc/>
        protected override void OnSleep()
        {
        }

        /// <inheritdoc/>
        protected override void OnResume()
        {
        }

        private static List<MainMenuItem> GenerateMenuItems()
        {
            return new List<MainMenuItem>()
            {
                new MainMenuItem()
                {
                    Title = "Main Page",
                    Page = new MainPage(),
                    IconImageSource = ImageSourceHelper.GenerateFontImageSource("FontAwesomeSolid", ""),
                },
            };
        }
    }
}
