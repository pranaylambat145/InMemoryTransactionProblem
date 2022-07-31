using InMemoryTrans.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryTrans.Store
{
    public class InMemoryStore
    {
        public readonly Dictionary<string, int> tempMemory;
        internal readonly Stack<string> _stack;
        //private IOperations o;

        public InMemoryStore()
        {
            _stack = new Stack<string>();
            tempMemory = new Dictionary<string, int>();
            //tempMemory = new Dictionary<string, int>();
        }
        //public InMemoryStore(Operationss o)
        //{
        //   // _stack = new Stack<string>();
        //    tempMemory = new Dictionary<string, int>(o.valueStore);
        //}

        //public InMemoryStore(Operationss o)
        //{
        //    tempMemory = new Dictionary<string, int>(o.valueStore);
        //}

        //public InMemoryStore(IOperations o)
        //{
        //    this.o = o;
        //}
    }
}
