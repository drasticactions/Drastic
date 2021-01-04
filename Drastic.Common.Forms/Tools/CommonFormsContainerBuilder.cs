// <copyright file="CommonFormsContainerBuilder.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Drastic.Common.Forms.Tools;
using Drastic.Common.Interfaces;

namespace Drastic.Common.Tools
{
    /// <summary>
    /// Autofac Container Builder.
    /// </summary>
    public static class CommonFormsContainerBuilder
    {
        /// <summary>
        /// Builds Common Container.
        /// </summary>
        /// <param name="builder">Platform Specific Container.</param>
        /// <returns>IContainer.</returns>
        public static ContainerBuilder AddDefaultsToContainer(ContainerBuilder builder)
        {
            builder.RegisterType<NavigationHandler>().As<INavigationHandler>();
            builder.RegisterType<ErrorHandler>().As<IErrorHandler>();
            builder.RegisterType<ResourceHelper>().As<IResourceHelper>();
            return builder;
        }
    }
}
