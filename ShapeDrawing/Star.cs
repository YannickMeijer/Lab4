using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Star : Shape
{
	private int width;
	private int height;
    private int numPoints;


	public Star (int x, int y, int width, int height)
	{
		this.x = x;
		this.y = y;
		this.width = width;
        this.height = height;
        pts = new Point[5];
        numPoints = 5;
        fillPoints();
    }

    public override void fillPoints()
    {
        double rx = width / 2;
        double ry = height / 2;
        double cx = x + rx;
        double cy = y + ry;

        double theta = -Math.PI / 2;
        double dtheta = 4 * Math.PI / numPoints;
        for (int i = 0; i < numPoints; i++)
        {
            pts[i] = new Point(
                Convert.ToInt32(cx + rx * Math.Cos(theta)),
                Convert.ToInt32(cy + ry * Math.Sin(theta)));
            theta += dtheta;
        }
    }


    public override void Draw (Graphics Canvas)
	{
		Pen pen = new Pen (Color.Black);
		for (int i = 0; i < numPoints; i++) 
		{
			Canvas.DrawLine(pen,pts[i].X,
                                pts[i].Y,
                                pts[(i+1) % numPoints].X,
                                pts[(i+1) % numPoints].Y);
		}
		
	}
}


