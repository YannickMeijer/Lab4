using System;
using System.Drawing;

public abstract class Shape
{
    protected int x;
    protected int y;
    protected Point[] pts;

    public Shape()
    {
    }

    public abstract void fillPoints();

    public abstract void Draw(Graphics Canvas);

    public Point[] getPoints
    {
        get { return this.pts; }
    }

}