using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class springMassPointManager : MonoBehaviour
{

    Vector2 position;
    Vector2 velocity = Vector2.zero;
    Vector2 sumForces = Vector2.zero;

    GameObject thisPoint;
    public GameObject otherPoint;

    springMassPointManager thisSpringMassPointManager;
    springMassPointManager otherSpringMassPointManager;
    public Vector2 initialVelocity;
    public float restingLength;
    public float springConstant;
    [Range(0,1)]
    public float dampingStrength;

    private void Awake()
    {
        thisPoint = gameObject;
        position = transform.position;
        velocity = initialVelocity;

        thisSpringMassPointManager = thisPoint.GetComponent<springMassPointManager>();
        otherSpringMassPointManager = otherPoint.GetComponent<springMassPointManager>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        CalcForces();
        Translation();
    }

    private void Translation()
    {
        thisPoint.transform.position = position;
        position += velocity / Time.deltaTime;
        velocity += sumForces;
        velocity *= dampingStrength;
        sumForces = Vector2.zero;
        Debug.Log($"vel: {velocity}");
    }

    void CalcForces()
    {

    }



}
