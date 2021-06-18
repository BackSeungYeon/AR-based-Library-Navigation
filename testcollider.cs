using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testcollider : MonoBehaviour
{
    public GetTrack floor1;
    public NewBehaviourScript endpoint;
    public GameObject Popup;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Collider에 들어왔을 때 불리는 함수
    /*public void OnCollisionEnter(Collision collision)
    {
        /*if(collision.gameObject.transform.position == GameObject.Find("AR Session Origin").transform.position)
        {
            Debug.Log("YOU FOUND A BOOK!!!!");
        }
        Debug.Log(collision.gameObject.name + "에 도착하면 됨");
    }*/

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + "와 충돌함");
        if (other.gameObject.name == "AR Camera" )
        {
            Popup.SetActive(true);
        }
        else
        {
            Popup.SetActive(false);
        }
    }
    public void SceneChange()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Scene변환됨-------------------------");

    }
}