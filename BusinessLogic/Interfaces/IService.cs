using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IService<T>
    {
        void Add(T item);
    }
}
