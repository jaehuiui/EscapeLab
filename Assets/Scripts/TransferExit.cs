using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferExit : MonoBehaviour
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
        if (collision.gameObject.name == "Thief")
        {
            if (ScoreManager.getScore() < 3)
            {
                Debug.Log("Current Score is " + ScoreManager.getScore());
                thePlayer.isDialog = true;
            }
            else
            {
                thePlayer.gameclear = true;
                Debug.Log("Game Clear");
                thePlayer.currentMapName = transferMapName;
                thePlayer.transferPointName = transferPointName;
                thePlayer.mapChanged = true;
                SceneManager.LoadScene(transferMapName);
            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Thief")
        {
            if (ScoreManager.getScore() < 3)
            {
                thePlayer.isDialog = false;
            }
        }
    }
}
