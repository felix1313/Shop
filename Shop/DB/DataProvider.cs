﻿using Shop.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Shop.Models;

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

        public Unit GetUnitById(int unitId)
        {
            using (var hren = new ShopDataContext())
            {
                return hren.Units.FirstOrDefault(u => u.Id == unitId);
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

        public Admin GetAdmin(string email)
        {
            using (var db = new ShopDataContext())
            {
                return db.Admins.SingleOrDefault(a => a.Email.Equals(email));
            }
        }

        public void CreateAdmin(string email, string password)
        {
            using (var db = new ShopDataContext())
            {
                db.Admins.InsertOnSubmit(new Admin {Email = email, Password = password});
				db.SubmitChanges();
            }
        }

	    public void AddUnit(Unit unit)
	    {
			using (var db = new ShopDataContext())
			{
				db.Units.InsertOnSubmit(unit);
				db.SubmitChanges();
			}
	    }

	    public IEnumerable<Order> GetNewOrders()
	    {
			using (var db = new ShopDataContext())
			{
				return db.Orders.Where(o => o.State == (int) OrderState.New);
			}
	    }

	    public void ConfirmOrder(int id)
	    {
			using (var db = new ShopDataContext())
			{
				var unit = db.Orders.FirstOrDefault(u => u.Id == id);
				unit.State = (int) OrderState.InProgress;
				db.SubmitChanges();
			}
	    }
    }
}