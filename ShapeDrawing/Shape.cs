using System;
using System.Drawing;

public abstract class Shape
{
    protected int x;
    protected int y;
    protected Point[] pts;
    protected GraphicsConversion converter;
    protected int size;

    public Shape()
    {
    }

    public abstract void fillPoints();

    public abstract void Draw(Graphics Canvas);

    public string Conversion(string a)
    {
        switch (a)
        {
            case "SVG":
                converter = new SVGGraphics();
                break;
        }
        return converter.writeConverter(pts, size);
    }
}