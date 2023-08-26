using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : MonoBehaviour
{
    private float StartY;
    // Start is called before the first frame update
    void Start()
    {
        StartY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = new Vector2(transform.position.x, StartY - 1.7f);
        transform.position = Vector2.MoveTowards(transform.position, target, 1 * Time.deltaTime);
    }
}
