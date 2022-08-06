using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController gameController;
    private int coins;
    public Text coinsText;
    public GameObject imageChest;
    void Awake()
    {
        if (gameController == null)
        {
            gameController = this;
        }
        ShowImageChest(false);

    }

    public void SetCoins(int c)
    {
        coins += c;
        UpdateHuD();
        
    }
        public void TextUpdate (int value)
    {
        coinsText.text = value.ToString();
    }

    public int GetCoins()
    {
        return coins;
    }

    void UpdateHuD()
    {
        coinsText.text = GetCoins().ToString();
    }

    public void ShowImageChest(bool show)
    {
        imageChest.SetActive(show);
    }



}
