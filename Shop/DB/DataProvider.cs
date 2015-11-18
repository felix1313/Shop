using Shop.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.DB
{
    public class DataProvider
    {
        private DataProvider()
        {
        }

        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }

                return instance;
            }
        }

        public List<Unit> GetAllUnits()
        {
            using (var hren = new ShopDataContext())
            {
                return hren.Units.ToList();
            }
        }

        public void CreateOrder(IEnumerable<UnitOrderRelation> unitOrderRelations, CustomerInfo customerInfo)
        {
            var order = new Order();
            foreach (var rel in unitOrderRelations)
            {
                order.UnitOrderRelations.Add(rel);
            }
            customerInfo.FillOrder(order);
            order.TimeStamp = DateTime.Now;
            order.State = (int)OrderState.New;
            using (var hren = new ShopDataContext())
            {
                hren.Orders.InsertOnSubmit(order);
                hren.SubmitChanges();
            }
        }
    }
}