using UnityEditor;
using UnityEngine;

public class SceneViewScript : MonoBehaviour
{

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var view = SceneView.currentDrawingSceneView;
        if (view != null)
        {
            view.pivot = target.transform.position;
        }
    }
}
