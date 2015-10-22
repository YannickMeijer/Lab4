using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Rectangle : Shape
{
    private int width;
    private int height;

    public Rectangle(int x, int y, int width, int height)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        pts = new Point[4];
        fillPoints();
    }

    public override void fillPoints()
    {
        pts[0] = new Point(this.x, this.y);
        pts[1] = new Point(this.x + this.width, this.y);
        pts[2] = new Point(this.x + this.width, this.y + this.height);
        pts[3] = new Point(this.x, this.y + this.height);
    }

    public override void Draw(Graphics Canvas)
    {
        Pen pen = new Pen(Color.Black);
        Canvas.DrawLine(pen, pts[0].X, pts[0].Y, pts[1].X, pts[1].Y);
        Canvas.DrawLine(pen, pts[1].X, pts[1].Y, pts[2].X, pts[2].Y);
        Canvas.DrawLine(pen, pts[2].X, pts[2].Y, pts[3].X, pts[3].Y);
        Canvas.DrawLine(pen, pts[3].X, pts[3].Y, pts[0].X, pts[0].Y);
    }

}

