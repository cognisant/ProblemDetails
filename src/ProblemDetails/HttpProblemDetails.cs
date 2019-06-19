// <copyright file="HttpProblemDetails.cs" company="Cognisant Research">
// Copyright (c) Cognisant Research. All rights reserved.
// </copyright>

namespace CR.ProblemDetails
{
    using System;

    /// <inheritdoc cref="IHttpProblemDetails" />
    public struct HttpProblemDetails : IHttpProblemDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpProblemDetails"/> struct, which represents a problem which occurred while fulfilling a HTTP request.
        /// </summary>
        /// <param name="type">A <see cref="Uri"/> reference which identifies the problem type.</param>
        /// <param name="instance">A <see cref="Uri"/> reference which identifies the specific occurrence of the problem.</param>
        /// <param name="title">A short, human-readable title for the problem (not specific to this instance).</param>
        /// <param name="detail">A human-readable explanation of the problem, specific to this instance of it.</param>
        /// <param name="status">The HTTP status code associated with the <see cref="HttpProblemDetails"/>.</param>
        public HttpProblemDetails(Uri type, Uri instance, string title, string detail, int status)
        {
            Detail = string.IsNullOrWhiteSpace(detail)
                ? throw new ArgumentException($"The {nameof(detail)} used to initialize a {nameof(HttpProblemDetails)} was null, empty or whitespace.", nameof(detail))
                : detail;

            Title = string.IsNullOrWhiteSpace(title)
                ? throw new ArgumentException($"The {nameof(title)} used to initialize a {nameof(HttpProblemDetails)} was null, empty or whitespace.", nameof(title))
                : title;

            Instance = instance
                ?? throw new ArgumentNullException(nameof(instance), $"The {nameof(instance)} {nameof(Uri)} used to initialize a {nameof(HttpProblemDetails)} was null.");

            Type = type ?? new Uri("about:blank");
            Status = status;
        }

        /// <inheritdoc />
        public int Status { get; }

        /// <inheritdoc />
        public string Detail { get; }

        /// <inheritdoc />
        public string Title { get; }

        /// <inheritdoc />
        public Uri Instance { get; }

        /// <inheritdoc />
        public Uri Type { get; }
    }
}
