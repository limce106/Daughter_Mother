using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour 
{
    public static Inventory instance; 

    /* 아이템 인벤토리창 */
    public Text NameText; // 아이템을 선택 했을 때의 이름
    public Text DescriptionText; // 아이템을 선택 했을 때의 설명 
    private int selectedItem; // 선택된 아이템의 번호, 어떤 아이템을 선택했는지?

    private InventorySlot[] slots;  // 인벤토리 슬롯들
    private List<Item> inventoryItemList; // 플레이어가 소지한 아이템 리스트 
    public Transform tf; // Slot의 부모 객체. (그리드 슬롯) // 부모 객체의 자식 객체들 즉, slot. InventorySlot[] 안에 넣음

    public GameObject inventoryPanel; // 인벤토리창 UI
    public bool activeInventory = false; // 인벤토리창 활성화시 true

    public ItemDatabase theDatabase; // 아이템데이터베이스에 접근
    private const int NONE = -1;  // selectedItem 이 -1일 때 : 선택한 슬롯이 없음 (슬롯은 0~11)

    /* 장비창 (HP, 공격력, 방어력) */
    public Text UserNameText; // 플레이어가 지정한 캐릭터 이름
    public Text HPText; // 플레이어 HP
    public Image weaponIcon; // 플레이어가 현재 장착한 무기 아이콘
    public Image shieldIcon; // 플레이어가 현재 장착한 방어구 아이콘
    public Image noteIcon; // 플레이어가 현재 습득한 쪽지의 아이콘
    public Text atkText; // 플레이어가 현재 장착한 무기의 공격력
    public Text defText; // 플레이어가 현재 장착한 방어구의 방어력
    public Text noteGrade; // 플레이어가 현재 얻은 쪽지의 단계
    public Note currentNote; // 현재 플레이어가 습득한 쪽지


    /* 함수 */
    // 시작 : 인벤토리창 초기화
    void Start() 
    {
        // 초기화 진행
        instance = this;
        inventoryItemList = new List<Item>(); //인벤토리 아이템 리스트 초기화
        slots = tf.GetComponentsInChildren<InventorySlot>(); // 그리드의 자식객체인 slot들이 배열 slots에 들어감
        theDatabase = FindObjectOfType<ItemDatabase>(); // ItemDataBase 스크립트
        UserNameText.text = PlayerPrefs.GetString("Name"); // 플레이어 이름 
        noteIcon.sprite = currentNote.noteIcon; // 쪽지 이미지는 한번 획득하면 바뀌지 X

        inventoryPanel.SetActive(activeInventory); //인벤토리 UI 활성화 여부
    }

    void Update()
    {
        HPText.text = "체력 : " + PlayerStat.instance.currentHP.ToString(); 

        // 키보드 C를 눌러서 인벤토리 UI를 열고닫는다. 
        if (Input.GetKeyDown(KeyCode.C))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
            // 인벤토리 창을 열면 SelectedItem 초기화~!!
            selectedItem = NONE;
            // 설명창 초기화
            PrintEmptyText(); 

        }
        // 인벤토리가 활성화 된 경우에
        // 마우스 왼쪽 버튼으로 slot을 클릭하면 정보를 확인할 수 있다.
        // 더블클릭 혹은 스페이스를 누르면 장착/사용 할 수 있다.  
        if (activeInventory)
        {
            // 아이템 슬롯에 보유 아이템을 띄운다. (아이템 활성화)
            ShowItem(); 
        }
    }

    // 아이템 슬롯 초기화 (invenrotyItemList에 아이템들을 넣어서 화면에 보여줌)
    public void ShowItem()
    {   
        for(int i = 0; i < 11; i++) // 아이템 슬롯의 개수는 총 12개
        {
            // 인벤토리 아이템 리스트의 내용을, 인벤토리 슬롯에 추가 
            if (i < inventoryItemList.Count)
            {
                // 활성화
                slots[i].gameObject.SetActive(true);
                // slots 배열에 소지한 아이템의 정보(Icon)을 넣음
                slots[i].AddItem(inventoryItemList[i]);
            }
            else
            {
                // 가지고 있는 아이템의 개수보다 남는 슬롯의 아이콘은 지워줌. 
                slots[i].RemoveItem();
            }
        }
    }

    // 슬롯을 마우스로 한 번 눌렀을 때 -> 아이템의 이름과 정보를 띄운다. 
    public void OnClickButton() 
    {
        // 방금 클릭한 버튼 오브젝트를 가져와서 저장
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        // 아이템 슬롯의 개수만큼 탐색한다. 
        for (int i =0; i < slots.Length; i++) 
        {
            // 만약 보유한 아이템의 수보다 작은 인덱스(버튼의 이름)의 슬롯 버튼을 클릭했을 때,
            // 클릭한게 i번째라면 (버튼 오브젝트의 이름을 미리 변경)
            // i = selectedItem이라면 장착하므로 제외
            if ((i < inventoryItemList.Count) && (clickedButton.name == ("Slot" + i) && (i != selectedItem)))
            {
                // 선택한 아이템의 인덱스를 i로 바꾸어 주고
                selectedItem = i;
                // selectedItem 번째의 슬롯으로 아이템 이름 및 설명 텍스트 바꾼다. 
                PrintText(); 
                break;
            }
            // 더블클릭 : 이미 한번 selected된 버튼을 한번 더 클릭 한 것.
            else if ((i < inventoryItemList.Count) && (clickedButton.name == ("Slot" + i) && (i == selectedItem)))
            {
                // 아이템 사용 -> 스탯 적용
                theDatabase.UseItem(inventoryItemList[i].itemID);

                // InventoyItemList[i]의 itemType에 따라서
                // 장비일 경우 PlayerStat - 장비에 추가, 플레이어의 공격력 증가, 이미지를 인벤토리에 띄움
                if (inventoryItemList[i].itemType == Item.ItemType.Weapon)
                {
                    weaponIcon.sprite = inventoryItemList[i].itemIcon; 
                    atkText.text = inventoryItemList[i].itemValue.ToString();
                }
                // 방어구일 결우 플레이어의 stat - 방어구에 추가, 플레이어의 방어력 증가, 이미지를 인벤토리에 띄움
                else if (inventoryItemList[i].itemType == Item.ItemType.Shield)
                {
                    shieldIcon.sprite = inventoryItemList[i].itemIcon;
                    defText.text = inventoryItemList[i].itemValue.ToString();
                }
                // 소모품일 경우 플레이어의 stat - HP를 수치만큼 증가하고 InventoryItemList에서 삭제함
                else if (inventoryItemList[i].itemType == Item.ItemType.Potion)
                {
                    inventoryItemList.RemoveAt(i); 
                    ShowItem(); 
                }
                break;
            }
            // 선택한 버튼이 아이템의 수보다 큰 인덱스의 슬롯 버튼일 때, (빈 슬롯 클릭)
            else if (clickedButton.name == ("Slot" + i))
            {
                // 빈 텍스트를 나타낸다. 
                PrintEmptyText(); 
                // 선택된 아이템 X (아이템 슬롯 한번 누르고 -> 빈 슬롯 누르고 -> 다시 같은 아이템 눌렀을 때 장비되는 것 막기 위함)
                selectedItem = NONE;
                break; 
            }
            else
            Debug.Log("왜 안될까");
        }
    }

    // 쪽지 버튼을 눌렀을 때, 쪽지의 내용이 나온다. 
    public void OnClickNoteButton()
    {
        NameText.text = " ";
        DescriptionText.text = currentNote.noteContent;
        selectedItem = NONE;
    }

    // 아이템 이름과 설명 텍스트를 공백으로
    public void PrintEmptyText()
    {
        NameText.text = " "; 
        DescriptionText.text = " "; 
    }
    // 아이템 이름과 설명을 선택한 아이템의 것으로
    public void PrintText()
    {
        NameText.text = inventoryItemList[selectedItem].itemName; 
        DescriptionText.text = inventoryItemList[selectedItem].itemDescription; 
    }

    // 아이템 찾기
    public void GetAnItem(int _itemID)
    {
        // 데이터베이스 검색 
        // 데이터 베이스의 아이템 리스트 크기만큼 반복하며 ID를 찾음
        for (int i = 0; i < theDatabase.itemList.Count; i++) 
        {
            if (_itemID == theDatabase.itemList[i].itemID) //베이스에서 ID를 찾으면
            {
                inventoryItemList.Add(theDatabase.itemList[i]); //inventoruItemList에 추가
                return;
            }
        }
        // 만약 데이터베이스에서 해당 ID의 아이템을 발견하지 못하면 에러창을 띄움.
        Debug.LogError("데이터베이스에 해당 ID를 가진 아이템이 존재하지 않습니다.");
    }

    // 쪽지를 얻었을 때 ??
    public void GetANote(int _itemID)
    {
        currentNote = theDatabase.NoteList[_itemID-1001]; // 아이템 이름 삭제
        noteIcon.sprite = currentNote.noteIcon; //아이콘 변경
        noteGrade.text = (currentNote.noteID - 1000).ToString(); // 몇단계의 쪽지인지
        selectedItem = NONE; 
    }
}
