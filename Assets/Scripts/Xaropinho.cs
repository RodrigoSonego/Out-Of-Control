using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xaropinho : MonoBehaviour
{
    public GameObject cheese;
    public Transform cheeseSpawn;
    [Range(0,8)]
    public float detectionRadius;

    [Range(0, 5)]
    public float throwCooldown;

    public float cheeseForce;

    private float timer;
    private Transform player;
    private Vector2 targetPos;
    private float shootAngle;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        throwCooldown = Random.Range(1.5f, 2.5f);
        CheckDistanceToPlayer();
    }

    private IEnumerator throwCheeseCoroutine()
    {
        yield return new WaitForSeconds(1.2f);
        ThrowCheese();
    }

    void ThrowCheese()
    {
        targetPos = player.position - cheeseSpawn.position;
        shootAngle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        cheeseSpawn.rotation = Quaternion.Euler(0f, 0f, shootAngle);

        if (!HasObstacles())
        {
            GameObject cheese = Instantiate(this.cheese, cheeseSpawn.position, cheeseSpawn.rotation);
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), cheese.GetComponent<Collider2D>());
            cheese.GetComponent<Rigidbody2D>().velocity = cheeseSpawn.right * cheeseForce;
            Destroy(cheese, 2f);
            timer = 0f;
        } else
        {
            print("parede encontrada");
        }

        
    }


    void CheckDistanceToPlayer()
    {
        timer += Time.fixedDeltaTime;

        if(Vector2.Distance(player.position, transform.position) <= detectionRadius)
        {
            //print("detectado");

            if(timer >= throwCooldown)
            {
                ThrowCheese();
                print("yeet");
            }
        }
    }

    bool HasObstacles()
    {
        RaycastHit2D hit = Physics2D.Raycast(cheeseSpawn.position, cheeseSpawn.right, detectionRadius);
        print(hit.collider.tag);
        return hit.collider.tag == "Obstacle";
    }

}
