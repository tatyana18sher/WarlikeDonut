using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class donut1 : Unit
{
     [SerializeField]
     private int lives = 5; //количество жизней игрока

     public int Lives
     {
       get { return lives; }
       set
       { 
         if (value < 5) lives = value;
         livesBar.Refresh();
       }
     }
     private LivesBar livesBar;

    [SerializeField]
    private float speed = 1; //скорость игрока
     [SerializeField]
     private float jumpForce = 10.0F; //сила прыжка
    [SerializeField]
    public Bullet  bullet;
    private BulletFlower bulletflower;
    public bool isGrounded = false;

    public GameObject WinText;
    private bool gameOver;



    new private Rigidbody2D rb;
    //private Animator animator;
      private SpriteRenderer sprite;

 


      private void Awake()
      {
        
        
        livesBar = FindObjectOfType<LivesBar>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        Resources.Load<Bullet>("Bullet"); // подгружаем ссылку на объект

        Resources.Load<BulletFlower>("BulletFlower");

      //  player.position=Camera.main.ViewportToWorldPoint(new Vector3(offsetx,offsety,distanceFromCamera)); // для того, чтобы не выходил за границы экрана
      }

      private void FixedUpdate()
      {
         CheckGround();
         rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 12f, rb.velocity.y);
      }

     private void Start()
     {
        rb = GetComponent<Rigidbody2D>();

        WinText.SetActive(false);
        Time.timeScale = 1;
        gameOver = false;
     }

     private void Update()
     {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ShootBullet();
        } 
    
			 

        if (Input.GetButton("Horizontal")) Run();
        //if (jump == 0)
       // {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space) )
        {
            Jumping(); // метод прыжка
           // jump = 1;
        }
       // }


       if (Input.anyKeyDown && gameOver == true)
        {
            Time.timeScale = 1;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Application.LoadLevel(Application.loadedLevel);
            gameOver = false;
            
        }
     }

     private void ShootBullet()
     {
        Vector3 position = transform.position; // создаём пулю от текущей позиции игрока
        position.y += -1.7F;
                                               //Instantiate(bullet, position, bullet.transform.rotation);
       // Bullet newBullet = Instantiate(bullet, transform.position, bullet.transform.rotation) as Bullet; // используем метод Instantiate, чтобы создать нашу пулю в сцене
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
        // newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
    }

    public void ReceiveDamage()
    {
      Lives--;

      rb.velocity = Vector3.zero;
      rb.AddForce(transform.up * 8.0F, ForceMode2D.Impulse);

      Debug.Log(lives);
    }



     private void Run()
     {
          Vector3 direction = transform.right * Input.GetAxis("Horizontal");

          transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

          sprite.flipX = direction.x < 0.0F; 
     }

     private void Jumping()
     {
         rb.AddForce(transform.up * 14f, ForceMode2D.Impulse);
        // jump = true;
     }

     
     private void CheckGround()
     {
          Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 4F);

         isGrounded = colliders.Length > 1;
        // jump = false;

        // jump = 0;
     }

     

     private void OnTriggerEnter2D(Collider2D collider)
     {

      // BulletFlower bulletflower = collider.GetComponent<BulletFlower>();
        
       if (collider.CompareTag ("Monster"))
         {
           Lives--;
         }
        if (collider.CompareTag ("BulletFlower"))
        {
           
          Lives--;
          
        }

        if (collider.CompareTag ("TheEnd"))
        {
          WinText.SetActive(true);
          Time.timeScale = 0;
          gameOver = true;
          // Application.LoadLevel(Application.loadedLevel);
        }


        // if (collider.CompareTag ("Block_ground"))
        // {
        //    jump = false;
          
        // }

         

        // if (bulletflower)
        //  {
        //      //ReceiveDamage(); // монстра можно убить, стрельнув в него     
        //    // Score.scoreAmount += 10;
        //     // ReceiveDamage(); // монстра можно убить, стрельнув в него     
        //     Lives--;
        // }

         
        //Monster monster = collider.gameObject.GetComponent<Monster>();
        // if (monster)
        //  {
        //    //Debug.Log(monster);
        //    ReceiveDamage();
        // }

        // Bullet bullet = collider.gameObject.GetComponent<Bullet>();
        // if (bullet && bullet.Parent != gameObject)
        // {
        //     ReceiveDamage();
        // }

          //BulletFlower bulletflower = collider.gameObject.GetComponent<BulletFlower>();
        // if (bulletflower && bulletflower.Parent != gameObject)
        // {
        //     //ReceiveDamage();
        //     Lives--;
        // }
        if (Lives <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }


    
    
    
}
      


 


