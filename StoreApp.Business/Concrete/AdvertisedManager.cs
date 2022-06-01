
using StoreApp.Business.Abstract;
using StoreApp.DataAccess.Abstract;
using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Business.Concrete
{
    public class AdvertisedManager : IAdvertisedService
    {

        private IAdvertisedDAL _advertisedDAL;
        public AdvertisedManager(IAdvertisedDAL advertisedDAL)
        {
            _advertisedDAL = advertisedDAL;
        }

        public void Create(Advertised entity)
        {
            _advertisedDAL.Create(entity);
        }

        public void Delete(Advertised entity)
        {
            _advertisedDAL.Delete(entity);
        }

        public List<Advertised> GetAll()
        {
            return _advertisedDAL.GetAll();
        }
        

        public List<Advertised> GetDailyAdvertised()
        {
            return _advertisedDAL.GetAll(a => a.WeeklyOrDaily == false);
        }

        public List<Advertised> GetWeeklyAdvertised()
        {
            return _advertisedDAL.GetAll(a => a.WeeklyOrDaily == true);
        }

        public void Update(Advertised entity)
        {
            _advertisedDAL.Update(entity);
        }
    }
}
