using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class UserInterfaceController : MonoBehaviour
{
    //[SerializeField] private VisualElement _menu;
    //[SerializeField] private VisualElement[] _mainMenuOptions;
    //[SerializeField] private List<VisualElement> _widgets;
    //[SerializeField] private const string POPUP_ANIMATION = "pop-animation-hide";
    //[SerializeField] private int _mainPopupIndex = -1;
    //int t;


    //private void Awake()
    //{
    //    var root = GetComponent<UIDocument>().rootVisualElement;
    //    _menu = root.Q<VisualElement>("Menu");
    //    _mainMenuOptions = _menu.Q<VisualElement>("MainNav").Children().ToArray();
    //    _widgets = root.Q<VisualElement>("Body").Children().ToList();
    //    Debug.Log("_mainMenuOptions " + _mainMenuOptions.Length);
    //    Debug.Log("_widgets " + _widgets.Count);
    //    _menu.RegisterCallback<TransitionEndEvent>(Menu_TransitionEnd);

    //}

    //private IEnumerator Start()
    //{
    //    yield return new WaitForSeconds(1f);
    //    _menu.ToggleInClassList(POPUP_ANIMATION);

    //}

    //private void FixedUpdate()
    //{
        

    //}

    //private void Menu_TransitionEnd(TransitionEndEvent evt)
    //{
    //    //if (!evt.stylePropertyNames.Contains("opacity")) { return; }
    //    //if (_mainPopupIndex < _mainMenuOptions.Length - 1)
    //    //{

    //    //    _mainPopupIndex++;
    //    //    _mainMenuOptions[_mainPopupIndex].ToggleInClassList(POPUP_ANIMATION);
    //    //}
    //    //else
    //    //{
    //    _widgets.ForEach(x => x.style.translate = new StyleTranslate(new Translate(0, 0, 0)));
    //    //}
    //}
}
