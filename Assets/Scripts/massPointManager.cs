using System.Collections;
using System.Collections.Generic;
using UnityEngine.U2D;
using UnityEngine;

public class massPointManager : MonoBehaviour
{
    public springManager attachedSpring;

    [SerializeField] Vector2 velocity;
    [SerializeField] float mass = 1f;
    [SerializeField] float damping;
    [SerializeField] float velocityThreshold = 0.01f;
    Vector2 position;
    Vector2 acceleration;
    Vector2 forces;

    GameObject massPoint;

    private void Awake()
    {
        massPoint = gameObject;
        position = massPoint.transform.position;
    }

    void FixedUpdate()
    {
        velocity *= damping;
        if (velocity.magnitude <= velocityThreshold) { velocity = Vector2.zero; }

        acceleration = forces / mass;
        velocity += acceleration;
        position += velocity;

        massPoint.transform.position = position;

        //dont accumulate forces over time
        forces = Vector2.zero;
    }

    public void AddForce(Vector2 force)
    {
        forces += force;
    }
}
