using UnityEngine;
public class HurtTrigger : MonoBehaviour
{
    public int startDamage;
    public int damage;
    public float resetTime = 0.25f;

    public bool inspired = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        GetComponent<Collider2D>().enabled = false;
        Invoke("ResetTrigger", resetTime);
    }
    private void ResetTrigger()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    private void Start()
    {
        damage = startDamage;
    }

    private void Update()
    {
        if (inspired == true)
        {
            damage = startDamage * 2;
        }
        else
        {
            damage = startDamage;
        }
    }
}