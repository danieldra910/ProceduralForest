using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public void Reset()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
