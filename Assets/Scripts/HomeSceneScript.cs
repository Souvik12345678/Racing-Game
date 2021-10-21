using UnityEngine.SceneManagement;
using UnityEngine;

public class HomeSceneScript : MonoBehaviour
{

    private void Awake()
    {
        //Set screen size for Standalone
#if UNITY_STANDALONE
        Screen.SetResolution(337, 600, false);
        Screen.fullScreen = false;
#endif
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPlayButtonPressed()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
