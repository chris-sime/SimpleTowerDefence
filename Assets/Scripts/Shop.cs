using UnityEngine;
public class Shop : MonoBehaviour {

    public TurretBlueprint standartTurret;
    public TurretBlueprint missileTurret;
    public TurretBlueprint laserTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurret()
    {
        Debug.Log("STANDART TURRET SELECTED");
        buildManager.SelectTurretToBuild(standartTurret);
    }
    public void SelectMissileTurret()
    {
        Debug.Log("Missile TURRET SELECTED");
        buildManager.SelectTurretToBuild(missileTurret);
    }
    public void SelectLaserTurret()
    {
        Debug.Log("Laser TURRET SELECTED");
        buildManager.SelectTurretToBuild(laserTurret);
    }
}
