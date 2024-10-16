using OtoServisSatis.Data.Abstract;
using OtoServisSatis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Service.Abstract
{
    public interface IService<T>:IRepository<T>where T : class,IEntity,new()
    {
    }
}
