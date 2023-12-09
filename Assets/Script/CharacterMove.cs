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
        // 사용자 입력 후 움직임 처리
        float moveX = Input.GetAxis("Horizontal");
        
        Vector2 movement = new Vector2(moveX, 0);
            
        if (movement == Vector2.zero) // 감속 적용
        {
            _rigidbody.velocity = Vector2.Lerp(_rigidbody.velocity, Vector2.zero, deceleration * Time.deltaTime);
        }
        else
        {
            // 속도 설정
            _rigidbody.velocity = movement * speed;
        }

        //애니메이터 변수 작동
        if(moveX != 0)
        {
            animator.SetFloat("RunState", 0.5f);
        }
        else
        {
            animator.SetFloat("RunState", 0);
        }

        //임시로 넣은 공격 기능
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger("Attack");
        }

        //캐릭터 스프라이트 뒤집기
        Flip(moveX);

    }

    void Flip(float moveX)
    {
        if (moveX > 0 && !facingRight || moveX < 0 && facingRight)
        {
            facingRight = !facingRight;

            // 캐릭터의 스케일을 반전시켜서 뒤집기
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }


}
