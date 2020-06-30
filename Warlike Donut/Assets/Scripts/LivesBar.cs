using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesBar : MonoBehaviour
{
   private Transform[] hearts = new Transform[5];

   private donut1 donut1;


   private void Awake()
   {
       donut1 = FindObjectOfType<donut1>();

       for (int i = 0; i < hearts.Length; i++)
       {
           hearts[i] = transform.GetChild(i);
           Debug.Log(hearts[i]);

       }
   }

    public void Refresh() // активирует нужное количество сердечек
    {
       for (int i = 0; i < hearts.Length; i++)
       {
           if (i < donut1.Lives) hearts[i].gameObject.SetActive(true);
           else hearts[i].gameObject.SetActive(false);

       }


    }



   
}
