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

    //Wave difficulty variables
    public int difficultyLevel = 1;
    private int waveSpawnCounter = 0;
    private bool diffIncreased = false;
    public int spawnerRange = 1;
    private bool rangeTo2 = false;
    private bool rangeTo3 = false;

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
                waveSpawnCounter = 0;
                diffIncreased = false;
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

        //Wave Difficulty Progression
        //---------------------------------------------------
        //-Increases difficulty every 2 waves
        if (waveCount % 2 == 0)
        {
            if (diffIncreased == false)
            {
                difficultyLevel++;

                diffIncreased = true;
            }
        }
        //-Introduce Runners from wave 5
        if (rangeTo2 == false)
        {
            if (waveCount >= 5)
            {
                spawnerRange = 2;

                rangeTo2 = true;
            }
        }
        //-Introduce Buffers from wave 10
        if (rangeTo3 == false)
        {
            if (waveCount >= 10)
            {
                spawnerRange = 3;

                rangeTo3 = true;
            }
        }
        //---------------------------------------------------
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
            waveSpawnCounter++;

            foreach (GameObject spawner in EnemySpawners)
            {
                spawner.SetActive(false);
            }

            if (waveSpawnCounter < difficultyLevel)
            {
                repeatCount = 0;
            }
        }
    }

    public void activateSpawner()
    {
        EnemySpawners[repeatCount].SetActive(true);
    }
}
