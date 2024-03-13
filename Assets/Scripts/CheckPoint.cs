using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckPoint : MonoBehaviour
{

    private GameMaster gameMaster;
    public GameObject popupTextPrefab;
    public TMP_Text popupText;
    private DialogueEvent dialogEvent;
    public int dialogIndex;

    private void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            Instantiate(popupTextPrefab, transform.position, Quaternion.identity);
            gameMaster.lastCheckPointPosition = transform.position;
        }
        gameObject.SetActive(false);
        
    }
}
