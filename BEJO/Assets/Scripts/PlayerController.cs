using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //BEJO
    public float speed;
    private Rigidbody2D _rigidbody2D;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");                          // bakal ngeset nilai secara otomatis
        float moveY = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(moveX, moveY);

        _rigidbody2D.velocity = direction * speed;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));  // bagian atas kanan

        min.x += 0.285f;
        //max.x += 0.285f;
        max.x += 0f;
        min.y += 0.250f;
        max.y += 0.250f;

        Vector2 pos = _rigidbody2D.position;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);                           // dia tidak akan melewati min dan max x nya
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);


        _rigidbody2D.position = pos;                                        // ga bakal lewat minimum dan maksimumnya

        if (moveX < 0)
        {
            _animator.SetBool("turnLeft", true);
        }
        else if (moveX == 0)
        {
            _animator.SetBool("turnLeft", false);
            _animator.SetBool("turnRight", false);
        }
        else
        {
            _animator.SetBool("turnRight", true);

        }



        if (moveY < 0)
        {
            _animator.SetBool("turnDown", true);
        }
        else if (moveY == 0)
        {
            _animator.SetBool("turnDown", false);
            _animator.SetBool("turnUp", false);
        }
        else
        {
            _animator.SetBool("turnUp", true);

        }

    }

}
