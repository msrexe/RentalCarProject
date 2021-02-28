using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetColors();
        Brand GetById(int id);
        void Add(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);
    }
}
