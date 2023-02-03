 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 대화창에 들어가는 텍스트의 종류
// 1. 배경 오브젝트 설명 -> 각 오브젝트의 설명을 출력
// 2. 아이템 설명 -> 아이템의 설명을 출력, 획득 메시지
// 3. 대사 -> 주인공과 에너미가 나누는 대화
// 4. 스테이지 종료 메시지

public class ChatManager : MonoBehaviour
{
    // 대화창 활성화 여부
    public bool isAction;
    // 대화창에 띄울 텍스트
    public Text talkText;
    // 플레이어가 조사한 오브젝트
    public PickUpItem item;

    // 아이템데이터베이스에 접근
    public ItemDatabase theDatabase;
    // 대화데이터베이스에 접근
    public TalkManager talkManager;

    // 대화창 
    // 기본 대화창
    public GameObject talkPanel;
    // 플레이어 기본 대화창
    public GameObject playerPanel1;
    // 플레이어의 엄마 기본 대화창
    public GameObject motherPanel1;
    // 플레이어 웃는 대화창
    public GameObject playerPanel2;
    // 플레이어의 엄마 웃는 대화창
    public GameObject motherPanel2;
    // 플레이어 우는 대화창
    public GameObject playerPanel3;
    // 플레이어의 엄마 우는 대화창
    public GameObject motherPanel3;

    int talkIndex = 0;

    PlayerController playercontroller;
    public GameObject Player;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;

    bool bFirstWord = true;

    // 처음 시작할 때 대화창 안보이도록 비활성화
    private void Start()
    {
        //talkPanel.SetActive(false);
        theDatabase = FindObjectOfType<ItemDatabase>(); // ItemDataBase 스크립트
        Player = GameObject.Find("Player"); 
        isAction = false;
    }

    void Update()
    {
        Enemy1 = GameObject.Find("Enemy1"); 
        Enemy2 = GameObject.Find("Enemy2"); 
        Enemy3 = GameObject.Find("Enemy3");

        if (bFirstWord)
        {
            //ShowDialogue();
            ShowDialogue();

            bFirstWord = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowDialogue();
        }
    }

    // 1. 배경 오브젝트의 설명을 대화창에 띄우는 함수
    public void ActionStuffDesc(int _itemID) // 아이템 객체를 인자로 받아서 
    {
        // X를 눌렀을 때 (PickUpItem 스크립트)
        // 대화창이 활성화 되어있다면 
        if (isAction)
        {
            isAction = false; //대화창 비활성화
            // Text..
        }
        // 대화창이 비활성화 되어 있다면
        else
        {
            // 데이터베이스 검색 
            // 데이터 베이스의 아이템 리스트 크기만큼 반복하며 ID를 찾음
            for (int i = 100; i < (theDatabase.stuffList.Count + 100); i++)
            {
                Debug.Log("stuff 리스트 개수 : " + theDatabase.stuffList.Count);
                Debug.Log("for문 도는 중~!");
                if (_itemID == theDatabase.stuffList[i - 100].stuffID) //베이스에서 ID를 찾으면
                {
                    isAction = true; // 대화창 활성화
                    // 해당 아이템ID에 맞는 이름과 설명을 대화창에 출력
                    talkText.text = theDatabase.stuffList[i - 100].stuffDescription;
                    break;
                }
            }
        }
        // 대화창 이미지도 같이 활/비활성화
        talkPanel.SetActive(isAction);
        talkText.gameObject.SetActive(isAction); 
    }

    // 2.아이템 습득시 아이템 설명을 대화창에 띄우는 함수
    public void ActionItemDesc(int _itemID) // 아이템 아이디를 인자로 받는다.
    {
        // Space를 눌렀을 때 (PickUpItem 스크립트)
        // 대화창이 활성화 되어있다면 
        if (isAction)
        {
            isAction = false; //대화창 비활성화
        }
        // 대화창이 비활성화 되어 있다면
        else
        {
            // 데이터베이스 검색 
            // 데이터 베이스의 아이템 리스트 크기만큼 반복하며 ID를 찾음
            for (int i = 0; i < theDatabase.itemList.Count; i++)
            {
                if (_itemID == theDatabase.itemList[i].itemID) //베이스에서 ID를 찾으면
                {
                    isAction = true; // 대화창 활성화
                    // 해당 아이템ID에 맞는 이름과 설명을 대화창에 출력
                    talkText.text = theDatabase.itemList[i].itemName + ". " + theDatabase.itemList[i].itemDescription;
                    break;
                }
            }
        }
        // 대화창 이미지도 같이 활/비활성화
        talkPanel.SetActive(isAction);
        talkText.gameObject.SetActive(isAction);
    }

    // 3. npc(에너미, 엄마)와 나누는 대화를 대화창에 띄우는 함수
    public void ShowDialogue()
    {
        List<string> talkData;

        Debug.Log("SfhoeDialog 호출");
        talkText.gameObject.SetActive(true);

        // Stage1
        if (SceneManager.GetActiveScene().name == "BedRoom")
        {
            talkData = talkManager.GetTalk(talkManager.Talk1, talkIndex);
            if (talkData == null)
            {
                talkText.text = " ";
                playerPanel1.SetActive(false);
                talkIndex = 0;
                talkText.gameObject.SetActive(false);
                Debug.Log("대화 끝, 대화텍스트 비활성화");
                return;
            }

            if ((bFirstWord || Input.GetKeyDown(KeyCode.Space)))
            {

                talkText.text = talkData[talkIndex];
                if(talkIndex == 3)
                {
                    talkPanel.SetActive(false);
                    playerPanel1.SetActive(false);
                    playerPanel3.SetActive(true);
                }
                else if(talkIndex == 0 || talkIndex == 1)
                {
                    talkPanel.SetActive(true);
                }
                else
                {
                    talkPanel.SetActive(false);
                    playerPanel3.SetActive(false);
                    playerPanel1.SetActive(true);
                }
                talkIndex++;
            }
        }

        if (SceneManager.GetActiveScene().name == "LivingRoom")
        {
            talkData = talkManager.GetTalk(talkManager.talk1, talkIndex);
            if (talkData == null)
            {
                talkText.text = " ";
                playerPanel1.SetActive(false);
                talkIndex = 0;
                talkText.gameObject.SetActive(false);
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //talkText.SetActive(true);
                talkText.text = talkData[talkIndex];
                playerPanel1.SetActive(true);
                talkIndex++;
            }
        }

        // Stage2
        if (SceneManager.GetActiveScene().name == "Road")
        {
            talkData = talkManager.GetTalk(talkManager.Talk2, talkIndex);
            if (talkData == null)
            {
                talkText.text = " ";
                playerPanel1.SetActive(false);
                talkIndex = 0;
                talkText.gameObject.SetActive(false);
                return;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                talkText.text = talkData[talkIndex];
                playerPanel1.SetActive(true);
                talkIndex++;
            }
        }


        if (SceneManager.GetActiveScene().name == "Enemy1")
        {
            Enemy1Controller ec1 = GameObject.Find("Enemy1").GetComponent<Enemy1Controller>();
            if (Vector2.Distance(Player.transform.position, Enemy1.transform.position) <= 1)
            {
                // 에너미에게 말 걸었을 때 실행
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    talkData = talkManager.GetTalk(talkManager.Talk3, talkIndex);
                    if (talkData == null)
                    {
                        talkText.text = " ";
                        talkPanel.SetActive(false);
                        talkIndex = 0;
                        ec1.enemyMoving = true;
                        talkText.gameObject.SetActive(false);
                        return;
                    }

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        talkText.text = talkData[talkIndex];
                        if(talkIndex == 0)
                        {
                            playerPanel1.SetActive(true);
                        }
                        else
                        {
                            playerPanel1.SetActive(false);
                            talkPanel.SetActive(true);
                        }
                        talkIndex++;
                    }
                }
            
            }

            // 전투가 끝난 후
            if (ec1.hp<= 0)
            {
                ec1.enemyMoving = false;
                talkData = talkManager.GetTalk(talkManager.Talk4, talkIndex);
                if (talkData == null)
                {
                    talkText.text = " ";
                    playerPanel1.SetActive(false);
                    talkIndex = 0;
                    talkText.gameObject.SetActive(false);
                    Inventory.instance.GetANote(1002);
                    return;
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    talkText.text = talkData[talkIndex];
                    if(talkIndex == 0 || talkIndex == 4)
                    {
                        talkPanel.SetActive(false);
                        playerPanel1.SetActive(true);
                    }
                    else
                    {
                        playerPanel1.SetActive(false);
                        talkPanel.SetActive(true);
                    }
                    talkIndex++;
                }
            }
        }

        // Stage3
        if (SceneManager.GetActiveScene().name == "Enemy2")
        {
            Enemy2Controller ec2 = GameObject.Find("Enemy2").GetComponent<Enemy2Controller>();
            if (Vector2.Distance(Player.transform.position, Enemy2.transform.position) <= 1)
            {
                // 에너미에게 말 걸었을 때 실행
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    talkData = talkManager.GetTalk(talkManager.Talk6, talkIndex);
                    if (talkData == null)
                    {
                        talkText.text = " ";
                        talkPanel.SetActive(false);
                        talkIndex = 0;
                        ec2.enemyMoving = true;
                        talkText.gameObject.SetActive(false);
                        Inventory.instance.GetANote(1003);
                        return;
                    }
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        talkText.text = talkData[talkIndex];
                        if(talkIndex == 5 || talkIndex == 6 || talkIndex == 7 || talkIndex == 8 || talkIndex == 9)
                        {
                            playerPanel1.SetActive(false);
                            talkPanel.SetActive(true);
                        }
                        else
                        {
                            talkPanel.SetActive(false);
                            playerPanel1.SetActive(true);
                        }
                        talkIndex++;
                    }
                }
            }

            // 전투가 끝난 후
            if (ec2.hp <= 0)
            {
                ec2.enemyMoving = false;
                talkData = talkManager.GetTalk(talkManager.Talk7, talkIndex);
                if (talkData == null)
                {
                    talkText.text = " ";
                    playerPanel1.SetActive(false);
                    talkIndex = 0;
                    talkText.gameObject.SetActive(false);
                    return;
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    talkText.text = talkData[talkIndex];

                    if (talkIndex == 0 || talkIndex == 4)
                    {
                        talkPanel.SetActive(false);
                        playerPanel1.SetActive(true);
                    }
                    else
                    {
                        playerPanel1.SetActive(false);
                        talkPanel.SetActive(true);
                    }
                    talkIndex++;
                }
            }
        }

        // Stage4
        if (SceneManager.GetActiveScene().name == "Enemy3")
        {
            Enemy3Controller ec3 = GameObject.Find("Enemy3").GetComponent<Enemy3Controller>();
            if (Vector2.Distance(Player.transform.position, Enemy3.transform.position) <= 1)
            {
                // 에너미에게 말 걸었을 때 실행
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    talkData = talkManager.GetTalk(talkManager.Talk8, talkIndex);
                    if (talkData == null)
                    {
                        talkText.text = " ";
                        playerPanel1.SetActive(false);
                        talkIndex = 0;
                        ec3.enemyMoving = true;
                        talkText.gameObject.SetActive(false);
                        return;
                    }
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        talkText.text = talkData[talkIndex];
                        if(talkIndex == 4 || talkIndex == 5 || talkIndex == 6)
                        {
                            playerPanel1.SetActive(false);
                            talkPanel.SetActive(true);
                        }
                        else
                        {
                            talkPanel.SetActive(false);
                            playerPanel1.SetActive(true);
                        }
                        talkIndex++;
                    }
                }

            }

            if (ec3.hp <= 0)
            {
                talkData = talkManager.GetTalk(talkManager.Talk10, talkIndex);
                if (talkData == null)
                {
                    talkText.text = " ";
                    motherPanel2.SetActive(false);
                    talkIndex = 0;
                    talkText.gameObject.SetActive(false);
                    return;
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    talkText.text = talkData[talkIndex];
                    // 기본 대화창
                    if (talkIndex == 0)
                    {
                        motherPanel3.SetActive(false);
                        motherPanel2.SetActive(false);
                        playerPanel3.SetActive(false);
                        playerPanel2.SetActive(false);
                        playerPanel1.SetActive(false);
                        motherPanel1.SetActive(false);
                        talkPanel.SetActive(true);
                    }
                    // 엄마 기본 대화창
                    if (talkIndex == 3 || talkIndex == 5 || talkIndex == 7 || talkIndex == 8)
                    {
                        talkPanel.SetActive(false);
                        motherPanel3.SetActive(false);
                        motherPanel2.SetActive(false);
                        playerPanel3.SetActive(false);
                        playerPanel1.SetActive(false);
                        motherPanel1.SetActive(true);
                    }
                    // 엄마 눈물
                    else if (talkIndex == 9 || talkIndex == 11 || talkIndex == 12 || talkIndex == 15 || talkIndex == 17)
                    {
                        motherPanel1.SetActive(false);
                        talkPanel.SetActive(false);
                        motherPanel2.SetActive(false);
                        playerPanel3.SetActive(false);
                        playerPanel1.SetActive(false);
                        motherPanel3.SetActive(true);
                    }
                    // 엄마 웃음
                    else if (talkIndex == 18 || talkIndex == 23)
                    {
                        motherPanel1.SetActive(false);
                        motherPanel3.SetActive(false);
                        talkPanel.SetActive(false);
                        playerPanel3.SetActive(false);
                        playerPanel1.SetActive(false);
                        motherPanel2.SetActive(true);
                    }
                    // 플레이어 눈물
                    else if (talkIndex == 19 || talkIndex == 20 || talkIndex == 21 || talkIndex == 22)
                    {
                        motherPanel1.SetActive(false);
                        motherPanel3.SetActive(false);
                        motherPanel2.SetActive(false);
                        talkPanel.SetActive(false);
                        playerPanel1.SetActive(false);
                        playerPanel3.SetActive(true);
                    }
                    // 플레이어 기본
                    else if (talkIndex == 1 || talkIndex == 2 || talkIndex == 4 || talkIndex == 6 || talkIndex == 10
                        || talkIndex == 13 || talkIndex == 14 || talkIndex == 16)
                    {
                        motherPanel1.SetActive(false);
                        motherPanel3.SetActive(false);
                        motherPanel2.SetActive(false);
                        playerPanel3.SetActive(false);
                        talkPanel.SetActive(false);
                        playerPanel1.SetActive(true);
                    }
                    talkIndex++;
                }
            }
        }

        // Stage5
        if (SceneManager.GetActiveScene().name == "Epilogue")
        {
            talkData = talkManager.GetTalk(talkManager.Talk11, talkIndex);
            if (talkData == null)
            {
                talkText.text = " ";
                playerPanel2.SetActive(false);
                talkIndex = 0;
                talkText.gameObject.SetActive(false);
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                talkText.text = talkData[talkIndex];
                playerPanel2.SetActive(true);
                talkIndex++;
            }
        }

    }

    // 4. 쪽지의 내용을 대화창에 띄우는 함수
    public void ActionNoteCont(int _itemID) // 아이템 객체를 인자로 받아서 
    {
        // Space를 눌렀을 때 (PickUpItem 스크립트)
        // 대화창이 활성화 되어있다면 
        if (isAction)
        {
            isAction = false; //대화창 비활성화
        }
        // 대화창이 비활성화 되어 있다면
        else
        {
            // 데이터베이스 검색 
            // 데이터 베이스의 아이템 리스트 크기만큼 반복하며 ID를 찾음
            for (int i = 1001; i < (theDatabase.NoteList.Count + 1001); i++)
            {
                if (_itemID == theDatabase.NoteList[i - 1001].noteID) //베이스에서 ID를 찾으면
                {
                    isAction = true; // 대화창 활성화
                    // 해당 아이템ID에 맞는 이름과 설명을 대화창에 출력
                    talkText.text = theDatabase.NoteList[i - 1001].noteContent;
                    break;
                }
            }
        }
        // 대화창 이미지도 같이 활/비활성화
        talkPanel.SetActive(isAction);
        talkText.gameObject.SetActive(isAction);
        Debug.Log(talkPanel.activeSelf);
        Debug.Log(talkText.IsActive());
    }

}
