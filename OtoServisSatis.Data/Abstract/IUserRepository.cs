﻿using OtoServisSatis.Entity;
using System.Linq.Expressions;

namespace OtoServisSatis.Data.Abstract
{
    public interface IUserRepository: IRepository<Kullanici>
    {
        Task<List<Kullanici>> GetCustomUserList();
        Task<List<Kullanici>> GetCustomUserList(Expression<Func<Kullanici, bool>> expression);
        
    }
}
