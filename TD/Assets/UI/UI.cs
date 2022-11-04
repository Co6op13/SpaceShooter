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
    VisualElement panelPause;
    Label moneyLabel;
    private const string AnimHideTowerMeny = "popAnimationHide";
    private const string AnimShowTowerMenu = "popAnimationShow";



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
        panelPause = root.Q<VisualElement>("PanelPause");
        moneyLabel = root.Q<Label>("MoneyLabel");
        Button Flamethrower = root.Q<Button>("Flamethrower");
        Button Gutling = root.Q<Button>("Gutling");
        Button PlasmaGun = root.Q<Button>("PlasmaGun");
        Button TestCreateEnemy1 = root.Q<Button>("TestCreateEnemy1");
        Button TestCreateEnemy2 = root.Q<Button>("TestCreateEnemy2");
        Button Resume = root.Q<Button>("Resume");
        Button RestartG = root.Q<Button>("RestartG");
        Button RestartP = root.Q<Button>("RestartP");
        Button Pause = root.Q<Button>("Pause");


   

        MyEventManager.OnChencheAmountMony.AddListener(GetAmontMoney);
        MyEventManager.OnDestroyBase.AddListener(ShowMenyGameOwer);
        MyEventManager.OnPauseEnable.AddListener(ShowMenuPause);

        Pause.clicked += GameManager.Instance.GamePauseEnable;
        RestartG.clicked += RestartScene;
        RestartP.clicked += RestartScene;
        Resume.clicked += HideAllMeny;
        Resume.clicked += GameManager.Instance.GamePauseDisable;
        Flamethrower.clicked += towerManager.AddFlamethrower;
        Gutling.clicked += towerManager.AddGutling;
        PlasmaGun.clicked += towerManager.AddPlasmaGun;
        TestCreateEnemy1.clicked += EnemyManager.Instance.AddEnemy1;
        TestCreateEnemy1.clicked += Test;
        TestCreateEnemy2.clicked += EnemyManager.Instance.AddEnemy2;
    }

    private void Test()
    {
        Debug.Log("test");
    }

    private void Start()
    {
        GetAmontMoney();
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowTowerMeny()
    {
        Debug.Log("show");
        towerMenu.EnableInClassList(AnimHideTowerMeny, false);
        towerMenu.EnableInClassList(AnimShowTowerMenu, true);
        // towerMenu.ToggleInClassList(AnimHideTowerMeny);
        //towerMenu.EnableInClassList(AnimHideTowerMeny, false);
        // towerMenu.style.visibility = Visibility.Visible;
        //towerMenu.style.translate = new StyleTranslate(new Translate(0, 0, 0));
    }

    public void HideTowerMeny()
    {
        Debug.Log("Hide");
        towerMenu.EnableInClassList(AnimHideTowerMeny, true);
        towerMenu.EnableInClassList(AnimShowTowerMenu, false);
        // towerMenu.style.translate = new StyleTranslate(new Translate(0, 100, 0));
        //towerMenu.style.visibility = Visibility.Hidden;
    }

    public void ShowMenyGameOwer()
    {
        menu.style.visibility = Visibility.Visible;
        panelGameOwer.style.visibility = Visibility.Visible;
    }
    public void HideAllMeny()
    {
        menu.style.visibility = Visibility.Hidden;
        panelGameOwer.style.visibility = Visibility.Hidden;
        panelPause.style.visibility = Visibility.Hidden;
    }

    public void ShowMenuPause()
    {
        menu.style.visibility = Visibility.Visible;
        panelPause.style.visibility = Visibility.Visible;
        
    }

    public void GetAmontMoney()
    {
        moneyLabel.text = GameManager.Instance.GetAmountMoney().ToString();
    }
}
