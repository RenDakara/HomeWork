using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    [SerializeField] private float speed = 3f; // скорость движения 
    [SerializeField] private int lives = 5; // количество жизней 
    [SerializeField] private float jump force = 15f; // сила прыжка   


    private Rigidbody2D rb;
    private SpriteRenderer sprite; 
    }
private void Awake()
  {
    rb = Getcomponent<Rigidbody2D>();
    sprite = GetComponentInChildren<SpriteRenderer>();

  }
  private void Update()
  {
    if (Input.GetButton("Horizontal"))
    Run();
  private void Run()
  }

    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime)
    // Update is called once per frame
    void Update()
    
        
    }
}


  