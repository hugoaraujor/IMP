using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMPSOR.Interfaces 
{ 

    public interface IMethods
    {

        List<PozosViewDetail> detalles(int? campo, int? yacimiento);
        IEnumerable<GraphData2View> getDetails(int? campo, int? yacimiento,int? idPozo =0);
        decimal getSor(int idPozo);

    }
}