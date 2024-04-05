using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    public TypeColor ballColor;
    public SpawnBall spawn;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.CompareTag("Player"))
        {
            Player player = collision.transform.GetComponent<Player>();
            if (player.playerColor == ballColor)
            {
                GameManager.instance.IncreScore(1);

                player.RandomColorPlayer();
                GameObject ball = spawn.InitBall();
                ball.GetComponent<Renderer>().material.color = Player.colors[(int)ballColor];
                ball.GetComponent<Ball>().ballColor = ballColor;
            }
            else UIManager.instance.ResultGame("YOU LOSE");

            Destroy(gameObject);
        }
    }
}
