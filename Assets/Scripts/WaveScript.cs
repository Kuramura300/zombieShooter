using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WaveScript : MonoBehaviour
{
    public int waveCount = 1;
    public Text waveText;
    private bool changingTextColor = false;
    private float changingTextColorTimer = 0;
    private float waveCheckTimer = 0;

    public GameObject[] EnemySpawners;

    public float cooldown = 1;
    public UnityEvent onTimerComplete;

    private int repeatCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject spawner in EnemySpawners)
        {
            spawner.SetActive(false);
        }

        InvokeRepeating("OnTimerComplete", 0, cooldown);
    }

    // Update is called once per frame
    void Update()
    {
        waveText.text = ("Wave: " + waveCount);

        //Check if all enemies defeated then progress to next wave
        if (waveCheckTimer > 5)
        {
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                waveCount++;

                changingTextColor = true;

                repeatCount = 0;
            }

            waveCheckTimer = 0;
        }
        else
        {
            waveCheckTimer += Time.deltaTime;
        }

        //Makes the Wave Number text turn red for a second when wave progresses
        if (changingTextColor == true)
        {
            waveText.color = Color.red;

            changingTextColorTimer += Time.deltaTime;

            if (changingTextColorTimer > 1)
            {
                waveText.color = Color.white;

                changingTextColor = false;

                changingTextColorTimer = 0;
            }
        }
    }

    private void OnTimerComplete()
    {
        if (repeatCount < EnemySpawners.Length)
        {
            onTimerComplete.Invoke();

            repeatCount++;
        }
        else
        {
            foreach (GameObject spawner in EnemySpawners)
            {
                spawner.SetActive(false);
            }
        }
    }

    public void activateSpawner()
    {
        EnemySpawners[repeatCount].SetActive(true);
    }
}
