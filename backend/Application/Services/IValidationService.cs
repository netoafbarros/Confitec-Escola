﻿namespace ConfitecEscola.Application.Services
{
    public interface IValidationService
    {
        void Validate<T>(T obj);
    }
}
