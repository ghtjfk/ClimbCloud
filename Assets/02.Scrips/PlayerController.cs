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
            rigid2D.AddForce(transform.up * jumpForce);     //�����Ѵ�.
        }
        
        //�� ����� ������ �� y���� �ӵ��� �ʹ� Ŀ�� ���߿��� ���� ������ �ſ�ſ� �̼��ϴ�.
        //�¿� Ű�� ����
        int key = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
        }

        //�÷��̾� �ӵ�
        float speedX = Mathf.Abs(rigid2D.velocity.x);

        //���ǵ� ����
        if (speedX < maxWalkSpped)
        {
            rigid2D.AddForce(transform.right * key * walkForce);    //�����̱�
        }

        //�����̴� ���⿡ ���� ȸ����Ű�� (��ƽ�� �¿� ����)
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //�÷��̾� �����̴� �ӵ��� ���� �ִϸ��̼� ����
        animator.speed = speedX / 2.0f;


        /*���2 (Pong�� ���� ���������, �̹��� �߷±��� ����ؾ� �ؼ� ���� ����)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid2D.AddForce(transform.right * -walkForce);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid2D.AddForce(transform.right * walkForce);
        }
        */




        /*���3
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

    //��߰��� �浹�� Trigger ���� üũ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("ClearScene");
    }
}
