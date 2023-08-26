using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float Speed;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position)<4)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime/ Vector2.Distance(transform.position, target.position));
        }
        
    }
}
