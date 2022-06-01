using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DataAccess.Abstract
{
    public interface IAdvertisedDAL : IRepository<Advertised>
    {
        List<Advertised> GetAll();
    }
}
