using System.Collections;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = -5f;
    public float deceleration = 10f;

    //캐릭터 인식용 RayCast
    public float raycastDistance = 1f;
    public LayerMask enemyLayer;

    private Rigidbody2D _rigidbody;
    private bool facingRight = false;

    public Animator animator;

    private bool isFighting = false;

    private bool canAttack = true;
    public float attackCoolDown = 0.5f;

    private CharacterInformation _characterInformation;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _characterInformation = GetComponent<CharacterInformation>();

    }
        private void Start()
    {
        StartCoroutine(MercenaryDetectionRoutine());
    }

    private IEnumerator MercenaryDetectionRoutine()
    {
        while (true)
        {
            DetectMercenary();
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void DetectMercenary()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, facingRight ? Vector2.right : Vector2.left, raycastDistance, enemyLayer);

        if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Mercenary"))
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

    private void Attack(GameObject Mercenary)
    {
        if (canAttack)
        {
            animator.SetTrigger("Attack");

            CharacterInformation mercenaryHealth = Mercenary.GetComponent<CharacterInformation>();
            if (mercenaryHealth != null)
            {
                mercenaryHealth.TakeDamage(_characterInformation.currentAtk);
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

            // Flip character sprite
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
