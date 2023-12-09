using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

    public float speed = 5f;
    public float deceleration = 10f;

    private Rigidbody2D _rigidbody;
    public Animator animator;

    private bool facingRight = true;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        // ����� �Է� �� ������ ó��
        float moveX = Input.GetAxis("Horizontal");
        
        Vector2 movement = new Vector2(moveX, 0);
            
        if (movement == Vector2.zero) // ���� ����
        {
            _rigidbody.velocity = Vector2.Lerp(_rigidbody.velocity, Vector2.zero, deceleration * Time.deltaTime);
        }
        else
        {
            // �ӵ� ����
            _rigidbody.velocity = movement * speed;
        }

        //�ִϸ����� ���� �۵�
        if(moveX != 0)
        {
            animator.SetFloat("RunState", 0.5f);
        }
        else
        {
            animator.SetFloat("RunState", 0);
        }

        //�ӽ÷� ���� ���� ���
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger("Attack");
        }

        //ĳ���� ��������Ʈ ������
        Flip(moveX);

    }

    void Flip(float moveX)
    {
        if (moveX > 0 && !facingRight || moveX < 0 && facingRight)
        {
            facingRight = !facingRight;

            // ĳ������ �������� �������Ѽ� ������
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }


}
