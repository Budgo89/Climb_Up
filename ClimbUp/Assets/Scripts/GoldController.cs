using Assets.Scripts;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GoldController : MonoBehaviour
{
    [SerializeField] Text _goldText;

    private GoldHandle gold;
    private int i;

    private void Awake()
    {        
        gold = new GoldHandle();
        _goldText.text = Convert.ToString(gold.Gold);
    }

    public void AccrualOfGold()
    {
        gold.Gold = gold.Gold + 1;
        string sum = Convert.ToString(gold.Gold);
        _goldText.text = sum;
    }

    public void WasteGold()
    {
        if(i < gold.Gold)
        {
            i++;
            gold.Gold = gold.Gold - i;
            string sum = Convert.ToString(gold.Gold);
            _goldText.text = sum;
        }
    }
    public int GoldVol()
    {
        return gold.Gold;
    }
}
