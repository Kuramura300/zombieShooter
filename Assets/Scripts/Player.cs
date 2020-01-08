using UnityEngine;
public class Player : MonoBehaviour
{
    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;

    private Animator gunAnim;

    public GameObject gameOverScreen;
    private void Start()
    {
        gunAnim = GetComponent<Animator>();
    }
    private void Update()
    {
        //if (GameObject.Find("EventSystem").GetComponent<PauseScript>().paused == false)
        //{
        //    if (Input.GetMouseButton(0))
        //    {
        //        gunAnim.SetBool("isFiring", true);
        //    }
        //    else
        //    {
        //        gunAnim.SetBool("isFiring", false);
        //    }
        //}
    }
    public void SendHealthData(int health)
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;

        gameOverScreen.SetActive(true);
    }

}
