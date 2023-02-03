using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyPlayer : MonoBehaviour
{
    private void Awake() 
    {
        // 이 스크립트의 오브젝트들을 모두 불러옴
        var objs = FindObjectsOfType<DontDestroyPlayer>();

        // 오브젝트가 하나
        if (objs.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
            // 플레이어의 위치 지정
            gameObject.transform.position = new Vector3(0, 0, 0);
        }
        // 오브젝트가 하나 이상이라면 생성된 게임 오브젝트를 파괴
        else
        {
            Destroy(gameObject);
        }
    }
}
