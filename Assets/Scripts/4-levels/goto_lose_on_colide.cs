using UnityEngine;
using UnityEngine.SceneManagement;

public class goto_lose_on_colide : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] NumberField scoreField;
    [SerializeField] string tag1;
    [SerializeField] string tag2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == tag1 || other.tag == tag2) && !enabled)
        {
            SceneManager.LoadScene(sceneName);    // Input can either be a serial number or a name; here we use name.
        }
    }
}