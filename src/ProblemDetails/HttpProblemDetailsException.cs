// <copyright file="HttpProblemDetailsException.cs" company="Cognisant Research">
// Copyright (c) Cognisant Research. All rights reserved.
// </copyright>

namespace CR.ProblemDetails
{
    using System;

    /// <inheritdoc />
    /// <summary>
    /// An <see cref="Exception"/> which can be thrown when an error occurs while fulfilling a HTTP request.
    /// </summary>
    public class HttpProblemDetailsException : Exception
    {
#pragma warning disable SA1648 // inheritdoc should be used with inheriting class
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpProblemDetailsException"/> class with <see cref="HttpProblemDetails"/>, an <see cref="Exception"/> message, and an inner <see cref="Exception"/>.
        /// </summary>
        /// <param name="problemDetails">The <see cref="IHttpProblemDetails"/> explaining what caused the <see cref="HttpProblemDetailsException"/> to be thrown.</param>
        /// <param name="message">A message providing additional details for the exception, and why it was thrown (unlike <paramref name="problemDetails"/> members, this will not be sent to the user).</param>
        /// <param name="innerException">An inner exception responsible for this one being thrown.</param>
        public HttpProblemDetailsException(IHttpProblemDetails problemDetails, string message, Exception innerException)
            : base(message, innerException) => ProblemDetails = problemDetails;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpProblemDetailsException"/> class with <see cref="IHttpProblemDetails"/>, and an inner <see cref="Exception"/>.
        /// </summary>
        /// <param name="problemDetails">The <see cref="IHttpProblemDetails"/> explaining what caused the <see cref="HttpProblemDetailsException"/> to be thrown.</param>
        /// <param name="innerException">An inner exception responsible for this one being thrown.</param>
        public HttpProblemDetailsException(IHttpProblemDetails problemDetails, Exception innerException)
            : base(null, innerException) => ProblemDetails = problemDetails;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpProblemDetailsException"/> class with <see cref="IHttpProblemDetails"/>, and an <see cref="Exception"/> message.
        /// </summary>
        /// <param name="problemDetails">The <see cref="IHttpProblemDetails"/> explaining what caused the <see cref="HttpProblemDetailsException"/> to be thrown.</param>
        /// <param name="message">A message providing additional details for the exception, and why it was thrown (unlike <paramref name="problemDetails"/> members, this will not be sent to the user).</param>
        public HttpProblemDetailsException(IHttpProblemDetails problemDetails, string message)
            : base(message) => ProblemDetails = problemDetails;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpProblemDetailsException"/> class with <see cref="IHttpProblemDetails"/>.
        /// </summary>
        /// <param name="problemDetails">The <see cref="IHttpProblemDetails"/> explaining what caused the <see cref="HttpProblemDetailsException"/> to be thrown.</param>
        public HttpProblemDetailsException(IHttpProblemDetails problemDetails) => ProblemDetails = problemDetails;
#pragma warning restore SA1648 // inheritdoc should be used with inheriting class

        /// <summary>
        /// Gets the <see cref="IHttpProblemDetails"/> describing the issue which resulted in the <see cref="HttpProblemDetailsException"/> being thrown.
        /// </summary>
        public IHttpProblemDetails ProblemDetails { get; }
    }
}
