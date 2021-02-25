using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private ThiefMove thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<ThiefMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thePlayer.gameclear)
        {
            gameObject.SetActive(false);
        }
    }
}
