using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardColission : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Transform player = collision.gameObject.transform;
            player.position += Vector3.up * 10.0f;
        }
    }

}
