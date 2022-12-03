using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public const int WIDTH = 38;
    public const int HEIGHT = 32;
    public const float DISTANCE_WALL = 2;
    public const float DISTANCE_PIT = -5;
    public int dimensions = WIDTH * HEIGHT;
    public int layerDifference = (WIDTH * HEIGHT) + HEIGHT + WIDTH + 1;

    private Vector3[] verts;
    private int[] tris;
    private Vector2[] uv;

    private int[] layerTerrain = new int[] {
        2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
        2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
        2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
        2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
        2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2,
        2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2,
        2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2,
        2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 1, 1, 1, 2, 2, 2, 2, 2, 2,
        2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 1, 1, 1, 2, 2, 2, 2, 2, 2,
        2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 1, 1, 1, 2, 2, 2, 2, 2, 2,
        2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 1, 1, 1, 2, 2, 2, 2, 2, 2,
        2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 1, 1, 1, 2, 2, 2, 2, 2, 2,
        2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 1, 1, 1, 2, 2, 2, 2, 2, 2,
        2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 1, 1, 1, 2, 2, 2, 2, 2, 2,
        2, 1, 1, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 1, 1, 1, 2, 2, 2, 2, 2, 2,
        2, 1, 1, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 1, 1, 1, 2, 2, 2, 2, 2, 2,
        2, 1, 1, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 1, 1, 1, 2, 2, 0, 0, 2, 2,
        2, 1, 1, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 1, 1, 1, 2, 2, 0, 0, 2, 2,
        2, 1, 1, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 1, 1, 1, 2, 2, 0, 0, 2, 2,
        2, 1, 1, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 1, 1, 1, 2, 2, 0, 0, 2, 2,
        2, 1, 1, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 1, 1, 1, 2, 2, 0, 0, 2, 2,
        2, 1, 1, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 1, 1, 1, 2, 2, 0, 0, 2, 2,
        2, 1, 1, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 0, 0, 2, 2,
        2, 1, 1, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 0, 0, 2, 2,
        2, 1, 1, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 0, 0, 2, 2,
        2, 1, 1, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 2, 2,
        2, 1, 1, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 2, 2,
        2, 1, 1, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2,
        2, 1, 1, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2,
        2, 1, 1, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2,
        2, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
        2, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2
    };
    private int[] layerEffects = new int[] { };
    private int[] layerElements = new int[] { };
    private int[] layerEntities = new int[] { };

    private Mesh mesh;
    private MeshFilter meshFilter;

    void Start()
    {
        // Plot vertices. It's simply three layers of (width + 1) by (height + 1) rectangles with each vert aligned to the unit grid
        List<Vector3> newVerts = new List<Vector3>();
        for (int l = 0; l < 3; l++)
        {
            for (int y = HEIGHT; y >= 0; y--)
            {
                for (int x = 0; x <= WIDTH; x++)
                {
                    newVerts.Add(new Vector3(x - (WIDTH * 0.5f), l switch { 0 => DISTANCE_PIT, 2 => DISTANCE_WALL, _ => 0 }, y - (HEIGHT * 0.5f)));
                }
            }
        }
        verts = newVerts.ToArray();

        // Plot triangles.
        List<int> newTris = new List<int>();
        int j = 0;
        int k = 0;
        // Firstly, we determine the current height to draw a surface on, then draw a square in the current tile
        for (int i = 0; i < dimensions; i++)
        {
            int thisIndex = k + (layerDifference * layerTerrain[i]);
            newTris.Add(thisIndex);
            newTris.Add(thisIndex + 1);
            newTris.Add(thisIndex + 1 + WIDTH);
            newTris.Add(thisIndex + 1);
            newTris.Add(thisIndex + 2 + WIDTH);
            newTris.Add(thisIndex + 1 + WIDTH);

            j++;
            k++;
            if (j == WIDTH)
            {
                j = 0;
                k++;
            }
        }
        j = 0;
        k = 0;
        // Secondly, we cycle through every tile and analyze each cardinally-adjacent tile to determine if and where to draw walls
        for (int i = 0; i < dimensions; i++)
        {
            if (layerTerrain[i] == 0)
            {
                if (i < WIDTH)
                    newTris = DrawWall(newTris, false, 0, k);
                else if (layerTerrain[i - WIDTH] != 0)
                    newTris = DrawWall(newTris, false, 0, k);

                if (i % WIDTH == 0 || layerTerrain[i - 1] != 0)
                    newTris = DrawWall(newTris, false, 1, k);

                if ((i + 1) % WIDTH == 0 || layerTerrain[i + 1] != 0)
                    newTris = DrawWall(newTris, false, 2, k);

                if (i > dimensions - WIDTH - 1)
                    newTris = DrawWall(newTris, false, 3, k);
                else if (layerTerrain[i + WIDTH] != 0)
                    newTris = DrawWall(newTris, false, 3, k);
            }
            else if (layerTerrain[i] == 2)
            {
                if (i < WIDTH)
                    newTris = DrawWall(newTris, true, 0, k);
                else if (layerTerrain[i - WIDTH] != 2)
                    newTris = DrawWall(newTris, true, 0, k);

                if (i % WIDTH == 0 || layerTerrain[i - 1] != 2)
                    newTris = DrawWall(newTris, true, 1, k);

                if ((i + 1) % WIDTH == 0 || layerTerrain[i + 1] != 2)
                    newTris = DrawWall(newTris, true, 2, k);

                if (i > dimensions - WIDTH - 1)
                    newTris = DrawWall(newTris, true, 3, k);
                else if (layerTerrain[i + WIDTH] != 2)
                    newTris = DrawWall(newTris, true, 3, k);
            }

            j++;
            k++;
            if (j == WIDTH)
            {
                j = 0;
                k++;
            }
        }
        tris = newTris.ToArray();

        meshFilter = GetComponent<MeshFilter>();
        mesh = new Mesh
        {
            vertices = verts,
            triangles = tris
        };
        meshFilter.mesh = mesh;
    }

    void Update()
    {
        
    }

    private List<int> DrawWall(List<int> currentList, bool layer, int direction, int tile)
    {
        List<int> newTris = currentList;
        int originVert = tile + (layer ? layerDifference : 0);
        switch (direction)
        {
            default: // If layer is true, walls are drawn facing away from the tile. If false, they're drawn facing inward toward it
            case 0: // Up
                newTris.Add(originVert);
                newTris.Add(layer ? (originVert + 1) : (originVert + layerDifference));
                newTris.Add(layer ? (originVert + layerDifference) : (originVert + 1));
                newTris.Add(originVert + 1);
                newTris.Add(layer ? (originVert + layerDifference + 1) : (originVert + layerDifference));
                newTris.Add(layer ? (originVert + layerDifference) : (originVert + layerDifference + 1));
                break;
            case 1: // Left
                newTris.Add(originVert);
                newTris.Add(layer ? (originVert + layerDifference) : (originVert + WIDTH + 1));
                newTris.Add(layer ? (originVert + WIDTH + 1) : (originVert + layerDifference));
                newTris.Add(originVert + WIDTH + 1);
                newTris.Add(layer ? (originVert + layerDifference) : (originVert + layerDifference + WIDTH + 1));
                newTris.Add(layer ? (originVert + layerDifference + WIDTH + 1) : (originVert + layerDifference));
                break;
            case 2: // Right
                newTris.Add(originVert + 1);
                newTris.Add(layer ? (originVert + WIDTH + 2) : (originVert + layerDifference + 1));
                newTris.Add(layer ? (originVert + layerDifference + 1) : (originVert + WIDTH + 2));
                newTris.Add(originVert + WIDTH + 2);
                newTris.Add(layer ? (originVert + layerDifference + WIDTH + 2) : (originVert + layerDifference + 1));
                newTris.Add(layer ? (originVert + layerDifference + 1) : (originVert + layerDifference + WIDTH + 2));
                break;
            case 3: // Down
                newTris.Add(originVert + WIDTH + 1);
                newTris.Add(layer ? (originVert + layerDifference + WIDTH + 1) : (originVert + WIDTH + 2));
                newTris.Add(layer ? (originVert + WIDTH + 2) : (originVert + layerDifference + WIDTH + 1));
                newTris.Add(originVert + WIDTH + 2);
                newTris.Add(layer ? (originVert + layerDifference + WIDTH + 1) : (originVert + layerDifference + WIDTH + 2));
                newTris.Add(layer ? (originVert + layerDifference + WIDTH + 2) : (originVert + layerDifference + WIDTH + 1));
                break;
        }
        return newTris;
    }
}
