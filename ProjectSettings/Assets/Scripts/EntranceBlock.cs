using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntranceBlock : MonoBehaviour
{
    void Update()
    {
        Enemy1Controller ec1 = GameObject.Find("Enemy1").GetComponent<Enemy1Controller>();
        Enemy2Controller ec2 = GameObject.Find("Enemy2").GetComponent<Enemy2Controller>();
        Enemy3Controller ec3 = GameObject.Find("Enemy3").GetComponent<Enemy3Controller>();
        if(SceneManager.GetActiveScene().name == "Enemy1")
        {
            if (ec1.hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                return;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Enemy2")
        {
            if (ec2.hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                return;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Enemy3")
        {
            if (ec3.hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                return;
            }
        }
    }
}
