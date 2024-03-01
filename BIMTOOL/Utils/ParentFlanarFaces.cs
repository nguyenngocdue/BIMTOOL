using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace STR
{
     public abstract class ParentFlanarFaces
    {
        // Implementing a default implementation of the method
        public virtual List<PlanarFace> GetPlanarFacesFromSolids(List<Solid> solids, Func<XYZ, bool> condition)
        {
            if (solids != null && condition != null)
            {
                List<PlanarFace> planarFaces = new List<PlanarFace>();
                foreach (Solid solid in solids)
                {
                    if(solid != null)
                    {
                        foreach(Face face in solid.Faces)
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
    }
}
