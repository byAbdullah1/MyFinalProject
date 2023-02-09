
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.DataAccess
{
    //generic consraint aşağıdaki gibi kullanılan generic yapısını kısıtlamak içindir.
    //class yazmamızdaki amaç referans tiplerin sadece T yerine kullanılabilmelerine izin verilmesidir 
    //IEntity interfaci ve onu implemente eden claslar sadece yazılabilir
    //new() demek newlenebilir olmalı demek yani soyut sınıfları yazamayacağımızı bildiriyor.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
       
    }
}
