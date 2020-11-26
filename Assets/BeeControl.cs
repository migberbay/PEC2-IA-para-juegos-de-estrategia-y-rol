using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeControl : MonoBehaviour
{
    public FlockManager myManager;
    public Vector3 direction;
    public float speed;

    void FixedUpdate()
    {
        Vector3 cohesion = Vector3.zero;
        Vector3 align = Vector3.zero;
        Vector3 separation = Vector3.zero;

        Vector3 randomization = new Vector3(Random.Range(-45, 45), Random.Range(-45, 45), Random.Range(-45, 45));

        int num = 0;
        foreach (GameObject b in myManager.allBees)
        {
            if(b != this.gameObject)// we dont count ourselves in this calculations.
            {
                float distance = Vector3.Distance(b.transform.position, transform.position); // distance to the other bees

                // we add the positions of all bees and the number of them that are too close.
                if (distance <= myManager.neighborDist) {
                    align += b.GetComponent<BeeControl>().direction;
                    separation -= (transform.position - b.transform.position) / (distance * distance);
                    cohesion += b.transform.position;
                    num++;
                }

                direction = (cohesion + align + separation + randomization).normalized * speed;
            }
        }

        if (num > 0) {
            align /= num;
            speed = Mathf.Clamp(align.magnitude, myManager.minSpeed, myManager.maxSpeed);
            cohesion = (cohesion / num - transform.position).normalized * speed;
        }

    }

    private void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
                             Quaternion.LookRotation(direction),
                             myManager.rotationSpeed * Time.deltaTime);

        transform.Translate(0.0f, 0.0f, Time.deltaTime * speed);
    }
}
