using System.Collections.Generic;
using System.Text;

namespace Log
{
    public class Log
    {
        public static string GetPlanarFaceDetails(List<PlanarFace> planarfaces)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Details of Planar Faces:");
            foreach (PlanarFace planarFace in planarfaces)
            {
                XYZ normal = planarFace.XVector;
                sb.AppendLine("Normal Vector: " + normal.ToString());
            }
            return sb.ToString();
        }
    }
}
