using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    private Slider _healthBar;

    void Start()
    {
        _healthBar = this.GetComponent<Slider>();
    }
    void Update()
    {
        _healthBar.value = player.cubeSize;
    }
}
