using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BalloonKill : MonoBehaviour
{
    public GameObject Balloons; // 풍선 부모 오브젝트
    public GameObject[] babyballs; // 풍선 각 객체 배열
    public float[] idleTime; // 탭 사이 간격 체크용 시간 변수 저장용 배열
    public float playTime = 0f; // 전체 게임 시간 체크용 시간 변수
    public bool isKilling = false;  //풍선 터트리기 코루틴 체크용 불 변수
    public int ballcount = 0;   //풍선 배열 인덱스
    public GameObject POP; // 파티클 시스템 부모 오브젝트
    public GameObject[] Pop;  // 파티클 시스템 배열
    public bool isPlaying;
    public AudioClip popSound;
    public AudioSource audioSource;


    void Start()
    {
        
    }

    IEnumerator killball(int count)
    {
        isKilling = true;
        Pop[count].GetComponent<ParticleSystem>().Play();
        babyballs[count].gameObject.SetActive(false);

        while (true)
        {
            if (count >= babyballs.Length - 1)
            {
                isPlaying = false;
            }


            if (Inputdata.index_F < 50)
            {
                ballcount++;
                isKilling = false;
                break;

            }


            yield return null;
        }
        yield return null;
    }



    public void Update()
    {
        StartCoroutine(killball(ballcount));

    }


}
//탭간격(o), (10/전체시간)Hz, 파티클(O)
