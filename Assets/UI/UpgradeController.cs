using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UpgradeController : MonoBehaviour
{
    private UIDocument doc;
    private Button upgradeOne;
    private Button upgradeTwo;
    private Button upgradeThree;
    private Button acceptUpgrade;

    private void Awake() {
        doc = GetComponent<UIDocument>();

        upgradeOne = doc.rootVisualElement.Q<Button>("upgradeOne");
        upgradeOne.clicked += upgradeOneClicked;

        upgradeTwo = doc.rootVisualElement.Q<Button>("upgradeTwo");
        upgradeTwo.clicked += upgradeTwoClicked;

        upgradeThree = doc.rootVisualElement.Q<Button>("upgradeThree");
        upgradeThree.clicked += upgradeThreeClicked;

        acceptUpgrade = doc.rootVisualElement.Q<Button>("acceptUpgrade");
        acceptUpgrade.clicked += acceptUpgradeClicked;
    }

    private void upgradeOneClicked() {
        // do stuff
    }

    private void upgradeTwoClicked() {
        // do stuff
    }

    private void upgradeThreeClicked() {
        // do stuff
    }

    private void acceptUpgradeClicked() {
        //do stuff
    }
}
