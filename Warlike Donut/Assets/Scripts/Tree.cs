using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField]
     private float rate = 2.0F;
     [SerializeField]
     private Color bulletflowerColor = Color.white;

    public BulletFlower bulletflower;
    private SpriteRenderer sprite;
    
    protected void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        Resources.Load<BulletFlower>("BulletFlower");
    }
     protected void Start()
    {
        InvokeRepeating("ShootBullet", rate, rate);
    }

     private void ShootBullet()
     {
         Vector3 position = transform.position; // создаём пулю от текущей позиции игрока
         position.y += -1.5F;
         position.x += 93.9F;
          BulletFlower newBulletFlower = Instantiate(bulletflower, position, bulletflower.transform.rotation) as BulletFlower;

         newBulletFlower.Parent = gameObject;
         newBulletFlower.Direction = -newBulletFlower.transform.right;
         newBulletFlower.Color = bulletflowerColor;
     }
    
    protected void OnTriggerEnter2D(Collider2D collider)
    {
        
        // Unit unit = collider.GetComponent<Unit>();

        //   if (unit && unit is donut1)
        //   {
        //       if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.3F) ReceiveDamage();
        //       else unit.ReceiveDamage();
        //   }

        //   Bullet bullet = collider.GetComponent<Bullet>();

        //  if (bullet)
        //  {
        //      ReceiveDamage(); // монстра можно убить, стрельнув в него     
        //  }

          if (collider.CompareTag ("Player"))
         {
             Score.scoreAmount += 50;
             Destroy (gameObject);
             //donut1.Lives++;
         }

    }

}
