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

namespace Drastic.Forms.UWP.Tools
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
            builder.RegisterType<WindowsPlatformProperties>().As<IPlatformProperties>();
            return builder;
        }
    }
}
