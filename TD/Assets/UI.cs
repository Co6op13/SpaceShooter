using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    [SerializeField] TowerManager towerManager;
    [SerializeField] EnemyManager EnemyManager;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button Tower1 = root.Q<Button>("Tower1");
        Tower1.clicked += towerManager.AddTower;
        Button TestCreateEnemy1 = root.Q<Button>("TestCreateEnemy1");
        Button TestCreateEnemy2 = root.Q<Button>("TestCreateEnemy2");
        TestCreateEnemy1.clicked += EnemyManager.AddEnemy1;
        TestCreateEnemy2.clicked += EnemyManager.AddEnemy2;
    }


}
