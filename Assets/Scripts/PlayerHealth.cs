using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;
    public PlayerMovement playerMove;
    [SerializeField] private Text _text;
    public SpawnScript spawn;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damageAmount)
    {

        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            GameOver();
            //OnEnemyKilled?.Invoke(this);
        }
    }
    public void GameOver()
    {
        playerMove.OnDisable();
        playerMove.canMove = false;
        spawn.OnDisable();
        _text.text = "You Lose";
    }
}
