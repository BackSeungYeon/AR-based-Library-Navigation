using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class connectui2 : MonoBehaviour
{
    public GameObject manual;
   
    // Start is called before the first frame update
    public void SceneChange()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Sceneº¯È¯µÊ-------------------------");

    }
    public void blah()
    {
        manual.SetActive(true);
    }
    public void closeblah()
    {
        manual.SetActive(false);
    }
}
