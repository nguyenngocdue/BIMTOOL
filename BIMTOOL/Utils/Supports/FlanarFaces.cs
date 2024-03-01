using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using static Autodesk.Revit.DB.SpecTypeId;

namespace STR
{
    public class FlanarFaces
    {
        public static List<PlanarFace> GetPlanarFacesFromSolids(List<Solid> solids, Func<XYZ, bool> condition)
        {
            if (solids != null && condition != null)
            {
                List<PlanarFace> planarFaces = new List<PlanarFace>();
                foreach (Solid solid in solids)
                {
                    if (solid != null)
                    {
                        foreach (Face face in solid.Faces)
                        {
                            if (face is PlanarFace planarFace)
                            {
                                XYZ normal = planarFace.FaceNormal;
                                if (condition(normal))
                                {
                                    planarFaces.Add(planarFace);
                                }

                            }
                        }
                    }
                }
                return planarFaces;
            }
            return null;

        }

        public static List<PlanarFace> GetTopBottomPlanarFaceFromSolid(Solid solid)
        {
            if (solid != null)
            {
                List<PlanarFace> planarFaces = new List<PlanarFace>();
                foreach (Face face in solid.Faces)
                {
                    if (face is PlanarFace planarFace)
                    {
                        XYZ normal = planarFace.FaceNormal;
                        if (normal.Z != 0) planarFaces.Add(planarFace);
                    }
                }
                return planarFaces;
            }
            return null;
        }

        private static bool isArraySolid(object input)
        {
            if (input is Solid) return false;
            else if (input is List<Solid>) return true;
            else throw new ArgumentException("Invalid input type. Expected Solid or List<Solid>.");
        }

        public static List<PlanarFace> GetTopBotPlanFacesFromSolidOrSolids(object input)
        {
            List<Solid> solids = new List<Solid>();
            if (isArraySolid(input))
            {
                List<Solid> inputSolids = input as List<Solid>;
                solids.AddRange(inputSolids);
            }
            else
            {
                Solid s = (Solid)input;
                solids.Add(s);
            }
            Func<XYZ, bool> condition = normal => normal.Z != 0;
            List<PlanarFace> planarfaces = GetPlanarFacesFromSolids(solids, condition);
            return planarfaces;
        }

    }
}
