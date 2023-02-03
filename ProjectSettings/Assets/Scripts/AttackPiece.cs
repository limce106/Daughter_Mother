using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPiece : MonoBehaviour
{
    // 이동 속도
    public float speed = 8;
    Vector3 dir;
    //조각의 공격력
    public int attackPower = 1;

    //충돌시작
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            PlayerController pc = GameObject.Find("Player").GetComponent<PlayerController>();
            PlayerStat.instance.currentHP -= attackPower;
            //충돌했을 때 달고나 조각(자신) 사라지기
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

        //플레이어를 찾아서 target으로 하고싶다
        GameObject target = GameObject.Find("Player");
        //방향을 구하고싶다. target - me
        dir = target.transform.position - transform.position;
        //방향의 크기를 1로 하고 싶다.
        dir.Normalize();

        //적이 쏜 총알은 3초뒤에 없어짐 시간지연함수
        Invoke("DestroyBullet", 3); 
        Debug.Log("정상작동3"); 
    }

    //총알이 사라지는 함수
    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        // 1. 방향을 구한다.
        //Vector3 dir = Vector3.down;
        // 2. 이동하고 싶다. 공식 P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }
}