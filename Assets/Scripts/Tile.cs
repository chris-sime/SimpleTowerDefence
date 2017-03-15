using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour {

    public Color hoverColor;
    public Color invalidLocationColor;
    public Vector3 positionOffset;
    private Color initialColor;
    private Renderer r;

    [Header("OPTIONAL")]
    public GameObject turret;
    public TurretBlueprint turretBlueprint;

    [HideInInspector]
    public bool isFullyUpgraded = false;

    BuildManager buildManager;
    UIManager UiManager;

    private GameObject hoverTurret;
    void Start()
    {
        r = GetComponent<Renderer>();
        initialColor = r.material.color;
        buildManager = BuildManager.instance;
        UiManager = UIManager.instance;

        if(turret != null)
        {
            Instantiate(turret, GetBuildPosition(), Random.rotation);
        }
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }


    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (turret != null || !buildManager.HasMoney)
        {
            r.material.color = invalidLocationColor;         
            
        }
        else
        {
            r.material.color = hoverColor;
            hoverTurret = (GameObject)Instantiate(buildManager.GetTurretToBuild().inactivePrefab, GetBuildPosition(), Quaternion.identity);
            
        }
        
    }

    void OnMouseExit()
    {
        r.material.color = initialColor;
        Destroy(hoverTurret);
        
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildManager.SelectTile(this);
            Debug.Log("Can't build here");
            return;
        }

        if (!buildManager.CanBuild) return;

        BuildTurret(buildManager.GetTurretToBuild());
        

    }

    void BuildTurret(TurretBlueprint blueprint)
    {

        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough resources");
            return;
        }

        
        PlayerStats.Money -= blueprint.cost;
        //Build a turret                       
        GameObject t = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = t;                     
        //Move buildEffect to turretBlueprint for every tower to has its own build effect
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);

        turretBlueprint = blueprint;

        UiManager.MoneyUi.text = PlayerStats.Money.ToString();

        Debug.Log("Build Succesfull! \nMoney Left:" + PlayerStats.Money);
        buildManager.UnselectAll();
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough resources to Upgrade");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //Remove Old turret
        Destroy(turret);

        //Create new turret                       
        GameObject t = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = t;
        //Move buildEffect to turretBlueprint for every tower to has its own build effect
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);

        UiManager.MoneyUi.text = PlayerStats.Money.ToString();

        //Remove When Tower Levels is isFullyUpgraded
        isFullyUpgraded = true;

        Debug.Log("Upgrade Succesfull! \nMoney Left:" + PlayerStats.Money);
        buildManager.UnselectAll();

    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        UiManager.MoneyUi.text = PlayerStats.Money.ToString();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);

        Destroy(turret);
        turretBlueprint = null;
        isFullyUpgraded = false;
    }
}
