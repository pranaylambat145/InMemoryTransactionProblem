using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryTrans.Operations
{
    public interface IOperations
    {
        public int Get(string field);
        public void Set(string field, int value);
        public int Count(int value);
        public void Delete(string field);

    }
}
