using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransferMap : MonoBehaviour
{

    public string transferMapName;
    public string transferPointName;

    private ThiefMove thePlayer;

    public Text currentPlace;


    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<ThiefMove>();

        currentPlace = GameObject.Find("Current Place").GetComponent<Text>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Thief"){

            thePlayer.currentMapName = transferMapName;
            thePlayer.transferPointName = transferPointName;
            thePlayer.mapChanged = true;
            SceneManager.LoadScene(transferMapName);

            switch (transferMapName)
            {
                case "1F Scene":
                    currentPlace.text = "1F 본관";
                    break;
                case "2F Scene":
                    currentPlace.text = "2F 본관";
                    break;
                case "Hallway 1F":
                    currentPlace.text = "1F 비상통로";
                    break;
                case "Main Hall":
                    currentPlace.text = "강당";
                    break;
                case "Room1 1F":
                    currentPlace.text = "1F 주 강의실";
                    break;
                case "Hallway 2F":
                    currentPlace.text = "2F 비상통로";
                    break;
                case "Room2 1F":
                    currentPlace.text = "1F 보조 연구실";
                    break;
                case "Room3 1F":
                    currentPlace.text = "1F 전산실";
                    break;
                case "Toliet1":
                    currentPlace.text = "1F 화장실";
                    break;
                case "Toliet2":
                    currentPlace.text = "1F 청소실";
                    break;
                case "Warehouse1":
                    currentPlace.text = "1F 창고";
                    break;
                case "Toliet3":
                    currentPlace.text = "2F 화장실";
                    break;
                case "Toliet4":
                    currentPlace.text = "2F 청소실";
                    break;
                case "Room Maze":
                    currentPlace.text = "2F 미로의 방";
                    break;
                case "Terrace1 2F":
                    currentPlace.text = "2F 테라스";
                    break;
                case "Warehouse2":
                    currentPlace.text = "2F 창고";
                    break;
                case "Lab1":
                    currentPlace.text = "2F 화학과 연구실";
                    break;
                default:
                    currentPlace.text = "";
                    break;
            }
        }
    }
}
