using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private Rigidbody2D rb2d;

    private float horzontalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horzontalInput = Input.GetAxis("Horizontal");

    }

    private void FixedUpdate()
    {
        rb2d.AddForce(Vector2.right * horzontalInput * speed);

    }
}
