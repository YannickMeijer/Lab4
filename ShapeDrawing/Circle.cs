using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Circle : Shape
{
    public Circle(int x, int y, int size)
    {
		this.x = x;
		this.y = y;
        this.size = size;
        pts = new Point[1];
        fillPoints();
    }

    public override void fillPoints()
    {
        pts[0] = new Point(this.x, this.y);
    }

    public override void Draw(Graphics Canvas)
    {
		Pen pen = new Pen(Color.Black);
        Canvas.DrawEllipse(pen, pts[0].X, pts[0].Y, this.size, this.size);
    }

}
