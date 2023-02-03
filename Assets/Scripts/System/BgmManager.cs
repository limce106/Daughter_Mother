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
        // DontDestroy 설정
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
        // 소스 초기화
        source = GetComponent<AudioSource>();
        // playerMusicTrack 초기화
        Play(0);
    }

    // 음악을 재생시키는 함수
    public void Play(int _playMusicTrack)
    {
        // 크기 조정
        source.volume = 1f;
        if (_playMusicTrack == 1)
        {
            source.volume = 0.7f;
        }
        //_playMusicTrack 오디오를 베열에 넣기 때문에 몇번째 곡을 진행할 건지
        source.clip = clips[_playMusicTrack];
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }
}
