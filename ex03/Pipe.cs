using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Measurements:
spawn = 9.7 x
despawn = -11.38 x
lowest pipe = -1.2 y
highest pipe = 3.3 y
hitbox = (-1.34x to 1.34x) (-1.48y to 1.1y)
*/

public class Pipe : MonoBehaviour
{
    private GameObject obj_bird;
    [SerializeField] float spawn_x;
    [SerializeField] float despawn_x;
    [SerializeField] float hb_left;
    [SerializeField] float hb_right;
    [SerializeField] float hb_down;
    [SerializeField] float hb_up;
    [SerializeField] float speed_pipe;
    private bool added_point;
    [SerializeField] float difficulty;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("bird"))
            obj_bird = GameObject.Find("bird");
        added_point = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool stop = obj_bird.GetComponent<Bird>().dead;
        Vector3 this_pos = this.gameObject.transform.position;
        if (!stop)
        {
            this.gameObject.transform.position = new Vector3(this_pos.x - speed_pipe * (obj_bird.GetComponent<Bird>().score * difficulty / 10 + 1), this_pos.y, 0);
            if (this_pos.x <= -1.34 && !added_point)
            {
                obj_bird.GetComponent<Bird>().score += 5;
                added_point = true;
            }
            Vector3 bird_pos = obj_bird.gameObject.transform.position;
            if (bird_pos.x >= this_pos.x + hb_left && bird_pos.x <= this_pos.x + hb_right &&
                    !(bird_pos.y >= this_pos.y + hb_down && bird_pos.y <= this_pos.y + hb_up))
                obj_bird.GetComponent<Bird>().dead = true;
            if (this_pos.x <= despawn_x)
            {  
                this.gameObject.transform.position = new Vector3(spawn_x, this_pos.y, 0);
                added_point = false;
            }
        }
    }
}
