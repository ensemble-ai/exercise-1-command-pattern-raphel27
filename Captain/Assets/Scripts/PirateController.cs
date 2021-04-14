using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

public class PirateController : MonoBehaviour
{
    public IPirateCommand ActiveCommand;
    public GameObject ProductPrefab;

    // Start is called before the first frame update
    void Start()
    {
        this.ActiveCommand = ScriptableObject.CreateInstance<SlowWorkerPirateCommand>();
    }

    // Update is called once per frame
    void Update()
    {
        var working = this.ActiveCommand.Execute(this.gameObject, this.ProductPrefab);

        this.gameObject.GetComponent<Animator>().SetBool("Exhausted", !working);
    }

    //Has received motivation. A likely source is from on of the Captain's morale inducements.
    public void Motivate()
    {
        float choice = (Random.value) * 100;
        if (choice <= 33.0)
        {
            this.ActiveCommand = Object.Instantiate(ScriptableObject.CreateInstance<FastWorkerPirateCommand>());
        }
        else if (choice > 33.0 && choice <= 66.0)
        {
            this.ActiveCommand = Object.Instantiate(ScriptableObject.CreateInstance<SlowWorkerPirateCommand>());
        }
        else
        {
            this.ActiveCommand = Object.Instantiate(ScriptableObject.CreateInstance<NormalWorkerPirateCommand>());
        }
        // The function will generate a randum number called "choice" in range 1-100. Then, base on this
        // number, the pirates will randumly get in to one of three working status.
    }
}
