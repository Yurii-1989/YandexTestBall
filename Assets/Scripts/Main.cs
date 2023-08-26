using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] private GameObject StartText;

    [SerializeField] private int Score;
    public GameObject SpownPoint;
    public GameObject[] SquaresCoins;

    private bool paused;
    [SerializeField] private Text ScoreText;
    private float RandomSecondsForSpawn;
    private float CurrentSeconds;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = Score.ToString();
        Time.timeScale = 0;
        paused = true;
        RandomSecondsForSpawn = Random.RandomRange(0.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentSeconds += Time.deltaTime;
        if(CurrentSeconds>= RandomSecondsForSpawn)
        {
            CurrentSeconds = 0;
            RandomSecondsForSpawn = Random.RandomRange(0.5f, 1.5f);
            Spawn();
        }

        if(Input.GetButtonDown("Jump")|| Input.GetButtonDown("Fire1")&& paused)
        {
            StartText.SetActive(false);
            paused = false;
            Time.timeScale = 1;
        }
    }

    public void ScoreSum()
    {
        Score += 1;
        ScoreText.text = Score.ToString();
    }

    private void Spawn()
    {
        
        Vector3 SpawnTransform = new Vector3(SpownPoint.transform.position.x, Random.RandomRange(-2.5f, 2.5f), SpownPoint.transform.position.z);
        GameObject CurrentSpawnObject = Instantiate(SquaresCoins[Random.RandomRange(0, 4)], SpawnTransform, SpownPoint.transform.rotation);
        Destroy(CurrentSpawnObject, 4);
    }

    public void Death()
    {
        SceneManager.LoadScene(0);
    }


}
