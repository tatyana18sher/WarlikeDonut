using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Monster : Unit
{
    [SerializeField]
    private float speed = 2.0F;

    private Vector3 direction;
    
    private Bullet bullet;
    //const float speedMove = 30.0f;

    private SpriteRenderer sprite;

    public int DestroyBullet = 1;//через какое врямя будет удалена со сцены

 //дистанция от которой он начинает видеть игрока
                
                //скорость енеми
                //public float speed = 2;
                
                //private Transform target;
                // Rigidbody2D rb;

                // void Start()
                // {
                //         target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
                //         rb = GetComponent<Rigidbody2D>();
                // }

               protected void Start()
               {
                   direction = transform.right;
                   
               }
               protected void Update()
                {
                    Move();
                    // var move = new Vector2(rb.position.x, rb.position.y);
                    // var targetMove = new Vector2(target.position.x, target.position.y);
                    // move = Vector2.MoveTowards(move, targetMove, speed * Time.deltaTime);
                    // //rb.velocity = move;
                    // var dir = (target.position - transform.position).normalized;
                    //  rb.velocity = dir * speed;
                }
        
 

 
    //  public Monster monster;


    // public void MonsterHurt()
    // {
    //     //Destroy(this.gameObject);
    //      ReceiveDamage();
    // }
    //  //дистанция от которой он начинает видеть игрока
    // public float seeDistance = 2f;
    // //дистанция до атаки
    // public float attackDistance = 2f;
    // //скорость енеми
    // public float speed = 6;
    // //игрок
    // public Transform target;

    // void Start()
    // {
    //     target = GameObject.FindWithTag("Player").transform;
    // }

    // void Update()
    // {
    //     if (Vector3.Distance(transform.position, target.transform.position) < seeDistance)
    //     {
    //         if (Vector3.Distance(transform.position, target.transform.position) > attackDistance)
    //         {
    //             //walk
    //             transform.right = target.transform.position - transform.position;
    //            //transform.LookAt(target.transform);
    //             transform.Translate(new Vector3 (0, 0, speed * Time.deltaTime));
    //         }
    //     }
    //     else {
    //         //idle
    //     }
    // }

//    void Start ()
//     {
//        Destroy (gameObject, DestroyBullet);//таймер для удаления
//     }
    // private GameObject parent;  //Хозяин пули
    // public GameObject Parent 
    // { 
    //     set { parent = value; }
    //    get { return parent; }
    //  }

     protected  void Awake()
     {
         sprite = GetComponentInChildren<SpriteRenderer>();
         Resources.Load<Bullet>("Bullet");
     }

    //  protected  void Start()
    //  {
    //      direction = transform.right;
        
    //  }

    // protected  void Update()
    // {
    //     Move();

    //     // float direction = player.transform.position.x - transform.position.x;
 
    //     // if (Mathf.Abs(direction) < 20)
    //     // {
    //     //     Vector3 pos = transform.position;
    //     //     pos.x += Mathf.Sign(direction) * speedMove * Time.deltaTime;
    //     //     transform.position = pos;
    //     // }
    // }

     protected  void OnTriggerEnter2D(Collider2D collider)
     {
         Bullet bullet = collider.GetComponent<Bullet>();

         if (bullet)
         {
             ReceiveDamage(); // монстра можно убить, стрельнув в него     
             Score.scoreAmount += 10;
         }


        //   Unit unit = collider.GetComponent<Unit>();

        //   if (unit && unit is donut1)
        //   {
        //       if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.3F) ReceiveDamage();
        //       else unit.ReceiveDamage();
        //   }


        //   if (unit && unit is donut1)
        //   {
        //       ReceiveDamage(); // монстра можно убить просто, прыгнув на него
        //   }

        
    //    if (bullet != Character) //Если игровой объект не является родителем(хозяином)
    //    {
    //       Destroy (bullet);
    //    }
        
     }

     private void Move()
     {
         Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5F + transform.right, 0.6F);

        if (colliders.Length > 0) direction *= -1.0F;
         //direction = transform.right;
         transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    
     }


      
    //     if(donut1.transform.position.x > transform.position.x + 1f)
    //     {
    //         Monster = true;
    //         run = 3f;
    //         Flip();
    //     }
    //     else if(donut1.transform.positionx.x < transform.position.x - 1f)
    //     {
    //         Monster = false;
    //         Flip();
    //         run = -3f;
    //     }
    //     else{
    //         run = 0f;
    //     }
    //  }

   
}
