using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace STR
{
    public class MessageUtils
    {
        public static void ShowMessageGeoPlannarFaces(List<PlanarFace> planarFaces)
        {
            string details = Log.GetPlanarFaceDetails(planarFaces);
            MessageBox.Show("The number of faces: " + planarFaces.Count.ToString() + "\n" + details);
        }

        public static void ShowMessageElements(List<Element> elements)
        {
             MessageBox.Show("Elements: " + elements.Count.ToString(), "Elements");
        }

        public static void ShowMessageFamilyIntances(List<FamilyInstance> elements)
        {
            MessageBox.Show("Elements: " + elements.Count.ToString(), "Elements");
        }

        public static void ShowSolidsMessage(List<Solid> solids)
        {
            MessageBox.Show("Solids: " + solids.Count.ToString(), "Solid");
        }

        public static void ShowPlanarFacessMessage(List<PlanarFace> planarFaces)
        {
            MessageBox.Show("Solids: " + planarFaces.Count.ToString(), "Solid");
        }
    }
}
