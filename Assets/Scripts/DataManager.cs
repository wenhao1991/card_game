using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    public TextAsset globalData;
    public Dictionary<string, Card> global_data;
    
    public TextAsset cardData;
    // public List<Card> cardList = new List<Card>();
    public Dictionary<int, Card> cards = new Dictionary<int, Card>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // load没有编号的全局表的通用函数
    // 全局表，没有id，只获取第一列和第二列的映射，第三列是描述
    public void CommonLoadGlobalData(TextAsset textAsset, Dictionary<object, object> data)
    {
        string[] dataRow = textAsset.text.Split('\n');
        foreach(var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            data.Add(rowArray[0], rowArray[1]);
        }
    }

    // load有编号的普通表的通用函数
    // 普通表，第一行为中文表头，第二行为英文表头（即实际表头）
    // 第一列为key，映射一个list
    public void CommonLoadNormalData(TextAsset textAsset, Dictionary<object, object> data)
    {
        string[] dataRow = textAsset.text.Split('\n');
        int index = 0;
        foreach (var row in dataRow)    // 遍历每一行
        {
            string[] rowArray = row.Split(',');
            if (index <= 1)             // 忽略前两行
            {
                continue;
            }
            // 每一行的第一个元素作为data的key， 表头和每个元素的映射，作为data的value
            Dictionary<object, object> value = new Dictionary<object, object>();
            int value_index = 0;
            foreach(var vRow in rowArray)   // 遍历一行中的所有元素
            {
                value.Add(dataRow[1][value_index], vRow);
            }
            data.Add(rowArray[0], value);
        }
    }

    public void LoadGlobalData()
    {
    }

    public void LoadCardData()
    {
        string[] dataRow = cardData.text.Split('\n');
        foreach(var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0].Contains("编号") || rowArray[0].Contains("id") )
            {
                continue;
            }
            // 新建卡片
            else if(rowArray[0] == "monster")
            {
                int id = int.Parse(rowArray[1]);
                string name = rowArray[2];
                int atk = int.Parse(rowArray[3]);
                EnermyCard enermyCard = new EnermyCard(id, name, 1, 1, 1, 1);
                cards.Add(id, enermyCard);

            }

        }
    }
}
