using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csdff : MonoBehaviour
{
    public GetTrack floor1;
    public NewBehaviourScript endpoint;
    public GameObject testcollider;
    //public GameObject marker;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frames
    void Update()
    {
        GetComponent<ArrowRenderer>().start = endpoint.endposition;
        GetComponent<ArrowRenderer>().end = endpoint.endposition3;
        GameObject.Find("Sphere").transform.position = endpoint.endposition3;
    }
}
