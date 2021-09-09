using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class myTest2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        mySingle.Instance.printLog();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }
    }
}
