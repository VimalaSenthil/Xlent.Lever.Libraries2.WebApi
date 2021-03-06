﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using Xlent.Lever.Libraries2.Core.Context;

namespace Xlent.Lever.Libraries2.WebApi.Pipe.Outbound
{
    /// <summary>
    /// A factory class to create delegating handlers for outgoing HTTP requests.
    /// </summary>
    public static class OutboundPipeFactory
    {

        /// <summary>
        /// Creates handlers to deal with Fulcrum specifics around making HTTP requests.
        /// </summary>
        /// <seealso cref="ThrowFulcrumExceptionOnFail"/>
        /// <seealso cref="AddCorrelationId"/>
        /// <seealso cref="LogRequestAndResponse"/>
        /// <returns>A list of recommended handlers.</returns>
        public static DelegatingHandler[] CreateDelegatingHandlers()
        {
            return CreateDelegatingHandlers(true);
        }

        /// <summary>
        /// Creates handlers to deal with Fulcrum specifics around making HTTP requests, but without any logging
        /// </summary>
        /// <seealso cref="ThrowFulcrumExceptionOnFail"/>
        /// <seealso cref="AddCorrelationId"/>
        /// <returns>A list of recommended handlers.</returns>
        public static DelegatingHandler[] CreateDelegatingHandlersWithoutLogging()
        {
            return CreateDelegatingHandlers(false);
        }


        private static DelegatingHandler[] CreateDelegatingHandlers(bool withLogging)
        {
            var handlers = new List<DelegatingHandler>
            {
                new ThrowFulcrumExceptionOnFail(),
                new AddCorrelationId()
            };
            if (withLogging)
            {
                handlers.Add(new LogRequestAndResponse());
            }
            return handlers.ToArray();
        }

        [Obsolete("Use overload with no parameters", true)]
#pragma warning disable 1591
        public static DelegatingHandler[] CreateDelegatingHandlers(IValueProvider valueProvider)
#pragma warning restore 1591
        {
            return CreateDelegatingHandlers();
        }
    }
}
