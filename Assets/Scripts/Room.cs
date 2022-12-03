using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public const int WIDTH = 38;
    public const int HEIGHT = 32;
    public const float DISTANCE_WALL = 1;
    public const float DISTANCE_PIT = -3;
    public int dimensions = WIDTH * HEIGHT;
    public int layerDifference = (WIDTH * HEIGHT) + HEIGHT + WIDTH + 1;

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
    private MeshRenderer meshRender;

    private enum Shapes { FloorSqr, RectWall };

    void Start()
    {
        List<Vector3> verts = new List<Vector3>();
        List<int> tris = new List<int>();
        List<Vector2> uv = new List<Vector2>();
        Vector2 index2D = Vector2.zero;
        for (int i = 0; i < layerTerrain.Length; i++)
        {
            int currentIndex = verts.Count;
            switch (layerTerrain[i])
            {
                case 0:
                    verts = AddVerts(Shapes.FloorSqr, new Vector3(index2D.x - (WIDTH * 0.5f), DISTANCE_PIT, -index2D.y + (HEIGHT * 0.5f)),
                        new Vector3(1, 0, -1), verts);
                    tris = AddTris(tris, currentIndex);
                    uv = StyleManager.GetTileUV(StyleManager.Tiles.Pit, uv);
                    currentIndex += 4;

                    if (i < WIDTH || (i >= WIDTH && layerTerrain[i - WIDTH] != 0))
                    {
                        verts = AddVerts(Shapes.RectWall, new Vector3(index2D.x - (WIDTH * 0.5f) + 1, 0, -index2D.y + (HEIGHT * 0.5f) + 1),
                            new Vector3(-1, -DISTANCE_PIT, 0), verts);
                        tris = AddTris(tris, currentIndex);
                        uv = StyleManager.GetTileUV(StyleManager.Tiles.PitWall, uv);
                        currentIndex += 4;
                    }
                    if (i % WIDTH == 0 || layerTerrain[i - 1] != 0)
                    {
                        verts = AddVerts(Shapes.RectWall, new Vector3(index2D.x - (WIDTH * 0.5f), 0, -index2D.y + (HEIGHT * 0.5f) + 1),
                            new Vector3(0, -DISTANCE_PIT, -1), verts);
                        tris = AddTris(tris, currentIndex);
                        uv = StyleManager.GetTileUV(StyleManager.Tiles.PitWall, uv);
                        currentIndex += 4;
                    }
                    if ((i + 1) % WIDTH == 0 || layerTerrain[i + 1] != 0)
                    {
                        verts = AddVerts(Shapes.RectWall, new Vector3(index2D.x - (WIDTH * 0.5f) + 1, 0, -index2D.y + (HEIGHT * 0.5f)),
                            new Vector3(0, -DISTANCE_PIT, 1), verts);
                        tris = AddTris(tris, currentIndex);
                        uv = StyleManager.GetTileUV(StyleManager.Tiles.PitWall, uv);
                        currentIndex += 4;
                    }
                    if ((i > dimensions - WIDTH - 1) || (i <= dimensions - WIDTH - 1 && layerTerrain[i + WIDTH] != 0))
                    {
                        verts = AddVerts(Shapes.RectWall, new Vector3(index2D.x - (WIDTH * 0.5f), 0, -index2D.y + (HEIGHT * 0.5f)),
                            new Vector3(1, -DISTANCE_PIT, 0), verts);
                        tris = AddTris(tris, currentIndex);
                        uv = StyleManager.GetTileUV(StyleManager.Tiles.PitWall, uv);
                    }
                    break;
                default:
                case 1:
                    verts = AddVerts(Shapes.FloorSqr, new Vector3(index2D.x - (WIDTH * 0.5f), 0, -index2D.y + (HEIGHT * 0.5f)),
                        new Vector3(1, 0, -1), verts);
                    tris = AddTris(tris, currentIndex);
                    if ((index2D.x % 2 == 0 && index2D.y % 2 == 0) || (index2D.x % 2 == 1 && index2D.y % 2 == 1))
                        uv = StyleManager.GetTileUV(StyleManager.Tiles.Floor1, uv);
                    else
                        uv = StyleManager.GetTileUV(StyleManager.Tiles.Floor2, uv);
                    break;
                case 2:
                    verts = AddVerts(Shapes.FloorSqr, new Vector3(index2D.x - (WIDTH * 0.5f), DISTANCE_WALL, -index2D.y + (HEIGHT * 0.5f)),
                      new Vector3(1, 0, -1), verts);
                    tris = AddTris(tris, currentIndex);
                    uv = StyleManager.GetTileUV(StyleManager.Tiles.Wall, uv);
                    currentIndex += 4;

                    if (i < WIDTH || (i >= WIDTH && layerTerrain[i - WIDTH] != 2))
                    {
                        verts = AddVerts(Shapes.RectWall, new Vector3(index2D.x - (WIDTH * 0.5f), DISTANCE_WALL, -index2D.y + (HEIGHT * 0.5f) + 1),
                            new Vector3(1, DISTANCE_WALL, 0), verts);
                        tris = AddTris(tris, currentIndex);
                        uv = StyleManager.GetTileUV(StyleManager.Tiles.WallSide, uv);
                        currentIndex += 4;
                    }
                    if (i % WIDTH == 0 || layerTerrain[i - 1] != 2)
                    {
                        verts = AddVerts(Shapes.RectWall, new Vector3(index2D.x - (WIDTH * 0.5f), DISTANCE_WALL, -index2D.y + (HEIGHT * 0.5f)),
                            new Vector3(0, DISTANCE_WALL, 1), verts);
                        tris = AddTris(tris, currentIndex);
                        uv = StyleManager.GetTileUV(StyleManager.Tiles.WallSide, uv);
                        currentIndex += 4;
                    }
                    if ((i + 1) % WIDTH == 0 || layerTerrain[i + 1] != 2)
                    {
                        verts = AddVerts(Shapes.RectWall, new Vector3(index2D.x - (WIDTH * 0.5f) + 1, DISTANCE_WALL, -index2D.y + (HEIGHT * 0.5f) + 1),
                            new Vector3(0, DISTANCE_WALL, -1), verts);
                        tris = AddTris(tris, currentIndex);
                        uv = StyleManager.GetTileUV(StyleManager.Tiles.WallSide, uv);
                        currentIndex += 4;
                    }
                    if ((i > dimensions - WIDTH - 1) || (i <= dimensions - WIDTH - 1 && layerTerrain[i + WIDTH] != 2))
                    {
                        verts = AddVerts(Shapes.RectWall, new Vector3(index2D.x - (WIDTH * 0.5f) + 1, DISTANCE_WALL, -index2D.y + (HEIGHT * 0.5f)),
                            new Vector3(-1,  DISTANCE_WALL, 0), verts);
                        tris = AddTris(tris, currentIndex);
                        uv = StyleManager.GetTileUV(StyleManager.Tiles.WallSide, uv);
                    }
                    break;
            }
            index2D.x++;
            if (index2D.x == WIDTH)
            {
                index2D.x = 0;
                index2D.y++;
            }
        }

        meshFilter = GetComponent<MeshFilter>();
        meshRender = GetComponent<MeshRenderer>();
        mesh = new Mesh
        {
            vertices = verts.ToArray(),
            triangles = tris.ToArray(),
            uv = uv.ToArray()
        };
        meshFilter.mesh = mesh;
        meshRender.material = new Material(Shader.Find("Standard"));
        meshRender.material.mainTexture = StyleManager.GetSheet();
    }

    void Update()
    {
        
    }

    private List<Vector3> AddVerts(Shapes shape, Vector3 topLeft, Vector3 bottomRightOffset, List<Vector3> currentList)
    {
        switch (shape)
        {
            default:
            case Shapes.FloorSqr:
                currentList.Add(topLeft);
                currentList.Add(new Vector3(topLeft.x + bottomRightOffset.x, topLeft.y, topLeft.z));
                currentList.Add(new Vector3(topLeft.x + bottomRightOffset.x, topLeft.y, topLeft.z - bottomRightOffset.z));
                currentList.Add(new Vector3(topLeft.x, topLeft.y, topLeft.z - bottomRightOffset.z));
                break;
            case Shapes.RectWall:
                currentList.Add(topLeft);
                currentList.Add(new Vector3(topLeft.x + bottomRightOffset.x, topLeft.y, topLeft.z + bottomRightOffset.z));
                currentList.Add(new Vector3(topLeft.x + bottomRightOffset.x, topLeft.y - bottomRightOffset.y, topLeft.z + bottomRightOffset.z));
                currentList.Add(new Vector3(topLeft.x, topLeft.y - bottomRightOffset.y, topLeft.z));
                break;
        }
        return currentList;
    }

    private List<int> AddTris(List<int> currentList, int currentIndex)
    {
        currentList.Add(currentIndex);
        currentList.Add(currentIndex + 2);
        currentList.Add(currentIndex + 1);
        currentList.Add(currentIndex + 2);
        currentList.Add(currentIndex);
        currentList.Add(currentIndex + 3);
        return currentList;
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
