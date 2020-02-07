using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
paddle_hb = +-0.95y +-0.2x
exit_room = +-10.41x
*/

public class PongBall : MonoBehaviour
{
    private int score_p1;
    private int score_p2;
    private int direction;
    [SerializeField] float speed;
    private float new_speed;
    [SerializeField] GameObject p1;
    [SerializeField] GameObject p2;
    private bool rerandom;
    private float paddle_hb_x;
    private float paddle_hb_y;
    [SerializeField] float speed_add;

    // Start is called before the first frame update
    void Start()
    {
        speed /= 100;
        score_p1 = 0;
        score_p2 = 0;
        rerandom = true;
        paddle_hb_x = 0.2f;
        paddle_hb_y = 0.95f;
    }
    void print_score()
    {
        Debug.Log("Player 1: " + score_p1 + " | Player 2: " + score_p2 + "\n");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (rerandom)
        {
            direction = Random.Range(0, 4);
            this.transform.position = new Vector3(0, 1, 0);
            new_speed = speed;
            rerandom = false;
        }
        if (direction == 0)
        {
           this.transform.Translate(Vector3.up * new_speed);
           this.transform.Translate(Vector3.left * new_speed);
        }
        else if (direction == 1)
        {
           this.transform.Translate(Vector3.up * new_speed);
           this.transform.Translate(Vector3.right * new_speed);
        }
        else if (direction == 2)
        {
           this.transform.Translate(Vector3.down * new_speed);
           this.transform.Translate(Vector3.right * new_speed);
        }
        else if (direction == 3)
        {
           this.transform.Translate(Vector3.down * new_speed);
           this.transform.Translate(Vector3.left * new_speed);
        }
        Vector3 this_pos = this.transform.position;
        if (this_pos.y >= 6.6f || this_pos.y <= -4.55)
        {
            if (direction == 0)
                direction = 3;
            else if (direction == 1)
                direction = 2;
            else if (direction == 2)
                direction = 1;
            else if (direction == 3)
                direction = 0;
        }
        Vector3 p1_pos = p1.transform.position;
        Vector3 p2_pos = p2.transform.position;
        if ((this_pos.x >= p1_pos.x - paddle_hb_x &&
                this_pos.x <= p1_pos.x + paddle_hb_x && 
                this_pos.y >= p1_pos.y - paddle_hb_y &&
                this_pos.y <= p1_pos.y + paddle_hb_y) ||
                (this_pos.x >= p2_pos.x - paddle_hb_x &&
                this_pos.x <= p2_pos.x + paddle_hb_x && 
                this_pos.y >= p2_pos.y - paddle_hb_y &&
                this_pos.y <= p2_pos.y + paddle_hb_y))
        {
            if (direction == 0)
                direction = 1;
            else if (direction == 1)
                direction = 0;
            else if (direction == 2)
                direction = 3;
            else if (direction == 3)
                direction = 2;
            new_speed += speed_add / 100f;
        }
        if (this_pos.x >= 10.41f || this_pos.x <= -10.41f)
        {
            if (this_pos.x >= 10.41f)
                score_p1++;
            else
                score_p2++;
            rerandom = true;
            print_score();
        }
    }
}
