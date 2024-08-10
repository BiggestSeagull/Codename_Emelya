using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentWood;

    // Start is called before the first frame update
    void Start()
    {
        currentWood.text = "Дрова: \n" + PlayerStats.currentFuel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WoodUpdate()
    {
        currentWood.text = "Дрова: \n" + PlayerStats.currentFuel.ToString();
    }
}
