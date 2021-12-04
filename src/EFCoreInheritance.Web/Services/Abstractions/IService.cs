﻿namespace EFCoreInheritance.Web.Services.Abstractions
{
    public interface IService
    {
        Task<IResponse> GetResult(CancellationToken cancellationToken);
    }
}
