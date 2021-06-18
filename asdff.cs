using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asdff : MonoBehaviour
{
    public GameObject marker;
    public GetTrack floor1;
    public NewBehaviourScript endpoint;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<ArrowRenderer>().start = marker.transform.position;
        //GetComponent<ArrowRenderer>().end = floor1.position[0].transform.position;
        for (int i = 0; i < floor1.position.Length - 1; i++)
        {
            GetComponent<ArrowRenderer>().start = marker.transform.position;
            if (endpoint.k < 67)
            {
                GetComponent<ArrowRenderer>().end = GameObject.Find("1").transform.position;
            }
            else
            {
                GetComponent<ArrowRenderer>().end = GameObject.Find("67").transform.position;
            }
         
        }
    }
}
