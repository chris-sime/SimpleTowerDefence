using UnityEngine;


[System.Serializable]
public class TurretBlueprint {

    public GameObject prefab;
    public int cost;
    public GameObject inactivePrefab;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}
