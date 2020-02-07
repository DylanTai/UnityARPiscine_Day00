using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeSpawner : MonoBehaviour
{
    private int time;
    [SerializeField] private int min_spawntime;
    [SerializeField] private int max_spawntime;
    [SerializeField] GameObject obj_Cube;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        score = 0;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (time <= 0)
            time = Random.Range(min_spawntime, max_spawntime);
        time -= 1;
        if (time <= 0)
            Instantiate(obj_Cube);
    }
}
