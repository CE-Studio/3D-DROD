using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StyleManager
{
    public static Texture testSheet = Resources.Load<Texture>("Textures/TestStylesheet");

    public static int WIDTH = 4;
    public static int HEIGHT = 4;
    public static float widthF = 1f / WIDTH;
    public static float heightF = 1f / HEIGHT;

    public enum Tiles { Wall, WallSide, Floor1, Floor2, PitWall, Pit };
    public static Vector2[] tileIndeces = new Vector2[]
    {
        new Vector2(0, 3), new Vector2(1, 3), new Vector2(2, 3), new Vector2(3, 3), new Vector2(0, 2), new Vector2(1, 2)
    };

    public static Vector2 GetUVCorner(Tiles tile, int corner)
    {
        Vector2 output = new Vector2(tileIndeces[(int)tile].x * widthF, tileIndeces[(int)tile].y * heightF);
        if (corner == 1 || corner == 3)
            output.x += widthF;
        if (corner == 2 || corner == 3)
            output.y += heightF;
        return output;
    }

    public static List<Vector2> GetTileUV(Tiles tile, List<Vector2> currentList)
    {
        Vector2 topLeft = new Vector2(tileIndeces[(int)tile].x * widthF, tileIndeces[(int)tile].y * heightF);
        currentList.Add(topLeft);
        currentList.Add(new Vector2(topLeft.x + widthF, topLeft.y));
        currentList.Add(new Vector2(topLeft.x + widthF, topLeft.y + heightF));
        currentList.Add(new Vector2(topLeft.x, topLeft.y + heightF));
        return currentList;
    }

    public static Texture GetSheet()
    {
        return testSheet;
    }
}
