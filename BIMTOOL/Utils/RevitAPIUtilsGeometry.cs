using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
namespace STR
{
    class RevitAPIUtilsGeometry
    {
        public static List<PlanarFace> GetPlanarFaceFromSolid(Solid solids)
        {

            if (solids != null)
            {
                List<PlanarFace> planarfaces = new List<PlanarFace>();
                foreach (Face face in solids.Faces)
                {
                    if (face is PlanarFace planarFace)
                    {
                        XYZ normal = planarFace.XVector;
                        if (normal.X > 0 && normal.Z == 0) planarfaces.Add(planarFace);
                    }
                }
                string details = Log.GetPlanarFaceDetails(planarfaces);
                Log.WritePlanarFaceDetailsToFile(planarfaces);
                MessageBox.Show("The number of faces: " + planarfaces.Count.ToString() + details);
                return planarfaces;
            }
            return null;
        }

        public static List<PlanarFace> GetTopBottomPlanarFacesFromSolid(Solid solid)
        {
            if(solid != null)
            {
                List<PlanarFace> planarFaces = new List<PlanarFace>();
                foreach(Face face in solid.Faces)
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


        public static List<PlanarFace> GetTopPlanarFaceFromSolid(Solid solid)
        {
            if (solid != null)
            {
                List<PlanarFace> planarFaces = new List<PlanarFace>();
                foreach (Face face in solid.Faces)
                {
                    if (face is PlanarFace planarFace)
                    {
                        XYZ normal = planarFace.FaceNormal;
                        if (normal.Z > 0) {
                            planarFaces.Add(planarFace);
                            break;
                        }
                    }
                }
                return planarFaces;
            }
            return null;
        }

        public static List<PlanarFace> GetBottomPlanarFaceFromSolid(Solid solid)
        {
            if (solid != null)
            {
                List<PlanarFace> planarFaces = new List<PlanarFace>();
                foreach (Face face in solid.Faces)
                {
                    if (face is PlanarFace planarFace)
                    {
                        XYZ normal = planarFace.FaceNormal;
                        if (normal.Z < 0)
                        {
                            planarFaces.Add(planarFace);
                            break;
                        }
                    }
                }
                return planarFaces;
            }
            return null;
        }

    }
}
