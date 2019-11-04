using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class EnemySpawnedEvent : UnityEvent<Transform> { }
public class Enemy : MonoBehaviour
{
    public EnemySpawnedEvent onSpawn;

    [HideInInspector]
    public MoveTowardsObject moveScript;
    [HideInInspector]
    public SmoothLookAtTarget2D lookAtScript;

    private void Start()
    {

        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        moveScript = GetComponent<MoveTowardsObject>();
        moveScript.target = player;
        lookAtScript = GetComponent<SmoothLookAtTarget2D>();
        lookAtScript.target = player;
        

        //onSpawn.Invoke(player);
    }
}
