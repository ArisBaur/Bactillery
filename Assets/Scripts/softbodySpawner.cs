using System.Collections;
using System.Collections.Generic;
using UnityEngine.U2D.Animation;
using UnityEngine;
using UnityEngine.XR;

public class softbodySpawner : MonoBehaviour
{

    public GameObject massPointPrefab;
    public GameObject springPrefab;

    private GameObject massPoint;
    private GameObject spring;

    private List<GameObject> massPointList = new List<GameObject>();
    private List<GameObject> springList = new List<GameObject>();

    private Vector2[] positionsArray = {new Vector2(0.1f, 0.1f), new Vector2(0.1f, -0.1f), new Vector2(-0.1f, 0.1f), new Vector2(-0.1f, -0.1f) };

    private springManager prefabSpringManager = null;
    private massPointManager prefabmassPointManager = null;

    private SpriteRenderer spriteRenderer = null;
    private SkeletonAsset skeletonAsset = null;
    

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //skeletonAsset = spriteRenderer.GetComponent<SkeletonAsset>();
    }

    void Start()
    {
        //spawn massPoints/springs
        for (int i = 0; i < 4; i++)
        {
            massPoint = Instantiate(massPointPrefab, new Vector3(positionsArray[i].x, positionsArray[i].y, 0), Quaternion.identity); //place the mPoints in a square
            massPointList.Add(massPoint);
            spring = Instantiate(springPrefab, new Vector3(0, 0, 0), Quaternion.identity); //springs set their coords automatically via their class -> no need to place them at a specific coord
            springList.Add(spring);
        }

        //position massPoints
        foreach (GameObject _massPoint in massPointList)
        {
            prefabmassPointManager = _massPoint.GetComponent<massPointManager>();
            //prefabmassPointManager.AddForce(new Vector2(0.1f, -0.1f));
        }

        ////link massPoints with springs
        //foreach (GameObject _spring in springList)
        //{
        //    prefabSpringManager = _spring.GetComponent<springManager>();
        //    prefabSpringManager.startPoint =
        //} //ill come back to that later


        //temporary code: use foreach or sth later
        //add one more spring cause there are only 4
        springList.Add(Instantiate(springPrefab, new Vector3(0, 0, 0), Quaternion.identity));
        springList.Add(Instantiate(springPrefab, new Vector3(0, 0, 0), Quaternion.identity));

        springList[0].GetComponent<springManager>().startPoint = massPointList[0].GetComponent<massPointManager>();
        springList[0].GetComponent<springManager>().endPoint   = massPointList[1].GetComponent<massPointManager>();
        springList[0].GetComponent<springManager>().restingLength = 1.0f;

        springList[1].GetComponent<springManager>().startPoint = massPointList[1].GetComponent<massPointManager>();
        springList[1].GetComponent<springManager>().endPoint   = massPointList[3].GetComponent<massPointManager>();
        springList[1].GetComponent<springManager>().restingLength = 1.0f;

        springList[2].GetComponent<springManager>().startPoint = massPointList[3].GetComponent<massPointManager>();
        springList[2].GetComponent<springManager>().endPoint   = massPointList[2].GetComponent<massPointManager>();
        springList[2].GetComponent<springManager>().restingLength = 1.0f;

        springList[3].GetComponent<springManager>().startPoint = massPointList[2].GetComponent<massPointManager>();
        springList[3].GetComponent<springManager>().endPoint   = massPointList[0].GetComponent<massPointManager>();
        springList[3].GetComponent<springManager>().restingLength = 1.0f;

        springList[4].GetComponent<springManager>().startPoint = massPointList[0].GetComponent<massPointManager>();
        springList[4].GetComponent<springManager>().endPoint = massPointList[3].GetComponent<massPointManager>();
        springList[4].GetComponent<springManager>().restingLength = Mathf.Sqrt(2);

        springList[5].GetComponent<springManager>().startPoint = massPointList[2].GetComponent<massPointManager>();
        springList[5].GetComponent<springManager>().endPoint = massPointList[1].GetComponent<massPointManager>();
        springList[5].GetComponent<springManager>().restingLength = Mathf.Sqrt(2);

        //temp code


    }

    private void FixedUpdate()
    {

    }

}
