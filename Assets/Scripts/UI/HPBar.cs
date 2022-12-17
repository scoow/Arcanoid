using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    private List<TextMeshProUGUI> _hpTextList;
    private void Awake()
    {
        _hpTextList = FindObjectsOfType<TextMeshProUGUI>().ToList();
    }
    public void RedrawHPBar(int hp)
    {
        foreach (TextMeshProUGUI text in _hpTextList)
        {
            text.text = hp.ToString();
        }
    }
}
