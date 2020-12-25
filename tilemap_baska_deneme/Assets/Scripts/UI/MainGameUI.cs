using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainGameUI : MonoBehaviour
{
    private static MainGameUI _instance;
    public static MainGameUI Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("MainGameUI is NULL");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;     
    }

    [SerializeField] private GameObject _deathScene;

    [SerializeField] private Text _coinCountText;

    [SerializeField] private GameObject _MobileController;

    [SerializeField] private GameObject _coinPanel;

    public void UpdateCoinText(int coin)
    {
        _coinCountText.text = coin.ToString();
    }
    
    public void ActivateDeathScene()
    {
        StartCoroutine(LoadDeathScene());
    }

    public void LoadCurrentScene()
    {
        _MobileController.SetActive(true);
        _coinPanel.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator LoadDeathScene()
    {
        yield return new WaitForSeconds(1f);
        _MobileController.SetActive(false);
        _coinPanel.SetActive(false);
        _deathScene.SetActive(true);
    }
}
