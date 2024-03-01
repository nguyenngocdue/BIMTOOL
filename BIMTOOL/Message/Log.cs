using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace STR
{
    public class Log
    {
        public static string GetPlanarFaceDetails(List<PlanarFace> planarfaces)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Details of Planar Faces:");
            foreach (PlanarFace planarFace in planarfaces)
            {
                XYZ normal = planarFace.FaceNormal;
                sb.AppendLine("Normal Vector: " + normal.ToString());
            }
            return sb.ToString();
        }

        public static void WritePlanarFaceDetailsToFile(List<PlanarFace> planarfaces)
        {
            // Path of the LogCsharp.log file
            string filePath = "LogCSharp.log";
            try
            {
                // Open or create the LogCsharp.log file for writing
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine("Details of Planar Faces:");
                    foreach (PlanarFace planarFace in planarfaces)
                    {
                        XYZ normal = planarFace.XVector;
                        writer.WriteLine("Normal Vector: " + normal.ToString());
                    }
                    writer.WriteLine(); // Add a blank line between each write
                }
            }
            catch (Exception ex)
            {
                // Handle error if any
                Console.WriteLine("An error occurred while writing to the file: " + ex.Message);
            }
        }
    }
}
