using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    // 카메라가 따라갈 대상
    private GameObject target;
    // 카메라가 따라갈 속도
    public float moveSpeed;
    // 대상의 현재 위치
    private Vector3 targetPosition;


    //로드 씬 거리에서만 작동하게 추가
    public BoxCollider2D bound;//영역 지정한 것
    public BoxCollider2D boundCenter; //중간지점을 밟으면 카메라의 y좌표 -10이 됨
    //바운드 영역안의 최소 최대 xyz값을 지님.
    private Vector3 minBound;
    private Vector3 maxBound;
    //카메라가 중심을 이용해 움직이기 때문에 카메라의 반너비, 반높이를 지닐 변수
    //이걸 영역에서 빼서 사용 
    private float halfWidth;
    private float halfHeight;
    //카메라의 반높이값을 구할 속성을 이용하기 위한 변수.
    private Camera theCamera;
    
    //중앙에 있는 boundCenter를 만나면 카메라의 현재 y값 좌표 고정

    void Start()
    {
        target = GameObject.Find("Player");
        // DontDestroyOnLoad(this.gameObject); // 게임 오브젝트 파괴금지 -> 로드에서만 쓸거니까
        // 2월4일 수정
        //target = GameObject.Find("Player");
        if (SceneManager.GetActiveScene().name == "Road")
        {
            Debug.Log("로드씬 확인");
            theCamera = GetComponent<Camera>();
            minBound = bound.bounds.min;    //bound변수의 영역에 min이라는 최솟값을 넣겠다는 말
            maxBound = bound.bounds.max;
            halfHeight = theCamera.orthographicSize;  //카메라의 반높이  카메라 사이즈:5  
            halfWidth = halfHeight * Screen.width / Screen.height;
        }
    }

    void Update()
    {
        // 대상이 있는지 체크
        if (target.gameObject != null)
        {
            // 플레이어의 위치값 설정
            // this는 카메라를 의미 (z값은 카메라값을 그대로 유지) 
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
            
            // vectorA -> B까지 T의 속도로 이동
            // 타겟의 위치로... 즉 카메라의 중심이 플레이어
            // 1초에 movespeed 만큼 이동
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            
            if(SceneManager.GetActiveScene().name == "Road")
            {
                float clampedX = Mathf.Clamp(this.transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth);
                float clampedY = Mathf.Clamp(this.transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);
                this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);

                if((target.transform.position.y <= 10) && (target.transform.position.x <= 18) && (target.transform.position.x >= 13))
                {
                    void OnTriggerEnter2D(Collider2D collision)
                    {
                        print("중앙 충돌");
                        this.transform.position = new Vector3(clampedX, -10, this.transform.position.z);
                    }
                    OnTriggerEnter2D(boundCenter);
                }
            }
        }
    }
}
