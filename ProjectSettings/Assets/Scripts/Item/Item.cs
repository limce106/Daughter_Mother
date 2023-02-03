using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// MonoBehaviour을 상속 받지 않는 일반 C# 클래스의 멤버들을 유니티의 Inspector 슬롯으로 띄워주려면
[System.Serializable]
public class Item 
{
    // 아이템 속성
    public int itemID; // 아이템 ID (이미지 파일의 이름)
    public int itemValue;
    public string itemName; //아이템 이름 (한글로)
    public string itemDescription; //아이템 설명(대화창, 인벤토리창)
    public Sprite itemIcon; //아이템 이미지
    public ItemType itemType; //아이템 종류 중 1가지 값을 가짐
    public bool isGet; // 아이템을 얻으면 true로..

    // 아이템타입 열거 (무기, 방어구, 체력회복아이템)
    public enum ItemType
    {
        Weapon,
        Shield,
        Potion
    }

    // 생성자
    public Item(int _itemID, string _itemName, string _itemDescription, int _itemValue, ItemType _itemType, bool _isGet) 
    { 
        // 아이템 속성 초기화 
        itemID = _itemID;
        itemName = _itemName;
        itemDescription = _itemDescription;
        itemValue = _itemValue;
        itemType = _itemType;
        isGet = _isGet;
        // resources 파일 내부에 있는 파일의 이름 = 아이템의 이름
        // resources 파일에 있는 이미지를 가져온다. 
        itemIcon = Resources.Load("ItemIcon/" + _itemID, typeof(Sprite)) as Sprite;
    }
}
