using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textScr : MonoBehaviour
{
    GameObject targetPos;

    Text tx;
    void Start()
    {
        tx = GetComponent<Text>();
        tx.text = "<size=90>abc</size>";
        tx.text += "<color=black>def</color>"+"<color=yellow>ghi</color>";

        tx.font = Resources.Load<Font>("Fonts/BMDOHYEON_ttf");

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            tx.font = Resources.Load<Font>("Fonts/BMHANNA_11yrs_ttf");
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            tx.font = Resources.Load<Font>("Fonts/BMDOHYEON_ttf");
            tx.fontStyle = FontStyle.Italic;

        }

    }
}
