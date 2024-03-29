﻿using System;
using ItechArt.Common.Logging.Abstractions;

namespace ItechArt.Common.Logging.Extensions;

public static class LoggerExtensions
{
    public static void LogTrace(this ILogger logger, string message)
    {
        logger.Log(LogLevel.Trace, message);
    }

    public static void LogInformation(this ILogger logger, string message)
    {
        logger.Log(LogLevel.Information, message);
    }

    public static void LogWarning(this ILogger logger, string message, Exception exception = null)
    {
        logger.Log(LogLevel.Warning, message, exception);
    }

    public static void LogError(this ILogger logger, string message, Exception exception)
    {
        logger.Log(LogLevel.Error, message, exception);
    }

    public static void LogCritical(this ILogger logger, string message, Exception exception)
    {
        logger.Log(LogLevel.Critical, message, exception);
    }
}