using UnityEngine;

[System.Serializable]
public class CellData
{
    public int cellNumber;
    public TerrainType terrainType;
    public Color color;
    public int wood;
    public int stone;

    public CellData(int cellNumber, TerrainType terrainType, Color color, int wood, int stone)
    {
        this.cellNumber = cellNumber;
        this.terrainType = terrainType;
        this.color = color;
        this.wood = wood;
        this.stone = stone;
    }
}
