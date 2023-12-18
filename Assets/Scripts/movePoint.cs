using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePoint : MonoBehaviour
{

    public float forceMultiplier = 10;
    public ForceMode2D forceMode;

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
    }

}
