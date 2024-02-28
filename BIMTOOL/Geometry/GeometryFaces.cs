using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Analysis;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace STR
{
    [Transaction(TransactionMode.Manual)]
    class GeometryFaces : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            Reference reference = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, new FilterFrammings());
            FamilyInstance familyins = doc.GetElement(reference) as FamilyInstance;

            Options options = new Options();
            options.IncludeNonVisibleObjects = true;

            Solid solids = RevitAPIUltisGeometry.GetSolidInstance(familyins, options);
            List<PlanarFace> planarFaces = RevitAPIUltisGeometry.GetPlanarFaceFromSolid(solids);
            return 0;
        }
    }
}
