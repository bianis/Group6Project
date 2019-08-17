using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //BEJO
    public float speed;
    private Rigidbody2D _rigidbody2D;

    public GameObject slash;

    public Animator _animator;
    //cobamelee
    private float timeBtwAttack;
    public float startTimeAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;

    public float attackRange;
    public int damage;


    // Start is called before the first frame update
    void Start()
    {

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        _rigidbody2D.velocity = movement * speed;
        _animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        _animator.SetFloat("Horizontal", movement.x);
        _animator.SetFloat("Vertical", movement.y);
        _animator.SetFloat("Magnitude", movement.magnitude);


        transform.position = transform.position + movement * Time.deltaTime;


        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Cubes>().TakeDamage(damage);
                }
            }
            timeBtwAttack = startTimeAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
            _animator.SetBool("space", false);

        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(attackPos.position, attackRange);
    }
}
