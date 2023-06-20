using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public int id;
    public string cardName;
    public int cardType;
    public Card(int _id, string name, int type)
    {
        this.id = _id;
        this.cardName = name;
        this.cardType = type;
    }
}

public class PlayerCard : Card
{
    public int attack;
    public PlayerCard(int _id, string name, int type, int attack) : base(_id, name, type)
    {
        this.attack = attack;
    }
}


public class EnermyCard : Card
{
    public int attack;
    public int healthPoint;
    public int healthPointMax;


    public EnermyCard(int _id, string name, int type, int attack, int healthPoint, int healthPointMax) : base(_id, name, type)
    {
        this.attack = attack;
        this.healthPoint = healthPoint;
        this.healthPointMax = healthPointMax;
    }
}
