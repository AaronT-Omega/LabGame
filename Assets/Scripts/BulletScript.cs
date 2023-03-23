using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public Rigidbody2D rb;

    public void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Enemy":

                other.GetComponent<Enemy>().TakeDamage(1);
                Destroy(gameObject);
                break ;
        }
    }
}
