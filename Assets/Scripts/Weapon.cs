using UnityEngine;
public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    private bool isFiring = false;
    public int bulletDamage = 1;
    private void SetFiring()
    {
        isFiring = false;
    }
    private void Fire()
    {
        isFiring = true;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        bullet.GetComponent<Bullet>().damage = bulletDamage;

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        Invoke("SetFiring", fireTime);
    }
    private void Update()
    {
        if (GameObject.Find("EventSystem").GetComponent<PauseScript>().paused == false)
        {
            if (Input.GetMouseButton(0))
            {
                if (!isFiring)
                {
                    Fire();
                }
            }
        }
    }
}
