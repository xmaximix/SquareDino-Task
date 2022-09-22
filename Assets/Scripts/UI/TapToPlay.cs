using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))] 
public class TapToPlay : MonoBehaviour
{
    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(StartGame);
        button.onClick.AddListener(delegate { gameObject.SetActive(false); });
    }

    public void StartGame()
    {
        FindObjectOfType<Player>().MoveToNextStage();
    }
}
