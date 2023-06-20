using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public Text textCardName;
    public Text textCardType;
    public Text textCardHealthPoint;
    public Text textCardAttack;
    public Image backgroundImg;
    // Start is called before the first frame update
    void Start()
    {
        ShowCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCard()
    {
        textCardName.text = card.cardName.ToString();
        if(card is EnermyCard)
        {
            var enermy = card as EnermyCard;
            textCardHealthPoint.text = enermy.healthPoint.ToString();
            textCardAttack.text = enermy.attack.ToString();

            textCardHealthPoint.gameObject.SetActive(false);
        }
    }
}
