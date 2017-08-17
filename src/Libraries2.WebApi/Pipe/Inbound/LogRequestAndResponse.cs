﻿using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xlent.Lever.Libraries2.Core.Logging.Model;

namespace Xlent.Lever.Libraries2.WebApi.Pipe.Inbound
{
    /// <summary>
    /// Logs requests and responses in the pipe
    /// </summary>
    public class LogRequestAndResponse : DelegatingHandler
    {
        private readonly IFulcrumLogger _logHandler;

        /// <summary>
        /// Creates the handler based on a <see cref="IFulcrumLogger"/>.
        /// </summary>
        /// <param name="logHandler"></param>
        public LogRequestAndResponse(IFulcrumLogger logHandler)
        {
            _logHandler = logHandler;
        }

        /// <inheritdoc />
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                await LogRequest(request);
            }
            catch (Exception)
            {
                // Ignore, don't interrupt request if logging fails
            }

            var timer = new Stopwatch();
            timer.Start();
            var response = await base.SendAsync(request, cancellationToken);
            timer.Stop();

            try
            {
                await LogResponse(response, timer.Elapsed);
            }
            catch (Exception)
            {
                // Ignore, don't interrupt request if logging fails
            }

            return response;
        }

        private async Task LogRequest(HttpRequestMessage request)
        {
            var message = $"REQUEST: {request?.Method?.Method} {request?.RequestUri}";
            await _logHandler.LogAsync(LogSeverityLevel.Information, message);
        }

     
        private async Task LogResponse(HttpResponseMessage response, TimeSpan timerElapsed)
        {
            var message = $"RESPONSE: Url: {response?.RequestMessage?.RequestUri}" +
                          $" | StatusCode: {response?.StatusCode}" +
                          $" | ElapsedTime: {timerElapsed}";
            await _logHandler.LogAsync(LogSeverityLevel.Information, message);
        }
    }
}