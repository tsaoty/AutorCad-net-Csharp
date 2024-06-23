using System;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using DOTNETARX;

namespace ClassLibrary
{
    public class Class1
    {
        // Define Command "Test"
        [CommandMethod("ty_DotNetARX")]
        static public void Test()
        {
            //gets the current AutoCAD editor using DOTNETARX 
            //Editor ed = Tools.Editor; 為何不行？？？ < Tools.Editor 屬性
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            //gets the first point on a circle
            PromptPointResult res = ed.GetPoint("\nPlease select the first point:");
            Point3d pt1 = res.Value;

            //gets the second point on a circle
            res = ed.GetPoint("\nPlease select the second point:");
            Point3d pt2 = res.Value;

            //gets the last point on a circle
            res = ed.GetPoint("\nPlease select the last point:");
            Point3d pt3 = res.Value;
            //creates a circle using the three points,Circles is a class to create circle in DOTNETARX
            Circles circle = new Circles(pt1, pt2, pt3);
            //adds the circle to AutoCAD database 
            Tools.AddEntity(circle); //？？？無此方法？？？
            //changes the color of the circle,though it has added into database
            Tools.PutColorIndex(circle, 1);
        }
    }
}
