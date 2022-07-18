using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceTestButton : MonoBehaviour
{
    [SerializeField]
    private Dice _dice;

    private Button _button;
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(() => {
            _dice.Roll((int value) => {
                Debug.Log(value);
            });
        });
    }
}
