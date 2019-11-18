using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public GameObject ShopCanvas;
    public GameObject player;

    [Header("Shop Text")]
    public Text gunDamageText;
    public Text shootSpeedText;
    public Text maxHealthText;

    void Start()
    {
        
    }

    void Update()
    {
        gunDamageText.text = player.GetComponent<Weapon>().bulletDamage.ToString();
        shootSpeedText.text = player.GetComponent<Weapon>().fireTime.ToString("0.00");
        maxHealthText.text = player.GetComponent<HealthSystem>().maxHealth.ToString();
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
    }

    public void upgradeShootSpeed()
    {
        player.GetComponent<Weapon>().fireTime -= 0.02f;
    }

    public void upgradeMaxHealth()
    {
        player.GetComponent<HealthSystem>().maxHealth += 5;
        player.GetComponent<HealthSystem>().health += 5;
    }
}
