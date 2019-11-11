using System.Collections;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{

    private Rigidbody rb;

    public float tumble;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}