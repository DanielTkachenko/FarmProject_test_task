using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInfo : MonoBehaviour
{
    [SerializeField] private Text _coinsInfoText;

    public void Refresh(object sender, int amount, int capacity)
    {
        _coinsInfoText.text = $"{amount.ToString()}/{capacity.ToString()}";
    }
}
