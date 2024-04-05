
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private int ballSize;
    public Transform spawnArea;

    private TypeColor currentColor;

    private int count = 0;

    private void Awake()
    {
        for (int i=0; i<ballSize; i++)
        {
            count++;
            GameObject ballObj = InitBall();

            if (count >= Player.colors.Count)
            {
                count = 0;
            }

            ballObj.GetComponent<Renderer>().material.color = Player.colors[count];
            
            switch (count)
            {
                case 0:
                    currentColor = TypeColor.Green;
                    break;
                case 1:
                    currentColor = TypeColor.Red;
                    break;
                case 2:
                    currentColor = TypeColor.Blue;
                    break;
            }
            ballObj.GetComponent<Ball>().ballColor = currentColor;
        }
    }

    public GameObject InitBall()
    {
        GameObject ballObj = Instantiate(ball, randomPosition(), Quaternion.identity);
        
        return ballObj;
    }


    Vector3 randomPosition()
    {
        Vector3 randomPos = new Vector3(
            Random.Range(spawnArea.position.x - spawnArea.localScale.x, spawnArea.position.x + spawnArea.localScale.x),
            0f,
            Random.Range(spawnArea.position.z - spawnArea.localScale.z, spawnArea.position.z + spawnArea.localScale.z)
        );
        return randomPos;
    }
}
