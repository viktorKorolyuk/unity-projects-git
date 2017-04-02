using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player"); //grab the player
        playerHealth = player.GetComponent <PlayerHealth> (); //grab the players gameobject
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> (); //reference the animator
    }


    void OnTriggerEnter (Collider other) //when a collision occurs
    {
        if(other.gameObject == player)
        {
            playerInRange = true; //hit the player
        }
    }


    void OnTriggerExit (Collider other) //when exiting the collision
    {
        if(other.gameObject == player)
        {
            playerInRange = false;// stop hitting the player
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack ();
        }

        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead"); //go idle
        }
    }


    void Attack ()
    {
        timer = 0f; //reset timer

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }
    }
}
