using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy2Controller : MonoBehaviour
{
    // 에너미 상태 변수
    enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Damaged
    }

    // 에너미 상태 변수
    EnemyState m_State;

    // 플레이어 발견 범위
    public float findDistance = 8f;

    // 플레이어 트랜스폼
    Transform player;

    // 공격 가능 범위
    public float attackDistance = 1f;

    // 이동 속도
    public float moveSpeed = 5f;

    // 캐릭터 콘트롤러 컴포넌트
    CharacterController cc;

    // 누적 시간
    float currentTime = 0;

    // 공격 딜레이 시간
    float attackDelay = 2f;

    // 에너미 공격력
    public int attackPower = 7;

    // 에너미의 체력
    public int hp = 50;

    // 애니메이터 변수
    Animator anim;

    // 에너미 움직임 확인
    public bool enemyMoving;

    // 마지막 움직임 방향 확인 변수
    Vector2 lastMove;

    //체력바
    public Slider EnemyHpSlider;
    public Text EnemyHpText;

    // 기억장면 이미지 UI
    public GameObject memory;

    // chatManager
    ChatManager chatManager;

    void Start()
    {
        enemyMoving = false;
        // 최초의 에너미 상태는 움직임으로 한다.
        m_State = EnemyState.Idle;
        // 최초의 에너미 상태는 대기로 한다.
        m_State = EnemyState.Idle;
        // 플레이어의 트랜스폼 컴포넌트 받아오기
        player = GameObject.Find("Player").transform;
        //컴포넌트 받아오기
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        chatManager = FindObjectOfType<ChatManager>();
        // 플레이어의 에너미를 이 객체로 설정
        if (findDistance != 0)
        {
            PlayerController.instance.Enemy = gameObject; 
        }
        // BGM 설정
        BgmManager.instance.ecbgm2 = this;
        // playercontroller의 ec2 설정
        PlayerController.instance.ec2 = GameObject.Find("Enemy2").GetComponent<Enemy2Controller>(); 
        // 에너미 체력바 슬라이더를 비활성화 상태로
        EnemyHpSlider.gameObject.SetActive(false);
    }

    void Update()
    {
        // 현재 상태를 체크해 상태별로 정해진 기능을 수행하게 하고 싶다.
        switch (m_State)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Damaged:
                //Damaged();
                break;
        }

        // EnemySlider UI 설정
        EnemyHpSlider.maxValue = 50; // Enemy1의 총 HP는 50
        EnemyHpSlider.value = hp; 
        string a = hp.ToString(); 
        EnemyHpText.text = a;

        // 플레이어와 에너미의 HPSlider 띄우기
        if (enemyMoving == true) // 에너미가 움직이는 동안 : 전투중
        {
            // 플레이어의 hpSlider 띄우기
            PlayerStat.instance.hpSlider.gameObject.SetActive(true);
            // 에너미의 hpSlider 띄우기
            EnemyHpSlider.gameObject.SetActive(true);
        }
        // 에너미의 hp가 0이면 EnemyHpSlider 비활성화
        if (hp <= 0)
        {
            EnemyHpSlider.gameObject.SetActive(false);
        } 
    }

    public void Idle()
    {
        if (hp > 0 && enemyMoving == true)
        {
            Move();
        }
        else if (hp <= 0)
        {
            anim.SetBool("isMove", enemyMoving);
        }
    }

    void Move()
    {
        // 인벤토리, 아이템 습득 대화창이 열려있을 때 -> 에너미가 움직이지 못하도록 함
        if ((chatManager.isAction) || (Inventory.instance.activeInventory)|| (hp <= 0))
        {
            enemyMoving = false;
        }
        else
        {
            enemyMoving = true;
        }

        // 에너미가 전투 상태
        if (enemyMoving)
        {
            Vector3 dir = Vector3.zero;

            // 만일, 플레이어와의 거리가 공격 범위 밖이라면 플레이어를 향해 이동한다.
            if (Vector3.Distance(transform.position, player.position) > attackDistance)
            {
                // 이동 방향 설정
                //Vector3 dir = (player.position - transform.position).normalized;
                dir = (player.position - transform.position).normalized;

                // 캐릭터 콘트롤러를 이용해 이동하기
                cc.Move(dir * moveSpeed * Time.deltaTime);
                lastMove = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
            }
            // 그렇지 않다면, 현재 상태를 공격(Attack)으로 전환한다.
            else
            {
                m_State = EnemyState.Attack;

                // 누적 시간을 공격 딜레이 시간만큼 미리 진행시켜 놓는다.
                currentTime = attackDelay;

                // 공격 대기 애니메이션 플레이
                //anim.SetTrigger("MoveToAttackDelay");
            }
            anim.SetFloat("DirX", dir.x);
            anim.SetFloat("DirY", dir.y);
            anim.SetBool("isMove", enemyMoving);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
        }

    }

    void Attack()
    {
        // 인벤토리, 아이템 습득 대화창이 열려있을 때 -> 에너미가 움직이지 못하도록 함
        if ((chatManager.isAction) || (Inventory.instance.activeInventory)|| (hp <= 0))
        {
            enemyMoving = false;
        }
        else
        {
            enemyMoving = true;
        }

        // 에너미가 전투 상태
        if (enemyMoving)
        {
            // 만일, 플레이어가 공격 범위 이내에 있다면 플레이어를 공격한다.
            if (Vector3.Distance(transform.position, player.position) < attackDistance)
            {
                // 일정 시간마다 플레이어를 공격한다.
                currentTime += Time.deltaTime;
                if (currentTime > attackDelay)
                {
                    // 플레이어 피격 -> HP 감소
                    player.GetComponent<PlayerController>().DamageAction(attackPower);
                    print(PlayerStat.instance.currentHP + "이 남았습니다");
                    print("공격");
                    currentTime = 0;

                    // 공격 애니메이션 플레이
                    //anim.SetTrigger("StartAttack");
                }
            }
            // 그렇지 않다면, 현재 상태를 이동(Move)으로 전환한다(재추격 실시).
            else
            {
                //dir = (player.position - transform.position).normalized;

                m_State = EnemyState.Move;
                currentTime = 0;

                // 이동 애니메이션 플레이
                //anim.SetTrigger("AttackToMove");
            }
        }

    }

    void Damaged()
    {
        // 피격 상태를 처리하기 위한 코루틴을 실행한다.
        StartCoroutine(DamageProcess());
    }

    // 데미지 처리용 코루틴 함수
    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(0f);

        // 현재 상태를 이동 상태로 전환한다.
        m_State = EnemyState.Move;
        print("상태 전환: Damaged -> Move");
    }

    // 데미지 실행 함수
    public void HitEnemy(int hitPower)
    {
        // 만일, 이미 피격 상태이거나 사망 상태 또는 복귀 상태라면 아무런 처리도 하지 않고 함수를 종료한다.
        if (m_State == EnemyState.Damaged)
        {
            return;
        }

        // 플레이어의 공격력만큼 에너미의 체력을 감소시킨다.
        hp -= hitPower;

        // 에너미의 체력이 0보다 크면 피격 상태로 전환한다.
        if (hp > 0)
        {
            m_State = EnemyState.Damaged;
            print("상태 전환: Any state -> Damaged");

            Damaged();
        }
        // 그렇지 않다면 죽음 상태로 전환한다.
        else
        {
            print("상태 전환: Any state -> Die");

            enemyMoving = false;
        }
    }
}
