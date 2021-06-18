using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bsdff : MonoBehaviour
{
    public GetTrack floor1;
    public NewBehaviourScript endpoint;

    //public GameObject marker;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frames
    void Update()
    {
        for (int i = 0; i < floor1.position.Length - 1; i++)
        {
            if (endpoint.k < 67)
            {
                GetComponent<ArrowRenderer>().start = GameObject.Find("1").transform.position;
            }
            else
            {
                GetComponent<ArrowRenderer>().start = GameObject.Find("67").transform.position;
            }
            GetComponent<ArrowRenderer>().end = endpoint.endposition;
        }
    }
}
