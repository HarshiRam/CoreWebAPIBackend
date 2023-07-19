using CoreWebAPIBackend.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebAPIBackend.Infrastructure.Implementation
{
    public class SingletonRep: ISingletonRep
    {
        int count;
        public SingletonRep()
        {
            count = count+1;
        }
        public int GetObjectCount()
        {
            return count;
        }
    }
}
