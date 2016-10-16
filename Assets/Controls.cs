using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
        speed = 3;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y -  speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y +  speed);
        }
    }
}
