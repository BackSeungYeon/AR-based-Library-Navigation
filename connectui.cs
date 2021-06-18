using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class connectui : MonoBehaviour
{
    // Start is called before the first frame update
    public void SceneChange()
    {
        SceneManager.LoadScene("BasicImageTracking");
        Debug.Log("Sceneº¯È¯µÊ-------------------------");

    }
}