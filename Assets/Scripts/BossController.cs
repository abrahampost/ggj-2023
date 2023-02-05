using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OnDeath();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDeath() {
        SceneManager.LoadScene("EndGame");
    }
}
