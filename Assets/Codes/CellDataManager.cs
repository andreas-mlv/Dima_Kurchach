using UnityEngine;

public static class CellDataManager
{
    public static void SaveCellData(CellData cellData)
    {
        string json = JsonUtility.ToJson(cellData);
        PlayerPrefs.SetString("CellData_" + cellData.cellNumber, json);
    }

    public static CellData LoadCellData(int cellNumber)
    {
        string json = PlayerPrefs.GetString("CellData_" + cellNumber, null);
        if (!string.IsNullOrEmpty(json))
        {
            return JsonUtility.FromJson<CellData>(json);
        }
        return null;
    }
}
