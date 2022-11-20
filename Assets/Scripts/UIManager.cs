using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    GameObject _changeUI;
    [SerializeField] TMP_Text _collectiable;
     [SerializeField] TMP_Text _health;

    private void Awake() {
         _changeUI = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {

        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() 
    {
        _changeUI.GetComponent<PlayerScript>().IsCollected += IncreaseCollectiable;
        _changeUI.GetComponent<PlayerScript>().IsHitted += DecreaseHealth;
    }

    

    private void OnDisable() 
    {
        _changeUI.GetComponent<PlayerScript>().IsCollected -= IncreaseCollectiable;
        _changeUI.GetComponent<PlayerScript>().IsHitted -= DecreaseHealth;
    }

    private void IncreaseCollectiable(int collected)
    {
        
        _collectiable.text  = collected.ToString();
    }
    private void DecreaseHealth(int health)
    {
        _health.text = health.ToString();
    }

}
