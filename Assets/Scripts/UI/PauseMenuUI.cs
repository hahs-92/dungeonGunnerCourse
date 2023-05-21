using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    private void Start()
    {
        // Initially hide the pause menu
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
