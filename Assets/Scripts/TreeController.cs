using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public struct TreeConfig
{
    public float health;
    public float targetHealth;
    public float growthInterval;
    public float growthRate;
}

public class TreeController : MonoBehaviour
{
    // Audio
    private TreeSoundController soundController;
    private System.Action winCallback;

    private float health;
    private float initialHealth;
    private float targetHealth;
    private float growthInterval;
    private float growthRate;
    private float scaleWidth = 1.6f;
    //private float pitchWidth = .6f;
    private float growthFactor;
    //private float pitchInterval;
    private float scaleInterval;

    public void InitializeTree(TreeConfig treeConfig)
    {
        health = treeConfig.health;
        initialHealth = treeConfig.health;
        targetHealth = treeConfig.targetHealth;
        growthInterval = treeConfig.growthInterval;
        growthRate = treeConfig.growthRate;

        growthFactor = (targetHealth - health) / growthRate;
        //pitchInterval = pitchWidth / growthFactor;
        scaleInterval = scaleWidth / growthFactor;
    }

    void Start()
    {
        TreeConfig treeConfig = new TreeConfig();
        treeConfig.growthRate = 2;
        treeConfig.health = 10;
        treeConfig.targetHealth = 30;
        treeConfig.growthInterval = 2;

        InitializeTree(treeConfig);

        beginGrowthLoop();
        soundController = GetComponent<TreeSoundController>();
    }

    private IEnumerator GrowTree()
    {
        while (health < targetHealth)
        {
            yield return new WaitForSeconds(growthRate);
            //soundController.DecreaseAmbientSoundPitch(pitchInterval);
            soundController.PlayTreeGrowth();
            gameObject.GetComponentInChildren<Animator>().SetTrigger("Growth-Trigger");
            gameObject.transform.localScale += new Vector3(scaleInterval, scaleInterval, 0);
            health += growthInterval;

        }

        Debug.Log("LEVEL COMPLETE");
        if (winCallback != null) {
            // this is for special battles like Boss fights
            winCallback();
        } else {
            SceneManager.LoadScene("SelectUpgrade");
        }
    }

    public void beginGrowthLoop()
    {
        StartCoroutine(GrowTree());
    }

    // private void Update()
    // {

    // }

    public void TakeDamage(float value)
    {
        ModifyHealthByValue(-value);

        Vector3 scale = gameObject.transform.localScale;

        var scalePerUnit = scaleWidth / (targetHealth - initialHealth);
        var scaleValue = Mathf.Max(.3f, .4f + ((health - initialHealth) * scalePerUnit));

        //var pitchPerUnit = pitchWidth / (targetHealth - initialHealth);
        //var pitchValue = Mathf.Max(.6f, .8f + ((health - initialHealth) * pitchPerUnit));

        //soundController.IncreaseAmbientSoundPitch(soundController.GetPitch() - pitchValue);
        gameObject.transform.localScale = new Vector3(scaleValue, scaleValue, 0);

        // Debug.Log("SCALE");
        // Debug.Log(gameObject.transform.localScale.x);
        
    }

    public void ModifyHealthByValue(float value)
    {
        health += value;

        if (health <= 0)
        {
            //soundController.playDeathScream();
            //animationController.DeathAnimation();
            SceneManager.LoadScene("EndGameLose");
            return;
        }

        //soundController.playOnHit();
        //animationController.HitAnimation();
    }

    public void RegisterWinCallback(System.Action callback) {
        this.winCallback = callback;
    }
}
