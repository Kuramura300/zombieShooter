using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public GameObject ShopCanvas;
    public GameObject player;
    public GameUI gameUIScript;

    [Header("Shop Text")]
    public Text gunDamageText;
    public Text shootSpeedText;
    public Text maxHealthText;

    [Header("Shop Buttons")]
    public Button gunDamageButton;
    public Button shootSpeedButton;
    public Button maxHealthButton;

    [Header("Button Text")]
    public Text gunDamageUpgradeText;
    public Text shootSpeedUpgradeText;
    public Text maxHealthUpgradeText;

    private float gunDamageCost = 100;
    private float shootSpeedCost = 10;
    private float maxHealthCost = 50;

    private bool maxGunDamage = false;
    private bool maxShootSpeed = false;
    private bool maxHealth = false;

    void Start()
    {
        
    }

    void Update()
    {
        //Displays the current value of the upgrades the player has
        gunDamageText.text = player.GetComponent<Weapon>().bulletDamage.ToString();
        shootSpeedText.text = player.GetComponent<Weapon>().fireTime.ToString("0.00");
        maxHealthText.text = player.GetComponent<HealthSystem>().maxHealth.ToString();

        //Updates upgrade button text to say the price of the upgrade
        gunDamageUpgradeText.text = "Upgrade: " + gunDamageCost.ToString("0");
        if (maxShootSpeed == false)
        {
            shootSpeedUpgradeText.text = "Upgrade: " + shootSpeedCost.ToString("0");
        }
        maxHealthUpgradeText.text = "Upgrade: " + maxHealthCost.ToString("0");

        //Disable upgrade button if player cannot afford upgrade
        if (gameUIScript.playerScore < gunDamageCost)
        {
            gunDamageButton.interactable = false;
        }
        else
        {
            if (maxGunDamage == false)
            {
                gunDamageButton.interactable = true;
            }
        }
        if (gameUIScript.playerScore < shootSpeedCost)
        {
            shootSpeedButton.interactable = false;
        }
        else
        {
            if (maxShootSpeed == false)
            {
                shootSpeedButton.interactable = true;
            }
        }
        if (gameUIScript.playerScore < maxHealthCost)
        {
            maxHealthButton.interactable = false;
        }
        else
        {
            if (maxHealth == false)
            {
                maxHealthButton.interactable = true;
            }
        }

        //Disable buttons at max upgrades
        if (player.GetComponent<Weapon>().bulletDamage == 20)
        {
            maxGunDamage = true;

            gunDamageButton.interactable = false;
        }
        if (player.GetComponent<Weapon>().fireTime < 0.04)
        {
            maxShootSpeed = true;

            shootSpeedButton.interactable = false;
        }
        if (player.GetComponent<HealthSystem>().maxHealth == 400)
        {
            maxHealth = true;

            maxHealthButton.interactable = false;
        }
    }

    public void toggleShop()
    {
        if (ShopCanvas.activeSelf == true)
        {
            ShopCanvas.SetActive(false);
        }
        else
        {
            ShopCanvas.SetActive(true);
        }
    }

    public void upgradeGunDamage()
    {
        player.GetComponent<Weapon>().bulletDamage += 1;

        //Spend players score and increases cost
        gameUIScript.playerScore -= gunDamageCost;
        gunDamageCost = gunDamageCost * 1.5f;
    }

    public void upgradeShootSpeed()
    {
        player.GetComponent<Weapon>().fireTime -= 0.02f;

        //Spend players score and increases cost
        gameUIScript.playerScore -= shootSpeedCost;
        shootSpeedCost = shootSpeedCost * 1.2f;
    }

    public void upgradeMaxHealth()
    {
        player.GetComponent<HealthSystem>().maxHealth += 10;
        player.GetComponent<HealthSystem>().health += 10;

        //Spend players score and increases cost
        gameUIScript.playerScore -= maxHealthCost;
        maxHealthCost = maxHealthCost * 1.3f;
    }
}
