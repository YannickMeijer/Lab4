using System;
using System.Drawing;

public abstract class Shape
{
    protected int x;
    protected int y;
    protected Point[] pts;
    protected SVGGraphics converter;
    protected int size;

    public Shape()
    {
        converter = new SVGGraphics();
    }

    public abstract void fillPoints();

    public abstract void Draw(Graphics Canvas);

    public string Conversion()
    {
        return converter.writeSVG(pts, size);
    }

    public Point[] getPoints
    {
        get { return this.pts; }
    }

}