using UnityEngine.SceneManagement;
using UnityEngine;

public class HomeSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }

    public void OnPlayButtonPressed()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
