using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public GameObject[] allBees;

    public int numBees;
    public GameObject beePrefab;

    public float neighborDist;
    public float minSpeed;
    public float maxSpeed;
    public float rotationSpeed;

    public GameObject flightArea;
    public Bounds bounds;

    private void Start()
    {
        bounds = flightArea.GetComponent<MeshRenderer>().bounds;

        allBees = new GameObject[numBees];
        for (int i = 0; i < numBees; i++) {
            Vector3 pos = transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f));
            Vector3 randomize = new Vector3(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f));
            allBees[i] = (GameObject)Instantiate(beePrefab, pos, Quaternion.LookRotation(randomize));
            allBees[i].GetComponent<BeeControl>().myManager = this;
        }
    }
}
