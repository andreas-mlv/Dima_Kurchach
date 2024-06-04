using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class SaveManager : MonoBehaviour
{
    public TerrainGen terrainGen;

    void Awake()
    {
        if (terrainGen == null)
        {
            terrainGen = FindObjectOfType<TerrainGen>();
        }
    }

    public void SaveGame(int slot)
    {
        if (terrainGen == null)
        {
            UnityEngine.Debug.LogError("TerrainGen is not assigned.");
            return;
        }

        string path = UnityEngine.Application.persistentDataPath + "/save" + slot + ".dat";
        SaveField(path);
        UnityEngine.Debug.Log($"Game saved in slot {slot}");
    }

    public void LoadGame(int slot)
    {
        string path = UnityEngine.Application.persistentDataPath + "/save" + slot + ".dat";
        if (File.Exists(path))
        {
            if (terrainGen == null)
            {
                UnityEngine.Debug.LogError("TerrainGen is not assigned.");
                return;
            }

            LoadField(path);
            UnityEngine.Debug.Log($"Game loaded from slot {slot}");
        }
        else
        {
            UnityEngine.Debug.LogError($"No save data found in slot {slot}");
        }
    }

    private void SaveField(string path)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(path);

        CellData[] fieldData = new CellData[terrainGen.fieldSize * terrainGen.fieldSize];
        for (int i = 1; i <= terrainGen.fieldSize * terrainGen.fieldSize; i++)
        {
            CellData cellData = CellDataManager.LoadCellData(i);
            if (cellData != null)
            {
                fieldData[i - 1] = cellData;
            }
        }

        formatter.Serialize(file, fieldData);
        file.Close();
    }

    private void LoadField(string path)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(path, FileMode.Open);

        CellData[] fieldData = (CellData[])formatter.Deserialize(file);
        file.Close();

        for (int i = 0; i < fieldData.Length; i++)
        {
            CellData cellData = fieldData[i];
            if (cellData != null)
            {
                GameObject cell = GameObject.Find("Cell" + cellData.cellNumber);
                if (cell != null)
                {
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
            }
        }
    }
}
