using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Sprite[] bar;
    public Image healthBarUI;
    public Player player;
    void Start()
    {
        
    }

    void Update()
    {
        healthBarUI.sprite = bar [player.vida];
    }
}
