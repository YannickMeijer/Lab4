using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;

public class Parser
{
	public static List<Shape> ParseShapes(string Filename)
	{
		// Load xml documents
		XmlDocument doc = new XmlDocument();
		doc.Load(Filename);
		
		// Parse all shapes
		List<Shape> shapes = new List<Shape>();
		foreach(XmlNode shape in doc.SelectNodes("/shapes/*"))
		{
			string type = shape.Name;
            int x; int y; Tuple<int, int> a;
            x = int.Parse(shape.Attributes["x"].Value);
            y = int.Parse(shape.Attributes["y"].Value);
            switch (type)
            {

                case "rectangle":
                    a = findWidthHeight(shape);
                    shapes.Add(new Rectangle(x, y, a.Item1, a.Item2));
                    break;
                case "circle":
					int size = int.Parse(shape.Attributes["size"].Value);
                    shapes.Add(new Circle(x, y, size));
                    break;
				case "star":
                    a = findWidthHeight(shape);
                    shapes.Add (new Star(x,y, a.Item1, a.Item2));
					break;
            }
		}
		
		return shapes;
	}

    static Tuple<int, int> findWidthHeight(XmlNode shape)
    {
        int width = int.Parse(shape.Attributes["width"].Value);
        int height = int.Parse(shape.Attributes["height"].Value);
        return Tuple.Create<int, int>(width, height);
    }
}