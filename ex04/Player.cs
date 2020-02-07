using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject p1;
    [SerializeField] GameObject p2;
    private float up_boundary;
    private float down_boundary;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        speed /= 100f;
        up_boundary = 6f;
        down_boundary = -3.9f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p1_pos = p1.transform.position;
        Vector3 p2_pos = p2.transform.position;
        if (Input.GetKey("w") && p1_pos.y < up_boundary)
            p1.transform.Translate(Vector3.up * speed);
        if (Input.GetKey("s") && p1_pos.y > down_boundary)
            p1.transform.Translate(Vector3.down * speed);
        if (Input.GetKey("up") && p2_pos.y < up_boundary)
            p2.transform.Translate(Vector3.up * speed);
        if (Input.GetKey("down") && p2_pos.y > down_boundary)
            p2.transform.Translate(Vector3.down * speed);
    }
}
