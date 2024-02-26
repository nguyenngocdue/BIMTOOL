using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;

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

    public class FilterElements : ISelectionFilter
    {
        public bool AllowElement(Element element)
        {

            if (element.Category.Name == "Structural Framing" || 
                element.Category.Name == "Structural Foundations" ||
                element.Category.Name == "Structural Columns" ||
                element.Category.Name == "Structural Walls"
                ) 
                    return true;
            return false;
        }
        public bool AllowReference(Reference refer, XYZ point)
        {
            return false;
        }
    }

}
