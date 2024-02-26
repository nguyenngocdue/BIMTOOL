using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace STR
{
     class RevitAPIUltisGeometry
    {
       public static Solid GetSolidInstance(FamilyInstance familyInstance, Options options)
        {
            Solid sol = null;
            GeometryElement geometryElements = familyInstance.get_Geometry(options);
            foreach (GeometryObject geometryObject in geometryElements)
            {
                if(geometryObject is Solid)
                {
                    Solid solid = geometryObject as Solid;
                    if(solid != null && solid.Volume > 0 && solid.Faces.Size > 0)
                    {
                        sol = solid;
                    }
                }
            }
            if (sol == null || sol.Volume == 0)
            {
                foreach (GeometryObject geometryObject in geometryElements)
                {
                    if (geometryObject is GeometryInstance)
                    {
                        GeometryInstance geometryInstance = (GeometryInstance)geometryObject;
                        foreach (GeometryObject geo1 in geometryInstance.GetInstanceGeometry())
                        {
                            if (geo1 is Solid)
                            {
                                Solid solid1 = geo1 as Solid;
                                if(solid1 != null && solid1.Volume > 0 && solid1.Faces.Size > 0)
                                {
                                    sol = solid1;
                                }
                            }
                        }
                    }
                }
            }
            return sol;

        }

    }
}
