using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnScript : MonoBehaviour
{

    public GameObject[] myObjects;
    float timer;
    float timeLeft;
    float timeText;
    public int dropRate = 300;
    public int winScore = 30;
    private bool gameOver = false;
    [SerializeField] private Text _text;
    [SerializeField] private Text _timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnEnable()
    {
        gameOver = true;
    }

    public void OnDisable()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1;
        _timer.text = (Mathf.FloorToInt(timer / 300)).ToString();
        if ((timer % dropRate) == 0 && gameOver == true)
        {
           
            int randomIndex = Random.Range(0, myObjects.Length);
            Vector2 randomSpawn = new Vector2(Random.Range(-7, 7), Random.Range(-4, 4));

            GameObject clone = Instantiate(myObjects[randomIndex], randomSpawn, Quaternion.identity);
            clone.SetActive(true);

        }
        
        if (Mathf.FloorToInt(timer / 300) >= winScore)
        {
            OnDisable();
            _text.text = "You Win";
        }
        




    }

    
}
