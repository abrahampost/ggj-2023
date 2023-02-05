using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UpgradeController : MonoBehaviour
{
    private UIDocument doc;
    private GameState gameState;
    private PlayerStats playerStats;
    private Button upgradeOne;
    private Label upgradeOneDescription;
    private Button upgradeTwo;
    private Label upgradeTwoDescription;
    private Button upgradeThree;
    private Label upgradeThreeDescription;
    private BuffManager buffManager;

    BuffBase buffOne;
    BuffBase buffTwo;

    BuffWeapon buffThree;

    private void Awake() {
        doc = GetComponent<UIDocument>();
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
        playerStats = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();

        upgradeOne = doc.rootVisualElement.Q<Button>("upgradeOne");
        upgradeOneDescription = doc.rootVisualElement.Q<Label>("descriptionOne");

        upgradeTwo = doc.rootVisualElement.Q<Button>("upgradeTwo");
        upgradeTwoDescription = doc.rootVisualElement.Q<Label>("descriptionTwo");

        upgradeThree = doc.rootVisualElement.Q<Button>("upgradeThree");
        upgradeThreeDescription = doc.rootVisualElement.Q<Label>("descriptionThree");
    }

    void Start() {
        GameObject go = GameObject.Find("BuffManager");
        buffManager = go.GetComponent<BuffManager>();

        BuffBase[] baseBuffs = buffManager.GetRandomBaseBuffs();
        buffOne = baseBuffs[0];
        buffTwo = baseBuffs[1];

        ForestTile selectedTile = gameState.tiles[gameState.selectedLevel.y][gameState.selectedLevel.x];
        selectedTile.isCompleted = true;

        ForestTile.TerrainType terrainType = selectedTile.terrainType;
        buffThree = buffManager.GetRandomWeaponBuffForTerrain(terrainType);
        
        upgradeOne.clicked += upgradeOneClicked;
        upgradeOneDescription.text = buffOne.description;
        upgradeTwo.clicked += upgradeTwoClicked;
        upgradeTwoDescription.text = buffTwo.description;
        upgradeThree.clicked += upgradeThreeClicked;
        upgradeThreeDescription.text = buffThree.description;
    }

    private void upgradeOneClicked() {
        playerStats.AddBaseBuff(buffOne);
        SceneManager.LoadScene("ForestSelection");
    }

    private void upgradeTwoClicked() {
        playerStats.AddBaseBuff(buffTwo);
        SceneManager.LoadScene("ForestSelection");
        // do stuff
    }

    private void upgradeThreeClicked() {
        playerStats.AddWeaponBuff(buffThree);
        SceneManager.LoadScene("ForestSelection");
        // do stuff
    }

}
