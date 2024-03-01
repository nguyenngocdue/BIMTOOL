using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Windows.Forms;

namespace STR
{
    [Transaction(TransactionMode.Manual)]
    class Geometry : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            List<Element> allElements = Selections.GetElementsByRectangle(uidoc);

            Options options = new Options();
            options.IncludeNonVisibleObjects = true;

            List<FamilyInstance> familyInstances = ElementConverter.ConvertToFamilyInstances(allElements);
            List<Solid> solids = Solids.GetSolidsFromFamilyInstances(familyInstances, options);

            List<PlanarFace> planarFaces = FlanarFaces.GetTopBotPlanFacesFromSolidOrSolids(solids);

            MessageUtils.ShowMessageGeoPlannarFaces(planarFaces);


            return 0;
        }
    }
}
