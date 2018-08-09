// <copyright file="HttpProblemDetails.cs" company="Cognisant Research">
// Copyright (c) Cognisant Research. All rights reserved.
// </copyright>

namespace CR.ProblemDetails
{
    using System;
    using System.Net;

    /// <summary>
    /// A description of a problem which occurred while fulfilling a HTTP request.
    /// </summary>
    public struct HttpProblemDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpProblemDetails"/> struct, which represents a problem which occurred while fulfilling a HTTP request.
        /// </summary>
        /// <param name="type">A <see cref="Uri"/> reference which identifies the problem type.</param>
        /// <param name="instance">A <see cref="Uri"/> reference which identifies the specific occurrence of the problem.</param>
        /// <param name="title">A short, human-readable title for the problem (not specific to this instance).</param>
        /// <param name="detail">A human-readable explanation of the problem, specific to this instance of it.</param>
        /// <param name="status">The <see cref="HttpStatusCode"/> associated with the <see cref="HttpProblemDetails"/>.</param>
        public HttpProblemDetails(Uri type, Uri instance, string title, string detail, HttpStatusCode status)
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

        /// <summary>
        /// Gets the <see cref="HttpStatusCode"/> which describes the problem which occurred while fulfilling a HTTP request.
        /// </summary>
        public HttpStatusCode Status { get; }

        /// <summary>
        /// Gets a human-readable explanation specific to this occurrence of the problem.
        /// </summary>
        public string Detail { get; }

        /// <summary>
        /// Gets a short, human-readable summary of the problem type. It should not change from occurrence to occurrence of the
        /// problem, except for purposes of localization(e.g., using proactive content negotiation).
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets a <see cref="Uri"/> reference that identifies the specific occurrence of the problem.
        /// It may or may not yield further information if dereferenced.
        /// </summary>
        public Uri Instance { get; }

        /// <summary>
        /// Gets a <see cref="Uri"/> reference that identifies the problem type. This specification encourages that, when dereferenced,
        /// it provide human-readable documentation for the problem type (e.g., using HTML).
        /// </summary>
        /// <remarks>
        /// When this member is not present, its value is assumed to be "about:blank".
        /// </remarks>
        public Uri Type { get; }
    }
}
