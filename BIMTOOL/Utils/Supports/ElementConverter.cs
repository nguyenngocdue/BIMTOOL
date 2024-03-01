using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace STR
{
    public static class ElementConverter
    {
        public static List<FamilyInstance> ConvertToFamilyInstances(List<Element> elements)
        {
            List<FamilyInstance> familyInstances = new List<FamilyInstance>();

            foreach (Element element in elements)
            {
                if (element is FamilyInstance familyInstance)
                {
                    familyInstances.Add(familyInstance);
                }
            }

            return familyInstances;
        }
    }
}
