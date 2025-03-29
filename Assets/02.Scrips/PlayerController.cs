using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public float jumpForce;
    public float walkForce;
    float maxWalkSpped = 2.0f;

    Animator animator;
    
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && rigid2D.velocity.y == 0)
        {
            animator.SetTrigger("Jump");
            rigid2D.AddForce(transform.up * jumpForce);     //점프한다.
        }
        
        //이 방법은 떨어질 때 y축의 속도가 너무 커서 공중에서 방향 조절이 매우매우 미세하다.
        //좌우 키값 지정
        int key = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
        }

        //플레이어 속도
        float speedX = Mathf.Abs(rigid2D.velocity.x);

        //스피드 제한
        if (speedX < maxWalkSpped)
        {
            rigid2D.AddForce(transform.right * key * walkForce);    //움직이기
        }

        //움직이는 방향에 따라 회전시키기 (케틱터 좌우 반전)
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //플레이어 움직이는 속도에 맞춰 애니메이션 적용
        animator.speed = speedX / 2.0f;


        /*방법2 (Pong과 같은 방식이지만, 이번엔 중력까지 고려해야 해서 옳지 않음)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid2D.AddForce(transform.right * -walkForce);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid2D.AddForce(transform.right * walkForce);
        }
        */




        /*방법3
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid2D.velocity = new Vector3(walkForce, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid2D.velocity = new Vector3(walkForce, 0, 0);
        }*/

        if (transform.position.y < -6)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    //깃발과의 충돌을 Trigger 모드로 체크
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("ClearScene");
    }
}
