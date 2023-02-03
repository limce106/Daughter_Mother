using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceBlock : MonoBehaviour
{
    PlayerController pc;
    void Start()
    {
        PlayerController pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        Destroy_Block();
    }

    void Destroy_Block()
    {
        if (pc.hp == 0)
        {
            Destroy(gameObject);
        }
    }
}
