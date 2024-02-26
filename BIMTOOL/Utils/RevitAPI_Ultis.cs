using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;
namespace STR
{
     class RevitAPI_Ultis
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

        public static List<Element> SelectAllElementsInDocument(Document doc, BuiltInCategory category, bool isNotElementType = true)
        {
            ElementFilter filter = new ElementCategoryFilter(category);

            IEnumerable<Element> elements;

            if (isNotElementType)
            {
                elements = new FilteredElementCollector(doc)
                    .WherePasses(filter)
                    .WhereElementIsNotElementType()
                    .ToElements();
            }
            else
            {
                elements = new FilteredElementCollector(doc)
                    .WherePasses(filter)
                    .WhereElementIsElementType()
                    .ToElements();
            }

            return elements.ToList();
        }

    }
}
