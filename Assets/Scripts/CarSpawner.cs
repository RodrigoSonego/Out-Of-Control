using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float spawnRate;
    [Range(0, 10)]
    public float carSpeed;
    public List<GameObject> cars;

    private float timer;

    private void FixedUpdate()
    {
        spawnRate = Random.Range(1f, 4);
        timer += Time.fixedDeltaTime;
        if(timer >= spawnRate)
        {
            SpawnCar();
            timer = 0f;
        }

    }

    void SpawnCar()
    {
        int index = Random.Range(0, 3);
        GameObject car = Instantiate(cars[index], transform.position, transform.rotation);
        car.GetComponent<Rigidbody2D>().velocity = transform.right * carSpeed;
        Destroy(car, 5f);
    }

}
