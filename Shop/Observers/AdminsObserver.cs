﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Observers
{
    public class AdminsObserver : IObserver
    {
        public void DoAction(IAction s)
        {
            //throw new NotImplementedException();
            // TODO send mails to admins
        }
    }
}