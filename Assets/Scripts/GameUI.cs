using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{
    public Slider healthBar;
    public Text scoreText;
    public float playerScore = 0;
    public float totalScore;
    private void OnEnable()
    {
        Player.OnUpdateHealth += UpdateHealthBar;
        AddScore.OnSendScore += UpdateScore;
    }
    private void OnDisable()
    {
        Player.OnUpdateHealth -= UpdateHealthBar;
        AddScore.OnSendScore -= UpdateScore;
    }
    private void UpdateHealthBar(int health)
    {
        healthBar.value = health;
    }
    private void UpdateScore(int theScore)
    {
        playerScore += theScore;
        totalScore += theScore;
    }

    void Update()
    {
        healthBar.maxValue = GameObject.Find("Hero").GetComponent<HealthSystem>().maxHealth;
        healthBar.value = GameObject.Find("Hero").GetComponent<HealthSystem>().health;
        scoreText.text = "SCORE: " + playerScore.ToString("0");
    }
}
