using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyGrimorium : MonoBehaviour
{
    public Text creatureNameText, priceText;
    public string creatureName;
    public int price;
    public Button Purchase;

    //Grimorium
    public bool Bigfoot, Chessie, Chupacabra, Jackalope, JerseyDevil, LovelandFrog, Menehune, Mothman, Passagoula, SalemWitches, Squonk, TakuHe, VanMeterMonster, Wendigo;

    // Start is called before the first frame update
    void Start()
    {
        creatureNameText.text = creatureName.ToString();
        priceText.text = price.ToString();
    }

    private void Update()
    {
        if (Bigfoot)
        {
            if (GameManager.Bigfoot)
            {
                Purchase.interactable = false;
            }
        }

        if (Chessie)
        {
            if (GameManager.Chessie)
            {
                Purchase.interactable = false;
            }
        }

        if (Chupacabra)
        {
            if (GameManager.Chupacabra)
            {
                Purchase.interactable = false;
            }
        }

        if (Jackalope)
        {
            if (GameManager.Jackalope)
            {
                Purchase.interactable = false;
            }
        }

        if (JerseyDevil)
        {
            if (GameManager.JerseyDevil)
            {
                Purchase.interactable = false;
            }
        }

        if (LovelandFrog)
        {
            if (GameManager.LovelandFrog)
            {
                Purchase.interactable = false;
            }
        }

        if (Menehune)
        {
            if (GameManager.Menehune)
            {
                Purchase.interactable = false;
            }
        }

        if (Mothman)
        {
            if (GameManager.Mothman)
            {
                Purchase.interactable = false;
            }
        }

        if (Passagoula)
        {
            if (GameManager.Passagoula)
            {
                Purchase.interactable = false;
            }
        }

        if (SalemWitches)
        {
            if (GameManager.SalemWitches)
            {
                Purchase.interactable = false;
            }
        }

        if (Squonk)
        {
            if (GameManager.Squonk)
            {
                Purchase.interactable = false;
            }
        }

        if (TakuHe)
        {
            if (GameManager.TakuHe)
            {
                Purchase.interactable = false;
            }
        }

        if (VanMeterMonster)
        {
            if (GameManager.VanMeterMonster)
            {
                Purchase.interactable = false;
            }
        }

        if (Wendigo)
        {
            if (GameManager.Wendigo)
            {
                Purchase.interactable = false;
            }
        }
    }

    public void BigfootBuy()
    {
        if (!GameManager.Bigfoot)
        {
            if (GameManager.Money >= price)
            {
                GameManager.Money -= price;
                GameManager.Bigfoot = true;
            }
        }
    }

    public void ChessieBuy()
    {
        if (!GameManager.Chessie)
        {
            if (GameManager.Money >= price)
            {
                GameManager.Money -= price;
                GameManager.Chessie = true;
            }
        }
    }

    public void ChupacabraBuy()
    {
        if (!GameManager.Chupacabra)
        {
            if (GameManager.Money >= price)
            {
                GameManager.Money -= price;
                GameManager.Chupacabra = true;
            }
        }
    }

    public void JackalopeBuy()
    {
        if (!GameManager.Jackalope)
        {
            if (GameManager.Money >= price)
            {
                GameManager.Money -= price;
                GameManager.Jackalope = true;
            }
        }
    }

    public void JerseyDevilBuy()
    {
        if (!GameManager.JerseyDevil)
        {
            if (GameManager.Money >= price)
            {
                GameManager.Money -= price;
                GameManager.JerseyDevil = true;
            }
        }
    }

    public void LovelandFrogBuy()
    {
        if (!GameManager.LovelandFrog)
        {
            if (GameManager.Money >= price)
            {
                GameManager.Money -= price;
                GameManager.LovelandFrog = true;
            }
        }
    }

    public void MenehuneBuy()
    {
        if (!GameManager.Menehune)
        {
            if (GameManager.Money >= price)
            {
                GameManager.Money -= price;
                GameManager.Menehune = true;
            }
        }
    }

    public void MothmanBuy()
    {
        if (!GameManager.Mothman)
        {
            if (GameManager.Money >= price)
            {
                GameManager.Money -= price;
                GameManager.Mothman = true;
            }
        }
    }

    public void PassagoulaBuy()
    {
        if (!GameManager.Passagoula)
        {
            if (GameManager.Money >= price)
            {
                GameManager.Money -= price;
                GameManager.Passagoula = true;
            }
        }
    }

    public void SalemWitchesBuy()
    {
        if (!GameManager.SalemWitches)
        {
            if (GameManager.Money >= price)
            {
                GameManager.Money -= price;
                GameManager.SalemWitches = true;
            }
        }
    }

    public void SquonkBuy()
    {
        if (!GameManager.Squonk)
        {
            if (GameManager.Money >= price)
            {
                GameManager.Money -= price;
                GameManager.Squonk = true;
            }
        }
    }

    public void TakuHeBuy()
    {
        if (!GameManager.TakuHe)
        {
            if (GameManager.Money >= price)
            {
                GameManager.Money -= price;
                GameManager.TakuHe = true;
            }
        }
    }

    public void VanMeterBuy()
    {
        if (!GameManager.VanMeterMonster)
        {
            if (GameManager.Money >= price)
            {
                GameManager.Money -= price;
                GameManager.VanMeterMonster = true;
            }
        }
    }

    public void WendigoBuy()
    {
        if (!GameManager.Wendigo)
        {
            if (GameManager.Money >= price)
            {
                GameManager.Money -= price;
                GameManager.Wendigo = true;
            }
        }
    }
}
