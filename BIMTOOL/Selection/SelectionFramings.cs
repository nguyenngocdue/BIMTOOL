using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections.Generic;

namespace STR
{
    [Transaction(TransactionMode.Manual)]
    class SelectionFramings : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            IList<Element> list = uidoc.Selection.PickElementsByRectangle(new FilterFrammings());
            IList<ElementId> ids = RevitAPI_Ultis.ToIlistId(list);
            uidoc.Selection.SetElementIds(ids);
            return 0;
        }
    }
}
