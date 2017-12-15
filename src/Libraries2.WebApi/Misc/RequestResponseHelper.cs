﻿using System;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Xlent.Lever.Libraries2.WebApi.Misc
{
    /// <summary>
    /// Methods for handling requests and responses
    /// </summary>
    [Obsolete("The class has been renamed to HttpHelper.")]
    public class RequestResponseHelper
    {
        /// <summary>
        /// Create a string based on the <paramref name="request"/> that is adequate for logging.
        /// </summary>
        /// <returns></returns>
        [Obsolete("The class has been renamed to HttpHelper.")]
        public static string ToStringForLogging(HttpRequestMessage request)
        {
            return request == null ? null : $"{request.Method?.Method} {FilteredRequestUri(request.RequestUri)}";
        }

        /// <summary>
        /// Create a string based on the <paramref name="response"/> that is adequate for logging.
        /// </summary>
        /// <returns></returns>
        [Obsolete("The class has been renamed to HttpHelper.")]
        public static string ToStringForLogging(HttpResponseMessage response, TimeSpan elapsedTime = default(TimeSpan))
        {
            if (response == null) return null;
            var message = $"{ToStringForLogging(response.StatusCode)}";
            if (elapsedTime != default(TimeSpan))
            {
                message += $" | {elapsedTime}";
            }
            message += $" | {ToStringForLogging(response.RequestMessage)}";
            return message;
        }

        /// <summary>
        /// Create a string based on the <paramref name="statusCode"/> that is adequate for logging.
        /// </summary>
        /// <returns></returns>
        [Obsolete("The class has been renamed to HttpHelper.")]
        public static string ToStringForLogging(HttpStatusCode statusCode)
        {
            return $"{(int)statusCode} {statusCode}";
        }

        private static string FilteredRequestUri(Uri uri)
        {
            var url = uri.AbsoluteUri;
            if (string.IsNullOrWhiteSpace(url)) return "";
            var result = Regex.Replace(url, "(api_key=)[^&]+", match => match.Groups[1].Value + "hidden");
            return result;
        }
    }
}
