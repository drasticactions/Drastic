// <copyright file="DrasticFlyoutPage.xaml.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drastic.Common.Forms.Tools;
using Drastic.Common.Forms.ViewModels;
using Drastic.Common.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Drastic.Common.Forms.Pages
{
    /// <summary>
    /// Drastic Flyout Page.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrasticFlyoutPage : FlyoutPage
    {
        private FlyoutPageViewModel vm;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrasticFlyoutPage"/> class.
        /// </summary>
        /// <param name="menuItems">Menu Items.</param>
        /// <param name="error">Error Handler.</param>
        /// <param name="navigation">Navigation Handler.</param>
        /// <param name="footerMenu">Optional button for the footer.</param>
        public DrasticFlyoutPage(List<MainMenuItem> menuItems, IErrorHandler error, INavigationHandler navigation, MainMenuItem footerMenu = default)
        {
            this.InitializeComponent();
            this.Detail = new ContentPage();
            this.BindingContext = this.vm = new FlyoutPageViewModel(this, menuItems, footerMenu, error, navigation);
            this.Flyout.BindingContext = this.vm;
        }
    }
}