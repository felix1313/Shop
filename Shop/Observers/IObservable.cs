using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Observers
{
    public interface IObservable
    {
        void AddObserver(IObserver observer);

        void Notify();
    }
}
