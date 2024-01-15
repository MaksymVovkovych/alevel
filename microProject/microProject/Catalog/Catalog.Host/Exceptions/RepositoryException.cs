﻿namespace Catalog.Host.Exceptions;

public class RepositoryException : Exception
{
    public override string Message { get; }

    public RepositoryException(string Message)
    {
        this.Message = Message;
    }
}