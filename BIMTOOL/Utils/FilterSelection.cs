using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;

namespace STR
{
  
    public class FilterWalls : ISelectionFilter
    {
        public bool AllowElement(Element element)
        {
            if (element.Category.Name == "Walls") return true;
            return false;
        }
        public bool AllowReference(Reference refer, XYZ point)
        {
            return false;
        }
    }

    public class FilterFrammings : ISelectionFilter
    {
        public bool AllowElement(Element element)
        {

            if(element.Category.Name == "Structural Framing") return true;
            return false;
        }
        public bool AllowReference(Reference refer, XYZ point)
        {
            return false;
        }
    }
}
