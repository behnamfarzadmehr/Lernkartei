using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Lernkartei.Test.Persist
{
    public abstract class PersistTest : IDisposable
    {
        private TransactionScope _scope;
        public PersistTest()
        {
            _scope = new();
        }
        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}
