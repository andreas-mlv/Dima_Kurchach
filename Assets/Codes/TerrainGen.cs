using System.Collections.Generic;
using UnityEngine;

public class TerrainGen : MonoBehaviour
{
    public GameObject cellPrefab;
    public Transform parentTransform;
    public int fieldSize = 8;
    public Color[] colors;

    private void Awake()
    {
        InitializeColors();
        GenerateField();
    }

    private void InitializeColors()
    {
        colors = new Color[6];
        colors[0] = new Color(0.0f, 1.0f, 0.0f); // Green (Plains)
        colors[1] = new Color(0.0f, 0.5f, 0.0f); // Dark Green (Forest)
        colors[2] = new Color(1.0f, 1.0f, 0.5f); // Light Yellow (Desert)
        colors[3] = new Color(0.8f, 0.8f, 0.8f); // Light Gray (Lowlands)
        colors[4] = new Color(0.1f, 0.1f, 0.1f); // Dark Gray (Mountains)
        colors[5] = new Color(0.0f, 0.0f, 0.7f); // Blue (River)
    }

    public void GenerateField()
    {
        for (int i = 1; i <= fieldSize * fieldSize; i++)
        {
            GameObject cell = GameObject.Find("Cell" + i);
            if (cell != null)
            {
                CellData cellData = CellDataManager.LoadCellData(i);
                if (cellData == null)
                {
                    TerrainType randomType = (TerrainType)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(TerrainType)).Length);

                    if ((int)randomType >= colors.Length)
                    {
                        UnityEngine.Debug.LogError("Color array does not have enough elements for the terrain types. Please ensure the colors array has enough elements.");
                        return;
                    }

                    Color color = colors[(int)randomType];
                    int woodAmount = GetWoodAmountForTerrainType(randomType);
                    int stoneAmount = GetStoneAmountForTerrainType(randomType);
                    cellData = new CellData(i, randomType, color, woodAmount, stoneAmount);
                    CellDataManager.SaveCellData(cellData);
                }

                CellTap cellTap = cell.GetComponent<CellTap>();
                if (cellTap != null)
                {
                    cellTap.cellData = cellData;
                }

                Renderer renderer = cell.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = cellData.color;
                }
            }
            else
            {
                UnityEngine.Debug.LogWarning("Cell with name 'Cell" + i + "' not found.");
            }
        }
    }

    private int GetWoodAmountForTerrainType(TerrainType type)
    {
        switch (type)
        {
            case TerrainType.Plains: return UnityEngine.Random.Range(1, 4);
            case TerrainType.Forest: return UnityEngine.Random.Range(3, 6);
            case TerrainType.Desert: return UnityEngine.Random.Range(0, 3);
            case TerrainType.Lowlands: return UnityEngine.Random.Range(1, 4);
            case TerrainType.Mountains: return UnityEngine.Random.Range(0, 2);
            case TerrainType.River: return 0;
            default: return 0;
        }
    }

    private int GetStoneAmountForTerrainType(TerrainType type)
    {
        switch (type)
        {
            case TerrainType.Plains: return UnityEngine.Random.Range(0, 3);
            case TerrainType.Forest: return UnityEngine.Random.Range(1, 4);
            case TerrainType.Desert: return UnityEngine.Random.Range(2, 5);
            case TerrainType.Lowlands: return UnityEngine.Random.Range(3, 6);
            case TerrainType.Mountains: return UnityEngine.Random.Range(3, 6);
            case TerrainType.River: return 0;
            default: return 0;
        }
    }
}
