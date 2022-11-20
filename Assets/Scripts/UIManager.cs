using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    GameObject _collectiableCont;
    [SerializeField] TMP_Text _collectiable;

    private void Awake() {
         _collectiableCont = GameObject.FindGameObjectWithTag("Player");
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
        _collectiableCont.GetComponent<PlayerScript>().IsCollected += IncreaseCollectiable;
    }
    private void OnDisable() 
    {
        _collectiableCont.GetComponent<PlayerScript>().IsCollected -= IncreaseCollectiable;
    }

    private void IncreaseCollectiable(int collected)
    {
        
        _collectiable.text  = collected.ToString();
    }

}
