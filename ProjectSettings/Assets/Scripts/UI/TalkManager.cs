using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public List<string> Talk1 = new List<string>();
    public List<string> Talk2 = new List<string>();
    public List<string> Talk3 = new List<string>();
    public List<string> Talk4 = new List<string>();
    public List<string> Talk5 = new List<string>();
    public List<string> Talk6 = new List<string>();
    public List<string> Talk7 = new List<string>();
    public List<string> Talk8 = new List<string>();
    public List<string> Talk9 = new List<string>();
    public List<string> Talk10 = new List<string>();
    public List<string> Talk11 = new List<string>();

    public string system1;
    public string system2;
    public List<string> talk1 = new List<string>();
    public string talk2;

    // 씬 이름은 임의로 설정함->나중에 변경
    void Start()
    {
        // STAGE1
        // 플레이어
        Talk1.Add("어두운 밤 20XX년 XX월 XX일 밤 자정, 서울의 한 가정집");
        Talk1.Add("방에서 잠을 자고 있었던 " + PlayerPrefs.GetString("Name") + "는 눈을 뜬다");
        Talk1.Add("어? 엄마... 어디갔어?");
        Talk1.Add("엄마없인 무서워서 못자는데 흐앙..");
        Talk1.Add("바닥에 저건 뭐지?");
        talk1.Add("엄마를 찾으러 가봐야겠다!");

        // STAGE2
        // 플레이어
        Talk2.Add("오늘따라 뭔가 꿈속에 있는 것 같아!");
        Talk2.Add("엄마가 왜 놀이터에 갔지? 일단 빨리 놀이터에 가보자!"); 

        Talk3.Add("근데 이게 뭐지..? 엇! 엄마가 작년 생일에 사준 곰인형이잖아!");
        // 곰 인형
        Talk3.Add("안녕? 오랜만이야! 오랫동안 나랑 안놀아줘서 조금 슬펐어...");
        Talk3.Add("엄마를 찾고있지? ");
        Talk3.Add("너네 엄마는 여기 없어 대신에...");
        Talk3.Add("엄마가 남긴 쪽지는 내가 가지고 있어");
        Talk3.Add("가지고 싶으면 빼앗아보던가!!");
        // 플레이어
        Talk4.Add("이 장면은 뭐지?  어 쪽지다.");
        Talk4.Add("곰인형과 재미있게 놀았니?");
        Talk4.Add("엄마는 지금 문방구에 있단다.");
        Talk4.Add("문방구로 와줄래?");
        Talk4.Add("엇 언제 문방구로 갔지? 얼른 문방구로 가야겠다.");

        // STAGE3
        // 플레이어
        Talk6.Add("와 뽑기다! 달콤한 냄새가 나는걸~"); //10
        Talk6.Add("엄마는 어디에 있는 걸까..?");
        Talk6.Add("어?! 바닥에 먹다 남은 달고나가 있어");

        Talk6.Add("자세히 보니 전에 엄마랑 문방구에서 만들었던 달고나와 비슷하게 생겼잖아!");
        Talk6.Add("엉망진창인 하트 모양이 똑같아. ㅎㅎ"); // 14
        // 달고나
        Talk6.Add("안녕! 나는 달고나야★");
        Talk6.Add("혹시.. 엄마를 찾고 있니?★");
        Talk6.Add("너희 엄마는 여기 없어! 다양한 문구와 맛있는 음식만이 있을 뿐이지..!★");
        Talk6.Add("엄마가 남긴 쪽지를 내가 가지고 있어★");
        Talk6.Add("쪽지를 가지고 싶다면 나를 쓰러뜨려봐!★");
        // 플레이어
        Talk7.Add("도대체 이 장면들은 뭘까...? 벌써 두번째야...");
        Talk7.Add("오랜만에 달콤한 냄새를 맡아보니까 어땠니?");
        Talk7.Add("엄마는 지금 학교에 있단다.");
        Talk7.Add("학교에 와줄래?");
        Talk7.Add("아이참 언제 또 학교로 간거야! 이번엔 정말 있겠지? 빨리 학교로 가봐야겠다.");

        // STAGE4
        // 플레이어
        Talk8.Add("어느새 학교까지 왔네. 윽... 학교는 너무 싫어");
        Talk8.Add("아휴 엄마는 왜 자꾸 다른데로 가버리는 거야");

        Talk8.Add("어?! 잃어버린 내 가방!!!");
        Talk8.Add("으악! 엄마가 만들어 준 토끼 인형이 버둥거리고 있어");
        // 토끼 인형
        // ++ 이름 입력 완성 후 밑 코드도 변경
        Talk8.Add(PlayerPrefs.GetString("Name") + "아 안녕! 나를 구해줘서 고마워! 너랑 같이 학교에 가고 싶어서 몰래 들어왔는데 지퍼에 실이 끼어버렸지 뭐야");
        Talk8.Add("이제 너랑 학교에서 놀 수 있겠다!");
        Talk8.Add("나와 함께 놀자! 그러면 엄마가 어디있는지 알려줄게! 정말이야!"); // 2
        // 플레이어
        Talk8.Add("뭐? 정말이지? 그 약속 꼭 지켜!"); //22
        // 토끼 인형
        Talk10.Add("엄마를 정말 찾고 싶었구나? 그럼 너와 한 약속 내가 이뤄줄게!"); // 기본
        // 플레이어
        Talk10.Add("뭐지?"); // 플레이어 기본
        Talk10.Add("!!!!!!!!!"); // 플레이어 기본
        // 엄마
        // ++ 이름 입력 완성 후 밑 코드도 변경
        Talk10.Add(PlayerPrefs.GetString("Name") + "아 안녕?"); // 엄마 기본
        // 플레이어
        Talk10.Add("엄마!?"); // 플레이어 기본
        // 엄마
        Talk10.Add("맞아. 엄마야"); // 엄마 기본
        // 플레이어
        Talk10.Add("엄마가 토끼인형이었어?!"); // 플레이어 기본
        // 엄마
        Talk10.Add("왜 내가 토끼인형으로 변했고, 왜 내가 사라졌는지 궁금하지?"); // 엄마 기본
        Talk10.Add("사실 네가 자는 사이 엄마가 쪽지를 남겨서 여기로 오도록 불렀단다.");// 엄마 기본 8
        Talk10.Add("엄마는 곧 사라질거야.. 여기는 현실이 아니니까");// 엄마 눈물
        // 플레이어
        Talk10.Add("현실이 아니라고...?");// 플레이어 기본
        // 엄마
        Talk10.Add("응. 이곳은 엄마가 우리" + PlayerPrefs.GetString("Name") + "에게 선물해주고 싶어 만든 공간이야"); // 엄마 눈물
        Talk10.Add("지금까지 만났던 물건들과 스쳐 지나갔던 장면들.. 혹시 기억나니?"); // 엄마 눈물 12
        // 플레이어
        Talk10.Add("뭐..? 곰인형.. 달고나.. 토끼인형..... 그리고 떠올랐던 장면들.................");  // 플레이어 기본
        Talk10.Add("!!!!!!!!!");  // 플레이어 기본
        // 엄마
        Talk10.Add("맞아. 모두 엄마와 " + PlayerPrefs.GetString("Name") + "이가 함께했던 소중한 추억들이야"); // 엄마 눈물 15
        Talk10.Add("생일 때 엄마가 주었던 곰인형, 엄마와 함께 만들었던 달고나, 엄마가 만들어주었던 토끼 인형..");// 플레이어 기본
        Talk10.Add("사실 네가 가정을 꾸리고, 한 아이의 엄마가 되면서 어릴 적 너의 활기차고 장난기 있던 모습이 없어진 것처럼 보였어");
        Talk10.Add("그래서 어린 시절 엄마와" + PlayerPrefs.GetString("Name") + "이가 함께 했던 추억과 이 추억이 깃든 물건들을 보여준거야." +
            "어린 시절 순수하고 활기찼던" + PlayerPrefs.GetString("Name") + "이의 모습을 다시금 깨닫게 해주고 싶었어." +
            "진정한 너의 모습 말이야."); // 엄마 웃음 18
        // 플레이어
        Talk10.Add("엄마...... "); // 플레이어 눈물
        Talk10.Add("엄마 사실 나 지금까지 너무 힘들었어..");// 플레이어 눈물
        Talk10.Add("엄마라는 존재가 이렇게 무거운 존재라는 것을 내가 엄마가 되고나서 알게 되었어.");// 플레이어 눈물
        Talk10.Add("엄마 미안하고 너무 고마웠어");// 플레이어 눈물
        // 엄마
        // ++ 이름 입력 완성 후 밑 코드도 변경
        Talk10.Add(PlayerPrefs.GetString("Name") + "아 지금까지 너무 고생했어. 이제는 앞으로 너 다운 삶을 살기 바랄게." +
            "나야말로 나의 딸로 태어나줘서 정말 고맙단다."); // 엄마 웃음

        // STAGE5
        // 플레이어
        Talk11.Add("모든 게 다 꿈이었다니... 너무 생생했어");
        Talk11.Add("보고싶은 우리 엄마. 엄마도 나 보고싶어서 꿈에서 찾아온거지?");
        Talk11.Add("엄마, 정말 고마워. 나에게 소중한 경험을 할 수 있게 해줘서. 나 앞으로도 힘낼게");
    }
    public List<string> GetTalk(List<string> talkname, int talkIndex)
    {
        if (talkIndex == talkname.Count)
        {
            return null;
        }
        else
        {
            return talkname;
        }
    }
}
