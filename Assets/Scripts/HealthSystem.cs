using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }
public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    public UnityEvent onDie;
    public OnDamagedEvent onDamaged;
    public void TakeDamage(int damage)
    {
        health -= damage;
        onDamaged.Invoke(health);
        if (health < 1)
        {
            if (gameObject.name == "Hero")
            {
                onDie.Invoke();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}