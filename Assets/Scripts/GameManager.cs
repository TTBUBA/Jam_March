using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Ui")]
    [SerializeField] private TextMeshProUGUI Text_CountObject;
    [SerializeField] private GameObject PanelGameOver;
    public int CountObjectPickUp;
    public int MaxObjectPickUp;

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        UiObjectPickUp();
    }

    private void UiObjectPickUp()
    {
        Text_CountObject.text = CountObjectPickUp.ToString() + "/" + MaxObjectPickUp.ToString();
    }

    private void GameOver()
    {
        if (Timer.Instance.ElapsedTime <= 1)
        {
            PanelGameOver.SetActive(true);
            MovementPlayer.Instance.ActiveMovement = false;
            PlayerCamera.Instance.ActiveCamera = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void RestartGame()
    {
        PanelGameOver.SetActive(false);
        CountObjectPickUp = 0;
        SceneManager.LoadScene("Game");

        MovementPlayer.Instance.ActiveMovement = true;
        PlayerCamera.Instance.ActiveCamera = true;
    }
}
