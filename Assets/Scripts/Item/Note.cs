using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehaviour을 상속 받지 않는 일반 C# 클래스의 멤버들을 유니티의 Inspector 슬롯으로 띄워주려면
[System.Serializable]
public class Note
{
    // Stuff 속성
    public int noteID; // 아이템 ID
    public string noteContent; //아이템 설명(대화창, 인벤토리창)
    public Sprite noteIcon; //아이템 이미지
    public bool isGet; // 쪽지를 얻은 직후 true

    // 생성자
    public Note(int _noteID, string _noteContent, bool _isGet)
    {
        // 속성 초기화 
        noteID = _noteID;
        noteContent = _noteContent;
        isGet = _isGet;
        // resources 파일에 있는 letter 이미지를 가져온다. 
        noteIcon = Resources.Load("letter", typeof(Sprite)) as Sprite; 
    }
}
