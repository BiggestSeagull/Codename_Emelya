using UnityEngine;

public class FuelSystem : MonoBehaviour
{
    [SerializeField] private UiManager uiManager;


    private void OnTriggerEnter(Collider other)
    {
        // Choosing woodCount depending on collided wood object
        switch(other.tag)
        {
            case "Fuel_1":
                BeahaveDependOnCount(1);
                Destroy(other.gameObject);
                break;

            case "Fuel_3":
                BeahaveDependOnCount(3);
                Destroy(other.gameObject);
                break;

            case "Fuel_4":
                BeahaveDependOnCount(4);
                Destroy(other.gameObject);
                break;
        }
    }

    private void BeahaveDependOnCount(int woodCount)
    {
        // Updating backend (planned as temp, will be chenged to YG variant)
        PlayerStats.currentFuel += woodCount;

        // Showing new score for player
        uiManager.WoodUpdate();

    }

}
