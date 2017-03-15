using UnityEngine;
using UnityEngine.UI;

public class TileUi : MonoBehaviour {

    public GameObject UI;

    public Text upgradeCost;
    public Text sellAmount;

    public Button upgradeButton;
    private Tile target;

    public void SetTarget(Tile target)
    {
        this.target = target;
        transform.position = target.GetBuildPosition();

        if (target.isFullyUpgraded)
        {
            upgradeButton.interactable = false;
            upgradeCost.text = "Fully Upgraded";
        }else
        {
            upgradeCost.text = target.turretBlueprint.upgradeCost.ToString();
            upgradeButton.interactable = true;
        }

        sellAmount.text = target.turretBlueprint.GetSellAmount().ToString();

        
        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.UnselectAll();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.UnselectAll();
    }
}
