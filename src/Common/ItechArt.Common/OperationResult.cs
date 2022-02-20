﻿using System;

namespace ItechArt.Common;

public class OperationResult<TError>
    where TError: Enum
{
    private readonly TError _error = default;

    private readonly bool _success = true;
    private readonly string _message = "";


    public TError Error
    {
        get
        {
            return _error;
        }
    }

    public bool Success
    {
        get
        {
            return _success;
        }
    }

    public string Message
    {
        get
        {
            return _message;
        }
    }


    private OperationResult(string message = null)
    {
        if (message != null)
            _message = message;
    }

    private OperationResult(TError error, string message = null)
    {
        _error = error;
        _success = false;

        if (message != null)
            _message = message;
    }


    public static OperationResult<TError> GetSuccessfulResult(string message = null)
    {
        return new OperationResult<TError>(message);
    }

    public static OperationResult<TError> GetFailureResult(TError error, string message = null)
    {
        return new OperationResult<TError>(error, message);
    }
}