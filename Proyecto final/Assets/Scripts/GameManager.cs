using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPoints;
    [SerializeField] private TextMeshProUGUI textEnemiesDead;

    [SerializeField] private int maxPoints;
    private int currentPoints;
    private int curretnEnemiesDead;
    private readonly int sumPoints = 50; //puntos por cada enemigo que matas

    // Start is called before the first frame update
    void Start()
    {
        currentPoints = 0;
        textPoints.text = "0";
        textEnemiesDead.text = "0";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SumarPoints()
    {
        currentPoints += sumPoints;
        curretnEnemiesDead++;
        textEnemiesDead.text = curretnEnemiesDead.ToString();
        textPoints.text = currentPoints.ToString();
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
