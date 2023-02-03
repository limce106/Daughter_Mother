using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement; //Scene 매니저 라이브러리 추가

//public class TransferMap : MonoBehaviour
//{
//    public string transferMapName; // 이동할 맵이름

//    // Start is called before the first frame update
//    void Start()
//    {
//        DontDestroyOnLoad(this.gameObject); // 게임 오브젝트 파괴금지

//        // 애니메이터 컴포넌트 가져오기
//        boxCollider = GetComponent<BoxCollider2D>();
//        animator = GetComponent<Animator>();
//    }

//    // 박스 콜라이더에 닿는 순간 이벤트 발생
//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.gameObject.name == "Player")
//        {
//            thePlayer.currentMapName = transferMapName;
//            //SceneManager.LoadScene(transferMapName);
//            theCamera.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, theCamera.transform.position.z);
//            thePlayer.transform.position = target.transform.position;

//        }
//    }
//}
