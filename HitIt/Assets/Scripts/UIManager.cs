using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject EndPanel;
    public GameObject scorePanel;


    private void Start()
    {
        scorePanel.SetActive(false);
    }

    public void OnStartBtn()
    {
        startPanel.SetActive(false);
        scorePanel.SetActive(true);

    }
    public void OnRestartBtn()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        EndPanel.SetActive(false);

    }

    public void GameOver()
    {
        scorePanel.SetActive(false);
        EndPanel.SetActive(true);

    }
}
