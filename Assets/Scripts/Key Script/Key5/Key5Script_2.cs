﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key5Script_2 : MonoBehaviour
{
    private ThiefMove thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<ThiefMove>();
        if (thePlayer.getKey5 || thePlayer.randomKey5 != 2)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
