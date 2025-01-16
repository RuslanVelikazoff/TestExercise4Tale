using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] 
    private Button nextLevelButton;

    [SerializeField] 
    private int levelIndex;

    private void Awake()
    {
        if (nextLevelButton != null)
        {
            nextLevelButton.onClick.RemoveAllListeners();
            nextLevelButton.onClick.AddListener(() =>
            {
                
            });
        }
    }

    private void NextLevel()
    {
        if (levelIndex != 3)
        {
            SceneManager.LoadScene("Level" + (levelIndex + 1));
        }
        else
        {
            SceneManager.LoadScene("Level" + 1);
        }
    }
}
