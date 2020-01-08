using UnityEngine;
public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;

    public GameObject[] enemies;
    //0 - Walker
    //1 - Runner
    //2 - Buffer
    public int upperRange;

    public float adjustmentAngle = 0;
    public void Spawn()
    {
        Vector3 rotationInDegrees = transform.eulerAngles;
        rotationInDegrees.z += adjustmentAngle;
        Quaternion rotationInRadians = Quaternion.Euler(rotationInDegrees);

        upperRange = GameObject.Find("EventSystem").GetComponent<WaveScript>().spawnerRange;
        prefabToSpawn = enemies[Random.Range(0, upperRange)];

        var enemy = Instantiate(prefabToSpawn, transform.position, rotationInRadians);
        enemy.GetComponent<HealthSystem>().health += GameObject.Find("EventSystem").GetComponent<WaveScript>().difficultyLevel;
    }
}
