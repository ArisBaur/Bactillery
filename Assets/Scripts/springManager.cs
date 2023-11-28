using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class springManager : MonoBehaviour
{
    public massPointManager startPoint;
    public massPointManager endPoint;

    public float restingLength = 2f;
    public float springConstant = 10f;

    float length;
    float rotation;

    GameObject spring;

    void Start()
    {
        spring = gameObject;
    }

    void FixedUpdate()
    {
        ManageTransform();
        ManageLength();
    }

    void ManageLength()
    {
        Vector2 delta = endPoint.transform.position - startPoint.transform.position;
        length = delta.magnitude;
        spring.transform.localScale = new Vector3(0.05f, length / 2, 1);

        float springForceMagnitude = springConstant * (length - restingLength);
        Vector2 springForce = springForceMagnitude * delta.normalized;
        startPoint.AddForce(springForce);
        endPoint.AddForce(-springForce);
    }

    void ManageTransform()
    {
        float x1 = startPoint.transform.position.x;
        float y1 = startPoint.transform.position.y;
        float x2 = endPoint.transform.position.x;
        float y2 = endPoint.transform.position.y;

        rotation = Mathf.Atan2(y2 - y1, x2 - x1) * Mathf.Rad2Deg;
        rotation = (rotation + 360) % 360;

        spring.transform.rotation = Quaternion.Euler(0f, 0f, rotation + 90);
        Debug.Log($"rotation: {rotation}");

        spring.transform.position = startPoint.transform.position + new Vector3(Mathf.Cos(rotation * Mathf.Deg2Rad) * length / 2, Mathf.Sin(rotation * Mathf.Deg2Rad) * length / 2, 0);
    }
}
