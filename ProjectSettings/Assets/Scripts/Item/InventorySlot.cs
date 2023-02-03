using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    // 슬롯 UI에 나타나는 요소들
    public Image icon; // 이미지
    // 아이템 선택 시 배경 변화하는 버튼
    public GameObject selectedItem;

    // 아이템을 인벤토리 UI에 추가
    public void AddItem(Item _item)
    {
        // 텍스트에 매개변수로 받은 item의 정보를 넣는다.
        icon.sprite = _item.itemIcon;
    }
    // 아이템을 인벤토리 UI에서 제거
    public void RemoveItem()
    {
        // 요소들 초기화
        icon.sprite = null;
    }

}
