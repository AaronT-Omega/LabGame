using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //public static event Action<Enemy> OnEnemyKilled;
    [SerializeField] float health, maxHealth = 3f;
    // Start is called before the first frame update



    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    public PlayerHealth playerHealth;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        health = maxHealth;
        target = GameObject.Find("Player").transform;
        

    }


    public void Update()
    {
        if(target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }
    }

    public void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }
   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(1);
        }    
    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
            //OnEnemyKilled?.Invoke(this);
        }
    }

}
