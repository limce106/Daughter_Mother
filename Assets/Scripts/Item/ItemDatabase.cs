using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    /* ID 0~99 : 습득가능한 아이템, 100~999 : 습득불가능한 오브젝트, 1001~1003 : 쪽지 */
    // 아이템 리스트
    // itemList에 아이템들을 등록함
    public List<Item> itemList = new List<Item>();
    // objList에 습득 불가능한 배경 오브젝트들을 등록
    public List<Stuff> stuffList = new List<Stuff>();
    // 쪽지 리스트 (총 3개의 쪽지를 얻어야 함.)
    public List<Note> NoteList = new List<Note>();


    private void Start() { 
        // 쪽지 리스트에 쪽지 추가 (Add) 
       NoteList.Add(new Note(1001, PlayerPrefs.GetString("Name") + "아 엄마는 놀이터에 있어\n엄마를 찾으러 와줄래?", false));
       NoteList.Add(new Note(1002, "곰인형과 재미있게 놀았니?\n엄마는 지금 문방구에 있단다.\n문방구로 와줄래? ", true));
       NoteList.Add(new Note(1003, "오랜만에 달콤한 냄새를 맡아보니까 어땠니?\n엄마는 지금 학교에 있단다.\n학교에 와줄래?", true));

        // 아이템 리스트에 아이템 추가 (Add)
        itemList.Add(new Item(0, "마법봉장난감", PlayerPrefs.GetString("Name") + "(이)가 제일 좋아하는 마법봉 장난감이다. \n\n공격력 +3", 3, Item.ItemType.Weapon, false));
        itemList.Add(new Item(1, "국자", "달고나 만들 때 유용한 국자이다. \n\n공격력 +5", 5, Item.ItemType.Weapon, false));
        itemList.Add(new Item(2, "가위", "문방구에 있던 새 가위이다. \n\n공격력 +7", 7, Item.ItemType.Weapon, false));
        itemList.Add(new Item(3, "낡은 옷", "산타클로스 무늬가 있는 빨간 스웨터이다. \n\n방어력 +1", 1, Item.ItemType.Shield, false));
        itemList.Add(new Item(4, "장난감방패", "만화영화 핏치피치어벤저스에서 주인공이 사용하는 방패이다. \n\n방어력 +3", 3, Item.ItemType.Shield, false));
        itemList.Add(new Item(5, "싸구려 목걸이", "문방구에서 뽑기를 하면 얻을 수 있는 목걸이다. \n\n방어력 +5", 5, Item.ItemType.Shield, false));
        itemList.Add(new Item(6, "사과", "먹음직스러워 보이는 잘익은 사과이다. \n\n체력 +50", 50, Item.ItemType.Potion, false));
        itemList.Add(new Item(7, "빵", "쓰레기통 근처에 떨어져 있었던 빵이다. \n\n체력 +10", 10, Item.ItemType.Potion, false));
        itemList.Add(new Item(8, "사탕", "놀이터 한 가운데에 떨어져 있던 딸기맛 사탕이다. \n\n체력 +20", 20, Item.ItemType.Potion, false));
        itemList.Add(new Item(9, "쿠키", "안촉촉한초코칩나라의 초코쿠키이다. \n\n체력 +40", 40, Item.ItemType.Potion, false));
        
        // Stuff 리스트에 오브젝트 추가 (Add) 
        // Bedroom
        stuffList.Add(new Stuff(100, "일기장", "책상위에 알록달록한 필통과 그림일기장이 놓여있다."));
        stuffList.Add(new Stuff(101, "쓰레기통", "지우개 가루와 눈높이 학습지가 버려져있다."));
        stuffList.Add(new Stuff(102, "침대", "방금까지 자고 일어난 침대이다."));
        stuffList.Add(new Stuff(103, "스탠드", "잠 자기 전에 켜놓는 노란빛의 스탠드이다."));
        // Kitchen
        stuffList.Add(new Stuff(104, "냉장고", "내가 좋아하는 음식들로 가득 차 있다."));
        stuffList.Add(new Stuff(105, "싱크대", "설거지가 가득 쌓여있는 싱크대이다."));
        stuffList.Add(new Stuff(106, "가스레인지", "맛있는 라면을 끓여 먹을 수 있는 가스레인지이다."));
        stuffList.Add(new Stuff(107, "선반", "엄마가 좋아하는 그릇과 예쁜 찻잔이 있는 선반이다."));
        stuffList.Add(new Stuff(108, "화병", "엄마가 좋아하는 꽃인 데이지이다."));
        stuffList.Add(new Stuff(109, "쓰레기통", "과자 봉지가 버려져 있다."));
        // Livingtoom
        stuffList.Add(new Stuff(110, "벽에 걸린 사진1", "내가 학교에서 그린 밤하늘 그림이다."));
        stuffList.Add(new Stuff(111, "벽에 걸린 사진2", "엄마와 함께 찍은 사진이다."));
        stuffList.Add(new Stuff(112, "화초1", "공기정화를 해주는 화초이다."));
        stuffList.Add(new Stuff(113, "화초2", "내가 좋아하는 꽃인 리시안셔스이다."));
        stuffList.Add(new Stuff(114, "소파", "엄마와 함께 자주 앉던 노란색 소파이다."));
        stuffList.Add(new Stuff(115, "쿠션", "소파와 한세트인 푹신푹신한 쿠션이다."));
        stuffList.Add(new Stuff(116, "엄마의 사진", "엄마의 모습이 담긴 사진. 사진을 보고 있으니 엄마를 빨리 보고 싶다."));
        stuffList.Add(new Stuff(117, "털실", "목도리를 만들다 만 털실이다."));
        stuffList.Add(new Stuff(118, "뜨개질 바늘", "목도리를 만들 때 사용했던 대바늘이다."));
        // Road 
        stuffList.Add(new Stuff(119, "가로등", "어두운 밤을 밝혀주는 한줄기의 빛! 가로등이다."));
        stuffList.Add(new Stuff(120, "쓰레기통1", "쓰레기가 거의 없는 텅 빈 쓰레기통이다."));
        stuffList.Add(new Stuff(121, "쓰레기통2", "쓰레기가 가득 찬 쓰레기통이다."));
        stuffList.Add(new Stuff(122, "의류수거함", "더이상 입지 않는 옷을 넣어두는 의류수거함이다."));
        stuffList.Add(new Stuff(123, "깨진 유리 조각", "누군가 무단 투기한 깨진 유리 조각이다. 앗 따갑다!"));
        // Enemy1(놀이터)
        stuffList.Add(new Stuff(124, "그네", "내가 재미있게 바이킹을 타던 그네이다."));
        stuffList.Add(new Stuff(125, "시소", "놀이터의 인기 No.1 시소이다."));
        stuffList.Add(new Stuff(126, "타이어", "친구들이 앉거나 올라가서 놀 수 있는 타이어이다."));
        stuffList.Add(new Stuff(127, "모래놀이 장난감", "모래성을 만들 수 있는 장난감이다."));
        // Enemy2(문방구)
        stuffList.Add(new Stuff(128, "아이스크림 냉장고", "여름철 문방구 필수품 아이스크림 냉장고이다."));
        stuffList.Add(new Stuff(129, "음료수 냉장고", "맛있는 음료들이 있는 음료수 냉장고이다. 내가 제일 좋아하는 음료수는 팬돌이♪"));
        stuffList.Add(new Stuff(130, "선반", "공책과 물감 등 여러가지 문구들이 있는 선반이다."));
        stuffList.Add(new Stuff(131, "계산대", "여러가지 물건을 계산할 수 있는 계산대이다."));
        // Enemy3(학교)
        stuffList.Add(new Stuff(132, "벤치", "페인트가 벗겨진 벤치이다."));
        stuffList.Add(new Stuff(133, "시험지", "만점을 받은 시험지이다. 전교 1등이 떨어뜨린 시험지인가.."));
        stuffList.Add(new Stuff(134, "책", "운동장에 버려진 책이다. 공부를 안하나 보다.."));
        stuffList.Add(new Stuff(135, "농구 골대", "학교 친구들의 점심시간을 책임지는 든든한 농구 골대이다."));
    }


    // 아이템을 사용했을 때의 스탯 변화
    public void UseItem(int _itemID)
    {
        switch (_itemID)
        {
            // 무기
            case 0: // 마법봉 장난감
                WearWeapon(0);
                break;
            case 1: // 국자
                WearWeapon(1);
                break;
            case 2: // 가위
                WearWeapon(2);
                break;
            // 방어구
            case 3: // 낡은 옷
                WearShield(3);
                break;
            case 4: // 장난감 방패
                WearShield(4);
                break;
            case 5: // 싸구려 목걸이
                WearShield(5);
                break;
            // 체력회복아이템
            case 6: // 사과
                UsePotion(6);
                break;
            case 7: // 빵
                UsePotion(7);
                break;
            case 8: // 사탕
                UsePotion(8);
                break;
            case 9: // 쿠키
                UsePotion(9);
                break;
        }
    }

    // 무기 착용했을 때
    public void WearWeapon(int id)
    {
        PlayerStat.instance.AKT = itemList[id].itemValue;
        PlayerStat.instance.weapon = itemList[id];
    }
    // 방어구 착용했을 때
    public void WearShield(int id) 
    {
        PlayerStat.instance.DEF = itemList[id].itemValue;
        PlayerStat.instance.shield = itemList[id];
    }
    
    // 체력회복아이템 먹었을 때 플레이어 스탯 조정
    public void UsePotion(int id)
    {
        // 아이템 복용 후 플레이어의 최대 HP를 넘으면 안된다. 
        if (PlayerStat.instance.HP >= PlayerStat.instance.currentHP + itemList[id].itemValue) 
        {
            PlayerStat.instance.currentHP += itemList[id].itemValue;
        }
        else
        {
            PlayerStat.instance.currentHP = PlayerStat.instance.HP;
        }
    }
}