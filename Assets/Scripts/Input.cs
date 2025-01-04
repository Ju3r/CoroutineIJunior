using System;
using UnityEngine;

public class Input : MonoBehaviour
{
    public event Action ButtonClicked;

    public void CLick()
    {
        ButtonClicked.Invoke();
    }
}