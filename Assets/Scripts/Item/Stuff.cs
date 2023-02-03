using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehaviour을 상속 받지 않는 일반 C# 클래스의 멤버들을 유니티의 Inspector 슬롯으로 띄워주려면
[System.Serializable]
public class Stuff
{
    // Stuff 속성
    public int stuffID; // 아이템 ID
    public string stuffName;
    public string stuffDescription; //아이템 설명(대화창, 인벤토리창)

    // 생성자
    public Stuff(int _stuffID, string _stuffName, string _stuffDescription)
    {
        // 아이템 속성 초기화 
        stuffID = _stuffID; 
        stuffName = _stuffName; 
        stuffDescription = _stuffDescription; 
    }
}
