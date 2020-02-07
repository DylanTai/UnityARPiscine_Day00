using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private GameObject obj_club;
    public int speed;
    public bool destroyed;
    public int direction;
    [SerializeField] GameObject obj_lwall;
    [SerializeField] GameObject obj_rwall;
    [SerializeField] GameObject obj_hole;
    // Start is called before the first frame update
    [SerializeField] float speed_divdr;
    [SerializeField] float margin_of_error;
    [SerializeField] int speed_threshold;


    void Start()
    {
        Application.targetFrameRate = 60;
        if (GameObject.Find("club"))
            obj_club = GameObject.Find("club");
        speed = 0;
        destroyed = false;
        direction = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (!destroyed)
        {
            if (speed > 0)
            {
                Vector3 this_pos = this.gameObject.transform.position;
                if (this_pos.x <= obj_lwall.gameObject.transform.position.x + 1.5)
                    direction = 1;
                else if (this_pos.x >= obj_rwall.gameObject.transform.position.x - 1.5)
                    direction = -1;
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + speed/speed_divdr * direction, 1, -0.01f);
                speed -= 1;
                if (this_pos.x >= obj_hole.gameObject.transform.position.x - margin_of_error && this_pos.x <= obj_hole.gameObject.transform.position.x + margin_of_error && speed <= speed_threshold)
                    destroyed = true;
            }
        }
        else
        {
            if (this.gameObject.transform.localScale.x > 0)
            {
                Vector3 this_scale = this.gameObject.transform.localScale;
                this.gameObject.transform.localScale = new Vector3(this_scale.x - 0.01f, this_scale.y - 0.01f, this_scale.z);
            }
            else
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
