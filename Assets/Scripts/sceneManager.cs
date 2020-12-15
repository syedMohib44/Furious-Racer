using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneManager : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("Level1");
    }
}
