using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SVGGraphics : GraphicsConversion
{

    public SVGGraphics()
    { }


    public override string writeConverter(Point[] points, int size = 0)
    {

        string output;

        if (points.Length > 1)
        {
            output = "\r\n<polyline points=\"";
            for (int i = 0; i < points.Length; i++)
            {
                output = output + points[i].X.ToString() + "," + points[i].Y.ToString() + " ";
            }

            output = output + points[0].X.ToString() + "," + points[0].Y.ToString() + "\"\r\nstyle=\"fill:none;stroke:black;stroke-width:1\" />";

            return output;
        }
        else
        {
            output = "\r\n<circle cx=\"" + (points[0].X + size / 2).ToString() + "\" cy=\"" + (points[0].Y + size / 2).ToString() +                 "\" r=\"" + (size / 2).ToString() + "\" stroke-width=\"1\"\r\nfill=\"none\" stroke=\"black\" />";            return output;
        }
    }
}
