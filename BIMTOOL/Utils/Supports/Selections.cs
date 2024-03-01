using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace STR
{
    public class Selections
    {
        public static List<Element> GetElementsByRectangle(UIDocument uidoc)
        {
            IList<Element> elements = uidoc.Selection.PickElementsByRectangle(new FilterFrammings());
            return new List<Element>(elements);
        }
    }
}
