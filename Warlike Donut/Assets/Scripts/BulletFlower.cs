using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlower : MonoBehaviour
{
   private GameObject parent;
    public GameObject Parent { set {parent = value; } get { return parent;} }
    private float speed = 10.0F; // скорость пули
    private Vector3 direction; // направление пули

    public donut1 donut1;

    public Color Color
    {
        set { sprite.color = value;}
    }


    private SpriteRenderer sprite;

    public Vector3 Direction // создаём свойство, чтобы дать доступ полю направления пули
    {
        set { direction = value; }
    }

      protected  void OnTriggerEnter2D(Collider2D collider)
     {
         

        if (collider.CompareTag ("Player"))
        // if (donut1)
         {
            // Score.scoreAmount += 30;   
             //donut1.Lives++;   
             Destroy (gameObject);
         }
    //      Unit unit = collider.GetComponent<Unit>();

    //    if (unit && unit.gameObject != parent)
    //    {
    //        Destroy(gameObject);
    //    }
     }

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {      
        Destroy(gameObject, 1F);       
    }

   
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime); // метод для движения
    }

    //Уничтожить пулю, если она вылетела за экран (out of screen)
    void OnBecameInvisible ()
    {
       Destroy (gameObject);
    }
}
