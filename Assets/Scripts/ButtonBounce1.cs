using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBounce1 : MonoBehaviour
{
    public Image button;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("Quit").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        if (time < 0.5f)
        {
            button.color = new Color(1, 1, 1, 1 - time);
        }
        else
        {
            button.color = new Color(1, 1, 1, time);
            if (time > 1f)
            {
                time = 0;
            }
        }

        time += Time.deltaTime;

    }




}
