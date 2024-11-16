using Cinemachine;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject character;
    [SerializeField] GameObject character2;
    [SerializeField] GameObject character3;

    [SerializeField] GameObject uiBar;
    [SerializeField] GameObject IA;

    public CinemachineVirtualCamera playerFollowCamera;

    // Posición donde aparecerá el prefab
    [SerializeField] private Vector3 spawnPosition;

    // Rotación del prefab
    [SerializeField] private Quaternion spawnRotation;
    public void Lyago()
    {
        GameObject newObject = Instantiate(character, spawnPosition, spawnRotation);
        Transform hips = newObject.transform.Find("PlayerCameraRoot");
        playerFollowCamera.Follow = hips;
        menu.SetActive(false);
        uiBar.SetActive(true);
        uiBar.GetComponent<HealthBar>().enabled = true;
        IA.SetActive(true);
        IA.GetComponent<SimpleEnemyMovement>().enabled = true;

    }
    public void MasterChiefTemu()
    {
        GameObject newObject = Instantiate(character2, spawnPosition, spawnRotation);
        Transform hips = newObject.transform.Find("PlayerCameraRoot");
        playerFollowCamera.Follow = hips;
        menu.SetActive(false);
        uiBar.SetActive(true);
        uiBar.GetComponent<HealthBar>().enabled = true;
        IA.SetActive(true);
        IA.GetComponent<SimpleEnemyMovement>().enabled = true;

    }
    public void Ninja()
    {
        GameObject newObject = Instantiate(character3, spawnPosition, spawnRotation);
        Transform hips = newObject.transform.Find("PlayerCameraRoot");
        playerFollowCamera.Follow = hips;
        menu.SetActive(false);
        uiBar.SetActive(true);
        uiBar.GetComponent<HealthBar>().enabled = true;
        IA.SetActive(true);
        IA.GetComponent<SimpleEnemyMovement>().enabled = true;

    }
    void ShowCursor(bool show)
    {
        Cursor.visible = show;
        Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;
    }
}