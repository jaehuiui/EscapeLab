using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key4Script_6 : MonoBehaviour
{
    private ThiefMove thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<ThiefMove>();
        if (thePlayer.getKey4 || thePlayer.randomKey4 != 6)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
