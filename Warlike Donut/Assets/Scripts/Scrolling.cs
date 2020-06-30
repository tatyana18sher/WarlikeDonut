using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour

{
    public float backgroundSize; // размер нашего бэкграунда
    public float paralaxSpeed;

    private Transform cameraTransform;
    private Transform [] layers; // массив картинок, что используется
    private float viewZone = 23; // область видимости
    private int leftIndex; // когдат мы будем сдвигаться максимум влево
    private int rightIndex; // когдат мы будем сдвигаться максимум вправо

    private float lastCameraX;

    

    private void Start()
    {
        cameraTransform = Camera.main.transform; //равно положению нашей текущей камеры
        lastCameraX = cameraTransform.position.x; // будет считывать всё относительно нашей камеры


        layers = new Transform[transform.childCount]; // кол подчинённых элементов
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }

    private void Update()
    {
         float deltaX = cameraTransform.position.x - lastCameraX;
        transform.position += Vector3.right * (deltaX * paralaxSpeed);
        lastCameraX = cameraTransform.position.x;

        // if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone)) // если положение камеры выходит за границы картинки , то срабатывает прокрутка
        // {
        //     ScrollLeft();
        // }

        // if (cameraTransform.position.x > (layers[rightIndex].transform.position.x + viewZone)) // если положение камеры выходит за границы картинки , то срабатывает прокрутка
        // {
        //     ScrollRight();
        // }
       

       if (Input.GetKeyDown(KeyCode.A))
       {
           ScrollLeft();

       }
       if (Input.GetKeyDown(KeyCode.D))
       {
           ScrollRight();

       }
    }


    private void ScrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize); // левые картинки перепрыгивают на правую сторону каждый раз
        //когда правый индекс будет считываться левая картинка будет забираться и перепрыгивать на правую сторону
        leftIndex = rightIndex;
        rightIndex--;

        if(rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }

    }

    private void ScrollRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize); // левые картинки перепрыгивают на правую сторону каждый раз
        //когда правый индекс будет считываться левая картинка будет забираться и перепрыгивать на правую сторону
        rightIndex = leftIndex;
        leftIndex++;

        if(leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }

    
    
}
