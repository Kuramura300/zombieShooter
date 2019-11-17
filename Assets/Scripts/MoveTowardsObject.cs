using UnityEngine;
public class MoveTowardsObject : MonoBehaviour
{
    public Transform target;
    public float speed = 5.0f;
    private void Update()
    {
        if (GameObject.Find("EventSystem").GetComponent<PauseScript>().paused == false)
        {
            if (target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * 0.01f);
            }
        }
    }
    public void SetTarget(Transform newTarget)
    {
        print(newTarget);
        target = newTarget;
    }

}
