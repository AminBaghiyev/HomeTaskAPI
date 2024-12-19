﻿namespace EmployeeManagement.BL.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string message) : base(message) { }

    public EntityNotFoundException() : base("Entity not found!") { }
}
