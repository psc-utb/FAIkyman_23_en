using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class KnightController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Horizontal speed of the knight")]
    float speed = 3;

    Animator _animator;
    Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    bool isAttacking = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire") && isAttacking == false)
        {
            _animator.SetTrigger("Attack");
            isAttacking = true;
        }


        float vx = Input.GetAxisRaw("Horizontal");

        if (vx != 0 && isAttacking == false)
        {
            _animator.SetBool("Moving", true);
            _rigidbody2D.velocity = new Vector2(vx * speed, _rigidbody2D.velocity.y);
        }
        else
        {
            _animator.SetBool("Moving", false);
            _rigidbody2D.velocity = Vector2.zero;
        }
    }

    private void LateUpdate()
    {
        if (transform.localScale.x > 0
            && _rigidbody2D.velocity.x < 0
            ||
            transform.localScale.x < 0
            && _rigidbody2D.velocity.x > 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    public void StopAttacking()
    {
        isAttacking = false;
    }

    public void RunDeadAnimation()

    {
        _animator.SetTrigger("Dead");
    }

    public void DestroyKnight()
    {
        Destroy(this.gameObject);
    }
}
