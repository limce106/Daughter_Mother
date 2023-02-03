using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPoint : MonoBehaviour
{
    // 씬 이동 후 도착한 지점의 이름
    public string doorPoint;

    void Start()
    {
        if (doorPoint == PlayerController.instance.currentDoor)
        {
            // 플레이어의 위치는 doorPoint로 지정
            PlayerController.instance.transform.position = this.transform.position;
        }
    }
}
