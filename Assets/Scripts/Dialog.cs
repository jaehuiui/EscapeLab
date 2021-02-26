using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    private ThiefMove thePlayer;
    public Image dialog;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        dialog = GameObject.Find("DialogExit").GetComponent<Image>();
        text = GameObject.Find("How to Exit").GetComponent<Text>();
        thePlayer = FindObjectOfType<ThiefMove>();
        dialog.enabled = false;
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (thePlayer.isDialog)
        {
           dialog.enabled = true;
           text.enabled = true;
        }
        else
        {
            dialog.enabled = false;
            text.enabled = false;
        }
    }
}
