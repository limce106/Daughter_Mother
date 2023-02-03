using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // 인스턴스
    public static PlayerController instance;

    // 이동 속도
    public float moveSpeed;
    // 캐릭터 콘트롤러 변수
    CharacterController cc;
    // Hit 효과 오브젝트
     public GameObject hitEffect;
    // 애니메이터 변수
    protected Animator anim;
    // 플레이어 움직임 확인
    protected bool playerMoving;
    // 마지막 움직임 방향 확인 변수
    protected Vector2 lastMove;
    // 플레이어 공격 확인
    protected bool playerAttacking;
    // 공격 딜레이 시간
    protected float currentAttackDelay;
    public float attackDelay = 1f;

    public GameObject Player; 
    public GameObject Enemy;

    public Enemy1Controller ec1;
    public Enemy2Controller ec2;
    public Enemy3Controller ec3;

    // 대화창
    public ChatManager chatManager;
    // 기억장면 후
    public bool aftermemory;
    // 최근 사용한 Door의 이름 저장 -> DoorPoint에서 사용
    public string currentDoor;

    void Start()
    {
        anim = GetComponent<Animator>();
        instance = this; 
        aftermemory = false; 
    }

    void Update()
    {
        Move();
        Attack();
        ChangeObject();
    }

    void Move()
    {
        // 따로 방향키 누르지 않으면 플레이어는 움직이지 않음으로 설정
        playerMoving = false;
        playerAttacking = false;

        // 대화창, 인벤토리가 활성화된 상태라면 플레이어는 움직이지 않는다.
        if ((chatManager.isAction) || (Inventory.instance.activeInventory)
            || (chatManager.talkPanel.activeSelf) || (chatManager.playerPanel1.activeSelf) || (chatManager.playerPanel2.activeSelf)
            || (chatManager.playerPanel3.activeSelf) || (chatManager.motherPanel1.activeSelf) || (chatManager.motherPanel3.activeSelf)
            || (chatManager.motherPanel3.activeSelf))
        {
            playerMoving = false;
        }
        else //대화창이 활성화되지 않았다면 플레이어는 움직일 수 있다. 
        {
            // 좌우로 움직이기
            if (Input.GetAxisRaw("Horizontal") > 0f || Input.GetAxisRaw("Horizontal") < 0f)
            {
                // 만일, 플레이어의 hp가 0 이하라면...
                if (PlayerStat.instance.currentHP <= 0)
                {
                    // 플레이어의 애니메이션을 멈춘다.
                    anim.SetBool("isMove", false);
                    anim.SetBool("isAttack", false);
                }
                else
                {
                    transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                    playerMoving = true;
                    lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                }
            }

            // 상하로 움직이기
            if (Input.GetAxisRaw("Vertical") > 0f || Input.GetAxisRaw("Vertical") < 0f)
            {
                // 만일, 플레이어의 hp가 0 이하라면...
                if (PlayerStat.instance.currentHP <= 0)
                {
                    // 플레이어의 애니메이션을 멈춘다.
                    anim.SetBool("isMove", false);
                    anim.SetBool("isAttack", false);
                }
                else
                {
                    transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                    playerMoving = true;
                    lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                }
            }
        }
        

        anim.SetFloat("DirX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("DirY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("isMove", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }


    void Attack()
    {
        //씬이 Enemy1, 2, 3일 때만 z를 눌러 공격할 수 있다.
        if ((SceneManager.GetActiveScene().name == "Enemy1") || (SceneManager.GetActiveScene().name == "Enemy2") || (SceneManager.GetActiveScene().name == "Enemy3"))
        {
            playerMoving = false;
            playerAttacking = false;
            // Z를 누르면
            if (Input.GetKeyDown(KeyCode.Z))
            {
                currentAttackDelay = attackDelay;
                // 공격 애니메이션 활성화
                playerAttacking = true;
                playerMoving = false;
                anim.SetFloat("DirX", Input.GetAxisRaw("Horizontal"));
                anim.SetFloat("DirY", Input.GetAxisRaw("Vertical"));
                anim.SetBool("isAttack", playerAttacking);
                if (Input.GetAxisRaw("Horizontal") > 0f || Input.GetAxisRaw("Horizontal") < 0f)
                {
                    transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                    playerMoving = true;
                    lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                }
                // 플레이어와 에너미의 거리가 1보다 작을 때 플레이어가 공격하면
                if (Vector2.Distance(Player.transform.position, Enemy.transform.position) <= 1)
                {
                    // 에너미의 hp가 플레이어의 공격력만큼 줄어든다.
                    if (SceneManager.GetActiveScene().name == "Enemy1")
                    {
                        ec1.hp -= PlayerStat.instance.AKT;
                    }
                    else if (SceneManager.GetActiveScene().name == "Enemy2")
                    {
                        ec2.hp -= PlayerStat.instance.AKT;
                    }
                    else if (SceneManager.GetActiveScene().name == "Enemy3")
                    {
                        ec3.hp -= PlayerStat.instance.AKT;
                    }
                }
                // 막타를 치면(에너미의 hp가 0이면) 기억 장면을 불러온다.
                if (ec1.hp <= 0)
                {
                    ec1.enemyMoving = false;
                    ec1.Idle();
                    StartCoroutine(LastHitProcess());
                }
                else if (ec2.hp <= 0)
                {
                    ec2.enemyMoving = false;
                    ec2.Idle();
                    StartCoroutine(LastHitProcess());
                }
                else if (ec3.hp <= 0)
                {
                    ec3.enemyMoving = false;
                    ec3.Idle();
                    StartCoroutine(LastHitProcess());
                }
            }
            else
            {
                currentAttackDelay -= Time.deltaTime;
                if (currentAttackDelay <= 0)
                {
                    anim.SetBool("isAttack", false);
                    playerAttacking = false;
                }
            }
        }
    }


    IEnumerator LastHitProcess()
    {
        BgmManager.instance.Play(0); 
        yield return new WaitForSeconds(0.5f);
        if (SceneManager.GetActiveScene().name == "Enemy1")
        {
            ec1.enemyMoving = false;
            // 1. 기억 장면 UI를 활성화한다.
            ec1.memory.SetActive(true);
            // 2. 5초간 대기한다.
            yield return new WaitForSeconds(3f);
            // 3. 기억 장면 UI를 비활성화한다.
            ec1.memory.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "Enemy2")
        {
            ec2.enemyMoving = false;
            // 1. 기억 장면 UI를 활성화한다.
            ec2.memory.SetActive(true);
            // 2. 5초간 대기한다.
            yield return new WaitForSeconds(3f);
            // 3. 기억 장면 UI를 비활성화한다.
            ec2.memory.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "Enemy3")
        {
            ec3.enemyMoving = false;
            // 1. 기억 장면 UI를 활성화한다.
            ec3.memory.SetActive(true);
            // 2. 5초간 대기한다.
            yield return new WaitForSeconds(3f);
            // 3. 기억 장면 UI를 비활성화한다.
            ec3.memory.SetActive(false);
            aftermemory = true;
        }
    }

    // 플레이어의 피격 함수
    public void DamageAction(int damage)
    {

        // 플레이어의 방어력이 에너미의 공격력보다 클 경우 1만큼만 타격 
        if (PlayerStat.instance.DEF >= damage) 
        {
            PlayerStat.instance.currentHP -= 1;
        }
        else // 방어력을 제외한 만큼의 데미지를 입음
        {
            PlayerStat.instance.currentHP -= damage - PlayerStat.instance.DEF;
        }

        // 만일, 플레이어의 체력이 0보다 크면 피격 효과를 출력한다.
        if (PlayerStat.instance.currentHP > 0)
        {
            // 피격 이펙트 코루틴을 시작한다.
            StartCoroutine(PlayHitEffect());
        }
    }

    // 피격 효과 코루틴 함수
    IEnumerator PlayHitEffect()
    {
        // 1. 피격 UI를 활성화한다.
        hitEffect.SetActive(true);

        // 2. 0.3초간 대기한다.
        yield return new WaitForSeconds(0.3f);

        // 3. 피격 UI를 비활성화한다.
        hitEffect.SetActive(false);
    }

    void ChangeObject()
    {
        // 플레이어가 무기를 장착했다면
        if(PlayerStat.instance.weapon != PlayerStat.instance.emptyItem)
        {
            anim.SetBool("isChange", true);
        }
        else
        {
            return;
        }
    }
}
