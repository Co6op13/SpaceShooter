using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    [SerializeField] TowerManager towerManager;
    [SerializeField] EnemyManager EnemyManager;
    VisualElement towerMenu;
    VisualElement menu;
    VisualElement panelGameOwer;
    Label coinLabel;
    [SerializeField] int coinsCount = 300;


    public static UI Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button Gutling = root.Q<Button>("Gutling");
        towerMenu = root.Q<VisualElement>("TowerMenu");
        menu = root.Q<VisualElement>("Menu");
        panelGameOwer = root.Q<VisualElement>("PanelGameOwer");
        Button Flamethrower = root.Q<Button>("Flamethrower");
        Button TestCreateEnemy1 = root.Q<Button>("TestCreateEnemy1");
        Button TestCreateEnemy2 = root.Q<Button>("TestCreateEnemy2");
        Button Resume = root.Q<Button>("Resume");
        coinLabel = root.Q<Label>("CoinsCount");

        menu.style.visibility = Visibility.Hidden;
        panelGameOwer.style.visibility = Visibility.Hidden;
        towerMenu.style.visibility = Visibility.Hidden;
        coinLabel.text = coinsCount.ToString();

        MyEventManager.OnEnemyKilled.AddListener(AddCoinsForKilledEnemy);
        MyEventManager.OnDestroyBase.AddListener(ShowMenyGameower);

        Flamethrower.clicked += towerManager.AddFlamethrower;
        Gutling.clicked += towerManager.AddGutling;
        TestCreateEnemy1.clicked += EnemyManager.AddEnemy1;
        TestCreateEnemy2.clicked += EnemyManager.AddEnemy2;
    }

    public void ShowTowerMeny()
    {
        Debug.Log("test22222");
        towerMenu.style.visibility = Visibility.Visible;
    }

    public void HideTowerMeny()
    {
        Debug.Log("tes44444");
        towerMenu.style.visibility = Visibility.Hidden;
    }

    public void ShowMenyGameower()
    {
        menu.style.visibility = Visibility.Visible;
        panelGameOwer.style.visibility = Visibility.Visible;
    }
        public void HideMenyGameower()
    {
        menu.style.visibility = Visibility.Hidden;
        panelGameOwer.style.visibility = Visibility.Hidden;
        //panelGameOwer.style.position = Positio
    }


    public void AddCoinsForKilledEnemy (int coins)
    {
        if (coins > 0) coinsCount += coins;
        {
            coinsCount += 100;
            coinLabel.text = coinsCount.ToString();
        }
    }
}
