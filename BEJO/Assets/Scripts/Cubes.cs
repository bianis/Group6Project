using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{

    public float speed;
    public int health;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    public GameObject explosion;
    public GameObject miniexplosion;

    //public Transform[] moveSpots; step1
    public Transform moveSpots;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private float waitTime;
    public float startWaitTime;

    public string cubeTag;

    //private Questions ans = gameObject.GetComponent<Questions>();
    //private string ansTag = ans.answerTag;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        moveSpots.position = new Vector2(Random.Range(minX,maxX), Random.Range(minY, maxY));

        _rigidbody2D = GetComponent<Rigidbody2D>();         // biar konsisten
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots.position, speed * Time.deltaTime);


        if (Vector2.Distance(transform.position, moveSpots.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        //Debug.Log("HEALTH:" + health);

        if (health == 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        Instantiate(miniexplosion, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage TAKEN" + health);
        cubeTag = gameObject.tag; //tag cube yg di-slash
        Debug.Log(cubeTag);

        //kalo tagnya sama jawabannya bener
        if (gameObject.CompareTag(ansTag)) //compare sama tag di answer
        {
            Debug.Log("correct answer");
        } else
        {
            Debug.Log("Wrong answer");
        }
    }

}
