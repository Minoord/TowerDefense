using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{
    public int towerHealthPoints;
    public BasicEnemy EnemyAttack;
    public Text printLives;

    private void Start()
    {
        printLives = GameObject.Find("LivesCount").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        printLives.text = "Lives:" + towerHealthPoints;
        if (towerHealthPoints <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyAttack = collision.gameObject.GetComponent<BasicEnemy>();
            towerHealthPoints -= EnemyAttack.basicAttack;
            EnemyAttack.enemyHealthPoints = 0;
        }
    }
}
