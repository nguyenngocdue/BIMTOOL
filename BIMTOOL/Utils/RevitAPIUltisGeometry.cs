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
                        if (normal.X > 0 && normal.Z == 0)
                        {
                            planarfaces.Add(planarFace);
                        }

                    }
                }
                string details = Log.GetPlanarFaceDetails(planarfaces);
                Log.WritePlanarFaceDetailsToFile(planarfaces);
                MessageBox.Show("The number of faces: " + planarfaces.Count.ToString() + details);
                return planarfaces;
            }
            return null;

        }

    }
}
