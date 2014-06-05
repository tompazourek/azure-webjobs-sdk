﻿using System.Collections.Generic;

namespace Microsoft.Azure.Jobs.Host.Indexers
{
    class IndexInMemory : IFunctionTable
    {
        private readonly List<FunctionDefinition> _list = new List<FunctionDefinition>();

        public void Add(FunctionDefinition func)
        {
            _list.Add(func);
        }

        void IFunctionTable.Delete(FunctionDefinition func)
        {
            string id = func.Id;
            foreach (var x in _list)
            {
                if (x.Id == id)
                {
                    _list.Remove(x);
                    return;
                }
            }
        }

        public FunctionDefinition Lookup(string functionId)
        {
            // $$$ Not linear :(
            foreach (var x in _list)
            {
                if (x.Id == functionId)
                {
                    return x;
                }
            }
            return null;
        }

        public FunctionDefinition[] ReadAll()
        {
            return _list.ToArray();
        }
    }
}