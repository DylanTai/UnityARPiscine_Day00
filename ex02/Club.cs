using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
    private int score;
    [SerializeField] GameObject obj_ball;
    [SerializeField] GameObject obj_hole;
    private Vector3 reset_pos;
    private int power;
    private bool hidden;
    private bool incrementing;
    [SerializeField] int max_power;
    [SerializeField] int increment_power;
    public int pos_multi;

    // Start is called before the first frame update
    void Start()
    {
        score = -15;
        power = 0;
        hidden = false;
        incrementing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!obj_ball.GetComponent<Ball>().destroyed)
        {
            Vector3 ball_pos = obj_ball.gameObject.transform.position;
            reset_pos = new Vector3(ball_pos.x + pos_multi * 1f, ball_pos.y + 0.5f, 0.01f);
            Vector3 hole_pos = obj_hole.gameObject.transform.position;
            if (ball_pos.x < hole_pos.x)
                pos_multi = -1;
            else
                pos_multi = 1;
            if (obj_ball.GetComponent<Ball>().speed > 0 || obj_ball.GetComponent<Ball>().destroyed)
            {
                hidden = true;
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                hidden = false;
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            if (!hidden && !Input.GetKey("space"))
            {
                if (power != 0)
                {
                    obj_ball.GetComponent<Ball>().speed = power;
                    obj_ball.GetComponent<Ball>().direction = pos_multi * -1;
                    incrementing = true;
                    power = 0;
                    score += 5;
                }
                this.gameObject.transform.position = reset_pos;
            }
            else if (!hidden && Input.GetKey("space"))
            {
                if (incrementing && power < max_power)
                    power += increment_power;
                else if (incrementing)
                    incrementing = false;
                if (!incrementing && power > 0)
                    power -= increment_power;
                else if (!incrementing)
                    incrementing = true;
                this.gameObject.transform.position = new Vector3(ball_pos.x + pos_multi * (1f + power/42f), ball_pos.y + 0.5f, 0.01f);
            }
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("Score: " + score);
        }
    }
}
