using UnityEngine;
using System.Collections;

public class HumanMove : MonoBehaviour
{
    public float speed = 2f;
    public float deceleration = 10f;

    public float raycastDistance = 5f;
    public LayerMask enemyLayer;

    private Rigidbody2D _rigidbody;
    private bool facingRight = true;

    public Animator animator;

    private bool isFighting = false;

    private bool canAttack = true;
    public float attackCoolDown = 1.0f;

    private CharacterInformation _characterInformation;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _characterInformation = GetComponent<CharacterInformation>();
    }

    private void Start()
    {
        StartCoroutine(DemonDetectionRoutine());
    }
    private IEnumerator DemonDetectionRoutine()
    {
        while (true)
        {
            DetectDemon();
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void Update()
    {
        MoveAutomatically();

    }

    private void MoveAutomatically()
    {
        Vector2 movement = new Vector2(speed, 0);

        if (isFighting)
        {
            _rigidbody.velocity = Vector2.Lerp(_rigidbody.velocity, Vector2.zero, deceleration * Time.deltaTime);
        }
        else
        {
            _rigidbody.velocity = movement;
        }

        animator.SetFloat("RunState", _rigidbody.velocity.magnitude > 0 ? 0.5f : 0);
        Flip(_rigidbody.velocity.x);
    }   

    private void DetectDemon()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, facingRight ? Vector2.right : Vector2.left, raycastDistance, enemyLayer);

        if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            isFighting = true;
            _rigidbody.velocity = Vector2.zero;

            Attack(hit.collider.gameObject);
        }
        else
        {
            isFighting = false;
        }
    }

    private void Attack(GameObject enemy)
    {
        if (canAttack)
        {
            animator.SetTrigger("Attack");

            CharacterInformation enemyHealth = enemy.GetComponent<CharacterInformation>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(_characterInformation.currentAtk);
            }

            StartCoroutine(StartAttackCooldown());
        }
    }

    private IEnumerator StartAttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCoolDown);
        canAttack = true;
    }

    private void Flip(float velocityX)
    {
        if (velocityX > 0 && !facingRight || velocityX < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
