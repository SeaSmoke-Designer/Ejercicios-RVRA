using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPoints;
    [SerializeField] private TextMeshProUGUI textEnemiesDead;

    private int maxPoints; //maximo de puntos 10000
    [SerializeField] private int maxEnemies;
    private int currentPoints;
    private int curretnEnemiesDead;
    private readonly int sumPoints = 50; //puntos por cada enemigo que matas
    private bool win;

    void Start()
    {
        currentPoints = 0;
        textPoints.text = "0";
        textEnemiesDead.text = "0";
    }

    void Update()
    {
    }

    public void SumarPoints()
    {
        if (!win)
        {
            currentPoints += sumPoints;
            curretnEnemiesDead++;
            textEnemiesDead.text = curretnEnemiesDead.ToString();
            textPoints.text = currentPoints.ToString();
        }

        if (curretnEnemiesDead >= maxEnemies)
            Win();

    }

    private void Win() => win = true;
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void ChangeScene() => SceneManager.LoadScene(1);
    public int GetMaxEnemies() => maxEnemies;
}
