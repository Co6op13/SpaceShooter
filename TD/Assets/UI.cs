using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    [SerializeField] TowerManager towerManager;
    [SerializeField] EnemyManager EnemyManager;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button Gutling = root.Q<Button>("Gutling");
        Gutling.clicked += towerManager.AddGutling;
        Button Flamethrower = root.Q<Button>("Flamethrower");
        Flamethrower.clicked += towerManager.AddFlamethrower;

        Button TestCreateEnemy1 = root.Q<Button>("TestCreateEnemy1");
        Button TestCreateEnemy2 = root.Q<Button>("TestCreateEnemy2");
        TestCreateEnemy1.clicked += EnemyManager.AddEnemy1;
        TestCreateEnemy2.clicked += EnemyManager.AddEnemy2;
    }


}
