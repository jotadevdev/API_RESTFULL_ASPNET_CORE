using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST_EXEMPLO.Data.Converter
{
    public interface IParse<O, D>
    {
        D Parse(O origem);
        List<D> PaserList(List<O> origem);

    }
}
