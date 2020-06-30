using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMonsters : Unit
{
     [SerializeField]
    private float speed = 0.01F;

    private Vector3 direction;
    
    private Bullet bullet;
    //const float speedMove = 30.0f;

    private SpriteRenderer sprite;

    public int DestroyBullet = 1;//через какое врямя будет удалена со сцены

 

               protected void Start()
               {
                   direction = transform.right;
                   
               }
               protected void Update()
                {
                    Move();
                   
                }
        
 

 


     protected  void Awake()
     {
         sprite = GetComponentInChildren<SpriteRenderer>();
         Resources.Load<Bullet>("Bullet");
     }

 

     protected  void OnTriggerEnter2D(Collider2D collider)
     {
         Bullet bullet = collider.GetComponent<Bullet>();

         if (bullet)
         {
             ReceiveDamage(); // монстра можно убить, стрельнув в него     
             Score.scoreAmount += 10;
         }


    
        
     }

     private void Move()
     {
         Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right, 0.6F);

        if (colliders.Length > 0) direction *= -1.0F;
         //direction = transform.right;
         transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    
     }


      
    
}
