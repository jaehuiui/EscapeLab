using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{

    public string transferMapName;
    public string transferPointName;

    private ThiefMove thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<ThiefMove>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Thief"){

            thePlayer.currentMapName = transferMapName;
            thePlayer.transferPointName = transferPointName;
            thePlayer.mapChanged = true;
            SceneManager.LoadScene(transferMapName);
        }
    }
}
