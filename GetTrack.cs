using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
//using TMPro;

public class GetTrack : MonoBehaviour
{
    //�������ν� �迭�� ����
    public GameObject[] position;
    public GameObject[] position3F;

    //�迭�� �Ҵ�
    void Start()
    {
        //arraySize = 66;
        //arrayObject = new int[arraySize];
        position = GameObject.FindGameObjectsWithTag("position");
        position3F = GameObject.FindGameObjectsWithTag("position3F");
    }

    //�迭�� ������ ����
    void Update()
    {
        //for(int i=0; i<arraySize; i+=2)
        //{
            //arrayObject[i] = int.Parse(gameObject.name);
        //}
    }

    //Destroy
    void Awake()
    {
        //foreach(GameObject destroyArray in arrayObject)
        //{
        //Destroy(destroyArray);
        //}
        //Debug.Log("PPPPPPPPPPPPPPPPPPPPPPPPOOOOOOOSSSIIITTTIIIOOONNN");
        //Debug.Log(position.Length);
        //Debug.Log(position3F.Length);
    }
}