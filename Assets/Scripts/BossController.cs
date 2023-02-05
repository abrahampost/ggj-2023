using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    // Start is called before the first frame update
    TreeController treeController;
    void Start()
    {
        treeController = GameObject.Find("Tree").GetComponent<TreeController>();
        treeController.RegisterWinCallback(OnDeath);
    }

    void OnDeath () {
        SceneManager.LoadScene("EndGameWin");
    }
}
