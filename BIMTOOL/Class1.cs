using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI.Events;
using System.Windows.Forms;

namespace STR
{
    [Transaction(TransactionMode.Manual)]
    internal class Class1 : IExternalCommand
    {
        private Document doc;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Obtain the active UI document and document
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            doc = uidoc.Document;

            // Pick an element from the active view
            Reference reference = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "Pick Object");
            Element element = doc.GetElement(reference);

            // Retrieve information about the element's category and ID
            string category = element.Category.Name;
            string id = element.Id.ToString();
            string thongtin = "Information of the object:" + '\n'
                         + "-Id: " + id + '\n'
                         + "-Category: " + category;

            // Display the information in a message box
            MessageBox.Show(thongtin, "Revit2020");

            // Get the instance parameter of the element
            Parameter parameter = element.LookupParameter("Comments");

            // Set the category information into the "Comments" parameter
            using (Transaction t = new Transaction(doc, "Test"))
            {
                t.Start();

                parameter.Set(category);

                t.Commit();
            }

            return Result.Succeeded;

        }
    }
}
