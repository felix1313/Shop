using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Observers
{
    public interface IObserver
    {
        void DoAction(IAction a);
    }
}
