using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Main mainScript;
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject PlayerShadow;
    [SerializeField] private Rigidbody2D PlayerRB;
    [SerializeField] float JumpSpeed;
    [SerializeField] float FlySpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRB.velocity = new Vector2(FlySpeed, PlayerRB.velocity.y);

        if (Input.GetButton("Jump") || Input.GetButton("Fire1"))
        {
            PlayerRB.AddForce(Vector2.up* JumpSpeed);
        }
    }

    void FixedUpdate()
    {
        
        GameObject CurrentShadow = Instantiate(PlayerShadow, transform.position, transform.rotation);
        Destroy(CurrentShadow, 2);
        Transform TempPlayer = transform;
        Camera.transform.position = new Vector3(TempPlayer.position.x + 4.31f, Camera.transform.position.y, Camera.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            mainScript.ScoreSum();
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "DeathZone")
        {
            mainScript.Death();
        }
    }
}
