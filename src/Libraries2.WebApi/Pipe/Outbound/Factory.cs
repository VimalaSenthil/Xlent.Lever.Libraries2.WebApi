﻿using System;
using System.Net.Http;
#pragma warning disable 1591

namespace Xlent.Lever.Libraries2.WebApi.Pipe.Outbound
{
    [Obsolete("Renamed. Please use OutboundPipeFactory.")]
    public static class Factory
    {
        /// <summary>
        /// Creates handlers to deal with Fulcrum specifics around making HTTP requests.
        /// </summary>
        /// <seealso cref="ThrowFulcrumExceptionOnFail"/>
        /// <seealso cref="AddCorrelationId"/>
        /// <returns>A list of recommended handlers.</returns>
        public static DelegatingHandler[] CreateDelegatingHandlers()
        {
            return new DelegatingHandler[]
            {
                new ThrowFulcrumExceptionOnFail(),
                new AddCorrelationId()
            };
        }
    }
}
