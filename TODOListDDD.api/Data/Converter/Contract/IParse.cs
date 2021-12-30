using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODOListDDD.api.Data.Converter.Contract
{
    interface IParse<O,D>
    {
        public D Parse(O origin);
        public IEnumerable<D> Parse(IEnumerable<O> origin);
    }
}
