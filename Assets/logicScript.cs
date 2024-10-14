using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logicScript : MonoBehaviour
{
    public bool whoIsP = false;//black=false,white=ture
    public int winner = 0;//black=1,white=2

    public Text roundText;
    public GameObject EndGameScreen;
    public Text EndText;
    // Update is called once per frame
    void Update()
    {
        if (winner != 0)
        {
            if (winner == 1)
            {
                EndText.text = "遊戲結束，黑子贏了";
            }
            else if (winner == 2)
            {
                EndText.text = "遊戲結束，白子贏了";
            }
            showEnd();
        }
    }
    public void showEnd()
    {
        EndGameScreen.SetActive(true);
    }
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
