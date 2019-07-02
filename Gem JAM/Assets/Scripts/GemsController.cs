using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsController : MonoBehaviour
{
    private Rigidbody slowfall;
    private void Start()
    {
        transform.Rotate(180f,0f,90f,0f);
        slowfall = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        slowfall.AddForce(new Vector3(0, 9, 0));
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 1);
    }
}
