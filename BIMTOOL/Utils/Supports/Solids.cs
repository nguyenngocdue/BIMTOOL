using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace STR
{
    public class Solids
    {
        public static Solid GetSolidInstance(FamilyInstance familyInstance, Options options)
        {
            Solid sol = null;
            GeometryElement geometryElements = familyInstance.get_Geometry(options);
            foreach (GeometryObject geometryObject in geometryElements)
            {
                if (geometryObject is Solid)
                {
                    Solid solid = geometryObject as Solid;
                    if (solid != null && solid.Volume > 0 && solid.Faces.Size > 0)
                    {
                        sol = solid;
                        break;
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
                                if (solid1 != null && solid1.Volume > 0 && solid1.Faces.Size > 0)
                                {
                                    sol = solid1;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return sol;

        }

        public static List<Solid> GetSolidsFromFamilyInstances(List<FamilyInstance> familyInstances, Options options)
        {
            List<Solid> solids = new List<Solid>();

            foreach (FamilyInstance familyInstance in familyInstances)
            {
                Solid solid = GetSolidInstance(familyInstance, options);
                if (solid != null)
                {
                    solids.Add(solid);
                }
            }

            return solids;
        }

        public static List<PlanarFace> GetAroundVerticalPlanarFacesFromSolids(List<Solid> solids)
        {
            Func<XYZ, bool> aroundVerticalCondition = normal => normal.Z == 0;
            return FlanarFaces.GetPlanarFacesFromSolids(solids, aroundVerticalCondition);
        }

    }
}
