using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Business.Abstract
{
    public interface IAdvertisedService
    {
        List<Advertised> GetWeeklyAdvertised();
        List<Advertised> GetDailyAdvertised();
        List<Advertised> GetAll();

        void Create(Advertised entity);
        void Update(Advertised entity);
        void Delete(Advertised entity);
    }
}
