using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyObject : MonoBehaviour
{
    DontDestroyObject[] objs;

    private void Awake()
    {
        // 이 스크립트의 오브젝트들을 모두 불러옴
        objs = GameObject.FindObjectsOfType<DontDestroyObject>();

        // 오브젝트 : InventoryCanvas, ItemDBManager, ChatCanvas
        if (objs.Length == 3)
        {
            DontDestroyOnLoad(gameObject);
        }
        // 오브젝트가 하나 이상이라면 생성된 게임 오브젝트를 파괴
        else
        {
            Destroy(gameObject);
        }
    }

    void Update() 
    {
        // 게임오버씬에서 삭제
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            Destroy(gameObject);
        }
    }
}
