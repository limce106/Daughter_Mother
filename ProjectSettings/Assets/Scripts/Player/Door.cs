using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    // 플레이어 게임 오브젝트
    private GameObject Player; 
    // 어디로 이동하는지?
    public string MoveTo;

    private void Awake() 
    {
        Player = GameObject.Find("Player");
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        // 플레이어의 최근 사용한 Door를 MoveTo로 지정
        PlayerController.instance.currentDoor = MoveTo;
        // Door 콜라이더에 플레이어가 닿으면 해당 씬으로 이동
        if (col.gameObject.tag.Equals("Player"))
        {
            // 거실
            if (MoveTo == "LivingRoomR")
            {
                SceneManager.LoadScene("LivingRoom");
            }
            else if (MoveTo == "LivingRoomL")
            {
                SceneManager.LoadScene("LivingRoom");
            }
            else if (MoveTo == "LivingRoomD")
            {
                SceneManager.LoadScene("LivingRoom");
            }
            // 방
            else if (MoveTo == "BedRoom")
            {
                SceneManager.LoadScene("BedRoom");
            }
            else if (MoveTo == "Kitchen")
            {
                SceneManager.LoadScene("Kitchen");   
            }
            // 길거리
            else if (MoveTo == "Road1")
            {
                SceneManager.LoadScene("Road");
            }
            else if (MoveTo == "Road2")
            {
                SceneManager.LoadScene("Road");
            }
            else if (MoveTo == "Road3")
            {
                SceneManager.LoadScene("Road");
            }
            // 전투씬
            else if (MoveTo == "Enemy1")
            {
                SceneManager.LoadScene("Enemy1");
            }
            else if (MoveTo == "Enemy2")
            {
                SceneManager.LoadScene("Enemy2");
            }
            else if (MoveTo == "Enemy3")
            {
                SceneManager.LoadScene("Enemy3");
            }    
        }
    }
}
