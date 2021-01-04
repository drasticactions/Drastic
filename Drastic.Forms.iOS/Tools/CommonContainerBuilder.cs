// <copyright file="CommonContainerBuilder.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Drastic.Common.Interfaces;

#pragma warning disable SA1300 // Element should begin with upper-case letter
namespace Drastic.Forms.iOS.Tools
#pragma warning restore SA1300 // Element should begin with upper-case letter
{
    /// <summary>
    /// Autofac Container Builder.
    /// </summary>
    public static class CommonContainerBuilder
    {
        /// <summary>
        /// Builds Common Container.
        /// </summary>
        /// <param name="builder">Platform Specific Container.</param>
        /// <returns>IContainer.</returns>
        public static ContainerBuilder AddDefaultsToContainer(ContainerBuilder builder)
        {
            builder.RegisterType<iOSPlatformProperties>().As<IPlatformProperties>();
            return builder;
        }
    }
}
