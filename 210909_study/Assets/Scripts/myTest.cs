using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class myTest : MonoBehaviour
{
    void Start()
    {
        mySingle.Instance.i = 100;
        mySingle.Instance.i2 = 200;
        mySingle.Instance.printLog();
        //Ŭ������ü�� ������ ������ ������ ������ �ʾ�������
        //Ŭ������ ������ �Լ��� ��� ������ �����ϴ�.
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject tmp = pooling.Inst.getBullet();
            tmp.transform.SetParent(this.transform);
            tmp.transform.position = this.transform.position;
        }
    }
}
