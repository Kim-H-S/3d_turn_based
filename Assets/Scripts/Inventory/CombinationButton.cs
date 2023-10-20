using System;
using UnityEngine;
using UnityEngine.UI;

public class CombinationButton : MonoBehaviour
{
    Action<int> Combination;
    private void Awake()
    {
        Combination += transform.parent.GetComponent<UICombination>().Combination;
        GetComponent<Button>().onClick.AddListener(Invoke);
    }

    public void Invoke()
    {
        Combination?.Invoke(transform.GetSiblingIndex());
    }

}
