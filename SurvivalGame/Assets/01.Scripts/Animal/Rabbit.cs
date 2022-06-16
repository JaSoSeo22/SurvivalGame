using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    [SerializeField] private string animalName;     // 동물의 이름
    [SerializeField] private int hp;        // 동물의 체력

    [SerializeField] private float walkSpeed;       // 걷기 스피드

    private Vector3 direction;      // 방향 설정

    // 상태변수
    private bool isAction;      // 행동중인지 아닌지 판별
    private bool isRunning;      // 걷는지 안 걷는지 판별

    [SerializeField] private float walkTime;        // 걷기 시간
    [SerializeField] private float waitTime;        // 대기 시간
    private float currentTime;      // 여기에 대기 시간 넣고 1초에 1씩 감소시킬 것

    // 필요한 컴포넌트
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private BoxCollider boxCol;


    void Start()
    {
        currentTime = waitTime;     // 대기시간 넣어줌
        isAction = true;        // 대기하는 것도 액션이니 트루줌
    }


    void Update()
    {
        ElapseTime();
        Move();
    }

    private void Move(){
        if(isRunning)
        rigid.MovePosition(transform.position + (transform.forward * walkSpeed * Time.deltaTime));
    }

    private void ElapseTime()
    {
        if (isAction)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
                ReSet(); // 다음 랜덤 행동 개시
        }
    }

    private void ReSet(){
        isRunning = false; isAction = true;
        anim.SetBool("Running", isRunning);
        direction.Set(0f, Random.Range(0f, 360f), 0f);
    }

    
}
