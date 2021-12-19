using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_projekt
{
    public interface SortEngine
    {
        void SortWithDescription();
        int SortAsMethod();
        int SortWithResult(ref List<Item> returnItems);
    }
}
