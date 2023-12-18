using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.Mathematics;
using UnityEngine;

public class rotateRelativeTo : MonoBehaviour
{

    public GameObject center;

    private GameObject bone;


    // Start is called before the first frame update
    private void Awake()
    {
        bone = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (center == null) {return; }
        
        Vector3 direction = center.transform.position - bone.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x); //differenzialquotient ,':D
        
        bone.GetComponent<Rigidbody2D>().rotation = angle * Mathf.Rad2Deg + 180; //+180 to point away
    }
}