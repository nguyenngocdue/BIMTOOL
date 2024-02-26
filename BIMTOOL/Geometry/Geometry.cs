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

            Reference reference = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, new FilterFrammings());
            FamilyInstance framings = doc.GetElement(reference) as FamilyInstance;

            Options options = new Options();
            options.IncludeNonVisibleObjects = true;

            Solid solids = RevitAPIUltisGeometry.GetSolidInstance(framings, options);
            if (solids != null)
            {
                // Đoạn mã dưới đây sẽ hiển thị một MessageBox thông báo về số lượng Face trong Solid
                int faceCount = 0;
                foreach (Face face in solids.Faces)
                {
                    faceCount++;
                }
                MessageBox.Show("Số lượng Face trong Solid: " + faceCount.ToString());
            }
            else
            {
                MessageBox.Show("Không tìm thấy Solid!");
            }
            return 0;
        }
    }
}
