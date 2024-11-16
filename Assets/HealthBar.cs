using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    HealthAndDamage healthAndDamage;
    [SerializeField] Image healthBar;
    [SerializeField] Slider healthSlider;

    void Start()
    {
        
        // Obtener el componente HealthAndDamage del mismo GameObject
        healthAndDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthAndDamage>();
        print("abueno");
        // Verificar si healthAndDamage no es nulo para evitar errores
        if (healthAndDamage != null)
        {
            Debug.Log("Vida inicial...");
            
            int vidaInicial = healthAndDamage.vida; // Asignar la vida correctamente
            Debug.Log("Vida inicial: " + vidaInicial);
        }
        else
        {
            Debug.LogError("No se encontró el componente HealthAndDamage en este GameObject.");
        }
    }

        // Update is called once per frame
        void Update()
        {
            int vidaInicial = healthAndDamage.vida; // Asignar la vida correctamente
            int currentHealth = healthAndDamage.currentHealth; // Asignar la vida correctamente
            
        }

        public void setMaxHealth(int vidaInical)
        {
            healthSlider.maxValue = vidaInical;
            healthSlider.value = vidaInical;
        }

        public void setHealth(int vidaInical)
        {
            healthSlider.value = vidaInical;
        }
}