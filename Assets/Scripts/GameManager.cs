using Unity.VisualScripting;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Ui")]
    [SerializeField] private TextMeshProUGUI Text_CountObject;
    public int CountObjectPickUp;
    public int MaxObjectPickUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        UiObjectPickUp();
    }

    private void UiObjectPickUp()
    {
        Text_CountObject.text = CountObjectPickUp.ToString() + "/" + MaxObjectPickUp.ToString();
    }
}
