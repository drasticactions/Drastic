// <copyright file="CommonContainerBuilder.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Drastic.Common.Interfaces;

namespace Drastic.Common.Tools
{
    /// <summary>
    /// Autofac Container Builder.
    /// </summary>
    public static class CommonContainerBuilder
    {
        /// <summary>
        /// Builds SocialMediaApp Container.
        /// </summary>
        /// <param name="builder">Platform Specific Container.</param>
        /// <returns>IContainer.</returns>
        public static ContainerBuilder AddDefaultsToContainer(ContainerBuilder builder)
        {
            return builder;
        }
    }
}
