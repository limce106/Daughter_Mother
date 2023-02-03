using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy2Fire : MonoBehaviour
{
    // 달고나 조각 생산할 공장
    public GameObject DalgonaFactory;
    // 발사 위치
    public GameObject firePosition; 

    //현재시간
    float currentTime;
    //일정시간
    public float createTime = 5;
    // chatManager
    ChatManager chatManager;

    private void Start() 
    {
        chatManager = FindObjectOfType<ChatManager>();
    }

    void Update()
    {
        Enemy2Controller ec2 = GameObject.Find("Enemy2").GetComponent<Enemy2Controller>();
        Enemy3Controller ec3 = GameObject.Find("Enemy3").GetComponent<Enemy3Controller>();
        if (SceneManager.GetActiveScene().name == "Enemy2")
        {
            if (ec2.enemyMoving == true)
            {
                // 인벤토리 열었을 때 공격 멈춤
                if ((chatManager.isAction) ||(Inventory.instance.activeInventory == false))
                {
                    //1.시간이 흐르다가
                    currentTime += Time.deltaTime;
                    //2.만약 현재시간이 일정시간이 되면
                    if (currentTime > createTime)
                    {
                        //총알 공장에서 총알을 만든다.
                        GameObject bullet = Instantiate(DalgonaFactory);
                        //총알을 발사한다
                        bullet.transform.position = firePosition.transform.position;
                        //현재시간을 0으로 초기화
                        currentTime = 0;
                    }
                }
            }
            else
            {
                ec2.enemyMoving = false;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Enemy3")
        {
            if (ec3.enemyMoving == true)
            {
                // 인벤토리 열었을 때 공격 멈춤
                if (Inventory.instance.activeInventory == false)
                {
                    //1.시간이 흐르다가
                    currentTime += Time.deltaTime;
                    //2.만약 현재시간이 일정시간이 되면
                    if (currentTime > createTime)
                    {
                        //총알 공장에서 총알을 만든다.
                        GameObject bullet = Instantiate(DalgonaFactory);
                        //총알을 발사한다
                        bullet.transform.position = firePosition.transform.position;
                        //현재시간을 0으로 초기화
                        currentTime = 0;
                    }
                }
            }
            else
            {
                ec3.enemyMoving = false;
            }
        }
    }
}
