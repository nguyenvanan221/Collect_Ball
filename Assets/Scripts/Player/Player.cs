using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeColor
{
    Green,
    Red,
    Blue
}

public class Player : MonoBehaviour
{
    //public Color playerColor { get; private set; }
    public TypeColor playerColor;
    public static List<Color> colors = new();
    Renderer playerRenderer;

    private void Awake()
    {
        playerRenderer = GetComponent<Renderer>();
        colors.Add(Color.green);
        colors.Add(Color.red);
        colors.Add(Color.blue);

        RandomColorPlayer();
    }

    public void RandomColorPlayer()
    {
        playerColor = (TypeColor)Random.Range(0, System.Enum.GetValues(typeof(TypeColor)).Length);
        playerRenderer.material.color = colors[(int)playerColor];
    }
}