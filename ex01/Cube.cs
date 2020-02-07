using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float type;
    private int speed;
    [SerializeField] private int min_speed;
    [SerializeField] private int max_speed;
    [SerializeField] private float margin_of_error;
    [SerializeField] GameObject a_detection;
    [SerializeField] GameObject s_detection;
    [SerializeField] GameObject d_detection;
    private GameObject line;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("line"))
            line = GameObject.Find("line");
        type = Random.Range(0, 3);
        if (type == 0)
            GetComponent<SpriteRenderer>().color = new Color (255, 0, 0, 255);
        else if (type == 1)
            GetComponent<SpriteRenderer>().color = new Color (0, 66, 255, 255);
        else if (type == 2)
            GetComponent<SpriteRenderer>().color = new Color (205, 255, 0, 255);
        speed = Random.Range(min_speed, max_speed);
    }

    // Update is called once per frame
    void Update()
    {
        float pos_x = 0f;
        if (type == 0)
            pos_x = -2.96f;
        else if (type == 2)
            pos_x = 2.96f;
        float dist = this.gameObject.transform.position.y;
        float pos_y = dist - speed/1000f;
        this.gameObject.transform.position = new Vector3(pos_x, pos_y, -1);
        if (Input.GetKeyDown("a") && type == 0)
        {
            dist -= a_detection.gameObject.transform.position.y;
            Debug.Log("Precision: " + dist * 100 + "\n");
            if (dist <= margin_of_error && dist >= margin_of_error * -1)
            {
                line.GetComponent<CubeSpawner>().score++;
                Destroy(this.gameObject);
            }
        }
        if (Input.GetKeyDown("s") && type == 1)
        {
            dist -= s_detection.gameObject.transform.position.y;
            Debug.Log("Precision: " + dist * 100 + "\n");
            if (dist <= margin_of_error && dist >= margin_of_error * -1)
            {
                line.GetComponent<CubeSpawner>().score++;
                Destroy(this.gameObject);
            }
        }
        if (Input.GetKeyDown("d") && type == 2)
        {
            dist -= d_detection.gameObject.transform.position.y;
            Debug.Log("Precision: " + dist * 100 + "\n");
            if (dist <= margin_of_error && dist >= margin_of_error * -1)
            {
                line.GetComponent<CubeSpawner>().score++;
                Destroy(this.gameObject);
            }
        }
        if (dist <= -5)
            Destroy(this.gameObject);
    }
}
