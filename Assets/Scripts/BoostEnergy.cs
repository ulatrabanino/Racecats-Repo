using UnityEngine;
using UnityEngine.UI;

public class BoostEnergy : MonoBehaviour
{
    public float energy;
    float maxEnergy;

    public Slider energyBar;
    public float dvalue;
    public float ivalue;

    // Start is called before the first frame update
    void Start() {
        maxEnergy = energy;
        energyBar.maxValue = maxEnergy;
    }

    // Update is called once per frame
    void Update() {

        //updates energy bar based on input and energy remaining
        if(Input.GetKey(KeyCode.Space) || GamepadController.boosting) {
            DecreaseEnergy();
        } else if(energy != maxEnergy) {
            IncreaseEnergy();
        }

        energyBar.value = energy;
    }

    //decreases energy
    public void DecreaseEnergy() {
        if (energy != 0) {
            energy -= dvalue * Time.deltaTime;
        }
     
        if (energy <= -1) {
            energy = 0;
        }
    }

    //increases energy
    public void IncreaseEnergy() {
        energy += ivalue * Time.deltaTime;
        if (energy >= maxEnergy) {
            energy = maxEnergy;
        }
    }       
}
