using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

 

public class UI : MonoBehaviour
{
    [SerializeField] TowerManager towerManager;
    [SerializeField] EnemyManager EnemyManager;
    VisualElement towerMenu;
    VisualElement menu;
    VisualElement panelGameOwer;
    Label moneyLabel;



    public static UI Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        towerMenu = root.Q<VisualElement>("TowerMenu");
        menu = root.Q<VisualElement>("Menu");
        panelGameOwer = root.Q<VisualElement>("PanelGameOwer");
        moneyLabel = root.Q<Label>("moneyLabel");
        Button Flamethrower = root.Q<Button>("Flamethrower");
        Button Gutling = root.Q<Button>("Gutling");
        Button TestCreateEnemy1 = root.Q<Button>("TestCreateEnemy1");
        Button TestCreateEnemy2 = root.Q<Button>("TestCreateEnemy2");
        Button Resume = root.Q<Button>("Resume");
        Button Restart = root.Q<Button>("Restart");

        menu.style.visibility = Visibility.Hidden;
        panelGameOwer.style.visibility = Visibility.Hidden;
        towerMenu.style.visibility = Visibility.Hidden;        

        MyEventManager.OnEnemyKilled.AddListener(ChangesAmpontMoney);
        MyEventManager.OnDestroyBase.AddListener(ShowMenyGameOwer);

        Restart.clicked += RestartScene;
        Resume.clicked += HideMenyGameOwer;
        Flamethrower.clicked += towerManager.AddFlamethrower;
        Gutling.clicked += towerManager.AddGutling;
        TestCreateEnemy1.clicked += EnemyManager.AddEnemy1;
        TestCreateEnemy2.clicked += EnemyManager.AddEnemy2;
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    public void ShowMenyGameOwer()
    {
        menu.style.visibility = Visibility.Visible;
        panelGameOwer.style.visibility = Visibility.Visible;
    }
        public void HideMenyGameOwer()
    {
        menu.style.visibility = Visibility.Hidden;
        panelGameOwer.style.visibility = Visibility.Hidden;
    }


    public void ChangesAmpontMoney (int coins)
    {
        moneyLabel.text = GameManager.Instance.GetAmountMoney().ToString();
    }
}
