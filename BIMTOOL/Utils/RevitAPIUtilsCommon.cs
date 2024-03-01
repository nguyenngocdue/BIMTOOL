using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace STR
{
     class RevitAPIUtilsCommon
    {
        public static IList<ElementId> ToIlistId(IList<Element> list)
        {
            IList<ElementId> ids = new List<ElementId>();
            foreach(Element element in list)
            {
                ids.Add(element.Id);
            }
            return ids;
        }

    }
}
