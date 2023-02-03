using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgmManager : MonoBehaviour
{
    public static BgmManager instance;  //싱글톤화시킴=>이건 씬이 넘어가도 파괴되면 안되기 때문

    public AudioClip[] clips; // 배경음악들

    private AudioSource source;

    //에너미의 에너미무빙 변수가 true일 때만 브금이 나오게 설정
    public Enemy1Controller ecbgm1;
    public Enemy2Controller ecbgm2;
    public Enemy3Controller ecbgm3;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }

    }


    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play(int _playMusicTrack)
    { //_playMusicTrack 오디오를 베열에 넣기 때문에 몇번째 곡을 진행할 건지
        source.volume = 1f;
        source.clip = clips[_playMusicTrack];
        source.Play();

        //게임오버 씬일 때 게임오버노래로 바꾸기
        if(SceneManager.GetActiveScene().name == "GameOver")
        {
            source.clip = clips[2]; //클립이란 배열에 있는 2번인 게임오버 브금 재생
            source.Play();
        }
        //전투씬일 때 전투 브금으로 바꾸기
        if(SceneManager.GetActiveScene().name == "Enemy1" || SceneManager.GetActiveScene().name == "Enemy2" || SceneManager.GetActiveScene().name == "Enemy3")
        {
            //에너미 무빙이 true일때만 재생
            if ((ecbgm1.enemyMoving == true) || (ecbgm2.enemyMoving == true) || (ecbgm2.enemyMoving == true))
            {
                source.clip = clips[1]; //클립이란 배열에 있는 1번인 전투 브금 재생
                source.Play();
                
                //그리고 에너미의 피가 0이 되면  메모리 음악 재생 후 다시 배경음악 재생
                //여기 수정
                if (ecbgm1.hp <= 0)
                {
                    source.clip = clips[0];
                    source.Play();
                }
            }
        }
    }
    public void Stop()
    {
        source.Stop();
    }
}
