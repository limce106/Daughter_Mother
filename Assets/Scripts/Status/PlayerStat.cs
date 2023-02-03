using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStat : MonoBehaviour
{
    // 인스턴스 만들기
    public static PlayerStat instance;

    // 플레이어 속성
    public int HP;
    public int currentHP;
    public int AKT;
    public int DEF;
    public Item weapon; 
    public Item shield; 

    // 빈 장비 (착용 전)
    public Item emptyItem;

    //체력바
    public Slider hpSlider;
    public Text hpText;

    void Start()
    {
        emptyItem = new Item(-1, "손", "", 0, Item.ItemType.Weapon, false); //기본 장비(손)
        instance = this;
        weapon = emptyItem;
        hpSlider.gameObject.SetActive(false); // -> 상태를 false로
    }

    // Enemy에게 공격당했을 때 플레이어의 체력이 0이 되었을 떄
    public void Dead()
    {
        // 에너미 공격력 에서 플레이어 방어력을 제외한 만큼 데미지를 입음
        //int dmg = _enemyAtk - DEF;
        //currentHP -= dmg;
        // HP 0 -> 게임 오버
        if (currentHP <= 0)
        {
            currentHP = 0; // (음수X) 
            // 게임오버 씬 불러오기
            SceneManager.LoadScene("GameOver");
            // bgm 변화
            BgmManager.instance.Play(2);
            // 플레이어 오브젝트 삭제 -> DontDestroyObjcst 코드에서
            // 인벤토리 초기화 하기 -> DontDestroyObjcst 코드에서
        }

        // 데미지 입었을 때 음향, 이미지 효과들 적용
    }
    void Update()
    {
        hpSlider.maxValue = HP;
        hpSlider.value = currentHP;

        //체력 텍스트 출력
        string v = currentHP.ToString();
        hpText.text = v;

        // HP가 0 일 때,
        Dead();
    }
}
