using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public int score;
    public bool dead;
    private int speed;
    [SerializeField] float grav_multi;
    [SerializeField] int jump_amt;
    private bool destroyed;
    private bool displayed;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        score = 0;
        dead = false;
        speed = 0;
        destroyed = false;
        displayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (!destroyed)
        {
            Vector3 this_pos = this.gameObject.transform.position;
            this.transform.Rotate(0, 0, speed / 3f, Space.Self);
            if (!dead && Input.GetKeyDown("space"))
            {
                this.transform.Rotate(0, 0, (jump_amt - speed) / 3f, Space.Self);
                speed = jump_amt;
            }
            this.gameObject.transform.position = new Vector3(this_pos.x, this_pos.y + grav_multi * speed, this_pos.z);
            if (this_pos.y < -4.4f || this_pos.y > 6.4f)
                dead = true;
            speed--;
            if (this_pos.y < -5.2f)
                destroyed = true;
        }
        else if (!displayed)
        {
            Debug.Log("Score: " + score + "\nTime: " + Mathf.RoundToInt(Time.realtimeSinceStartup) + "s\n");
            displayed = true;
        }
    }
}
