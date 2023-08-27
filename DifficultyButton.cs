using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DifficultyButton : MonoBehaviour
{
    private Button difficultyButton;
    private GameManager gameManagerScript;

    [SerializeField] private int difficulty;
    void Start()
    {
        difficultyButton = GetComponent<Button>();
        gameManagerScript =GameObject.Find("Game Manager").GetComponent <GameManager>();
        difficultyButton.onClick.AddListener(SetDifficulty);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDifficulty()
    {
        Debug.Log(difficultyButton.gameObject.name + " on clicked");
        gameManagerScript.StartGame(difficulty);
    }
}
