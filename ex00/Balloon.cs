using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Balloon : MonoBehaviour
{
    [SerializeField] private int total_air;
    [SerializeField] private int total_breath;
    [SerializeField] private int max_breath;
    [SerializeField] private int max_air;
    [SerializeField] GameObject obj_breath_bar;
    private float time;
    private bool game_over;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        time = 0;
        game_over = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (!game_over)
        {
            this.gameObject.transform.localScale = new Vector3(total_air / 50f, total_air / 50f, -1);
            obj_breath_bar.transform.localScale = new Vector3(0.5f, total_breath / 12f, 0.01f);
            if (Input.GetKeyDown("space") && total_breath >= 30)
            {
                total_breath -= 30;
                total_air += 30;
            }
            if (total_breath < max_breath)
                total_breath += 1;
            time += 1f/60f;
            total_air -= 1;
            if (total_air <= 10 || total_air >= max_air)
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                game_over = true;
                Debug.Log("Balloon life time: " + Mathf.RoundToInt(time) + "s\n");
            }
        }
    }
}
