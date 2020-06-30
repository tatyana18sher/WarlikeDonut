using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coffee : Unit
{
      
     void OnTriggerEnter2D (Collider2D collider)
     {
         //donut1 donut1 = collider.GetComponent<donut1>();
         // проверяем было ли столкновение с пончиком
         if (collider.CompareTag ("Player"))
        // if (donut1)
         {
             Score.scoreAmount += 30;   
             //donut1.Lives++;   
             Destroy (gameObject);
         }
    }
         
}
