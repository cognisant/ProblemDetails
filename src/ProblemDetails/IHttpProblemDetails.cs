// <copyright file="IHttpProblemDetails.cs" company="Cognisant Research">
// Copyright (c) Cognisant Research. All rights reserved.
// </copyright>

namespace CR.ProblemDetails
{
    using System;

    /// <summary>
    /// A description of a problem which occurred while fulfilling a HTTP request.
    /// </summary>
    public interface IHttpProblemDetails
    {
        /// <summary>
        /// Gets the HTTP status code which describes the problem which occurred while fulfilling a HTTP request.
        /// </summary>
        /// <remarks>
        /// If the provided status code is not supported by the consuming framework, it will default to InternalServerError.
        /// </remarks>
        int Status { get; }

        /// <summary>
        /// Gets a human-readable explanation specific to this occurrence of the problem.
        /// </summary>
        string Detail { get; }

        /// <summary>
        /// Gets a short, human-readable summary of the problem type. It should not change from occurrence to occurrence of the
        /// problem, except for purposes of localization(e.g., using proactive content negotiation).
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets a <see cref="Uri"/> reference that identifies the specific occurrence of the problem.
        /// It may or may not yield further information if dereferenced.
        /// </summary>
        Uri Instance { get; }

        /// <summary>
        /// Gets a <see cref="Uri"/> reference that identifies the problem type. This specification encourages that, when dereferenced,
        /// it provide human-readable documentation for the problem type (e.g., using HTML).
        /// </summary>
        /// <remarks>
        /// When this member is not present, its value is assumed to be "about:blank".
        /// </remarks>
        Uri Type { get; }
    }
}
