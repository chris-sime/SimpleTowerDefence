using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    void Awake()
    {
        instance = this;
    }

    //UIManager UiManager;

    void Start()
    {
        //UiManager = UIManager.instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) UnselectAll();
    }

    
    private TurretBlueprint turretToBuild;
    private Tile selectedTile;
    public GameObject standartTurretPrefab;
    public GameObject missileTurretPrefab;
    public GameObject buildEffect;
    public GameObject sellEffect;

    public TileUi tileUi;
    

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedTile = null;
        tileUi.Hide();
    }

    public void SelectTile(Tile tile)
    {
        if (selectedTile == tile)
        {
            UnselectAll();
            return;
        }

        selectedTile = tile;
        turretToBuild = null;

        tileUi.SetTarget(selectedTile);
    }

    public void UnselectAll()
    {
        selectedTile = null;
        turretToBuild = null;
        tileUi.Hide();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

}
