using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePoint : MonoBehaviour
{

    public float forceMultiplier = 10;
    public ForceMode2D forceMode;
    public float maxSpeed = 4;

    private float moveX;
    private float moveY;

    private GameObject point;

    // Start is called before the first frame update
    void Start()
    {
        point = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
    }


    private void FixedUpdate()
    {
        point.GetComponent<Rigidbody2D>().AddForce(new Vector3(moveX * forceMultiplier, moveY * forceMultiplier, 0), forceMode);
        if (point.GetComponent<Rigidbody2D>().velocity.x > maxSpeed) point.GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, point.GetComponent<Rigidbody2D>().velocity.y);
        if (point.GetComponent<Rigidbody2D>().velocity.y > maxSpeed) point.GetComponent<Rigidbody2D>().velocity = new Vector2(point.GetComponent<Rigidbody2D>().velocity.x, maxSpeed);
        if (point.GetComponent<Rigidbody2D>().velocity.x < -maxSpeed) point.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, point.GetComponent<Rigidbody2D>().velocity.y);
        if (point.GetComponent<Rigidbody2D>().velocity.y < -maxSpeed) point.GetComponent<Rigidbody2D>().velocity = new Vector2(point.GetComponent<Rigidbody2D>().velocity.x, -maxSpeed);
    }

}
