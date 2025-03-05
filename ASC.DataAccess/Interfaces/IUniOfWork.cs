using ASC.DataAccess.Interfaces;
using ASC.Model.BaseTypes;
using System;

namespace ASC.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : BaseEntity;
        int CommitTransaction();
    }
}