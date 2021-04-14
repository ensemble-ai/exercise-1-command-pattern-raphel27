using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

namespace Captain.Command
{
    public class SlowWorkerPirateCommand : ScriptableObject, IPirateCommand
    {
        private float TotalWorkDuration = 50.0f;
        private float TotalWorkDone = 0.0f;
        private float CurrentWork = 0.0f;
        private const float PRODUCTION_TIME = 8.0f;
        // Random value cannot be assigned in the constructor. Therefore, in here, the TotalWorkDuration
        // has been assigned to a large value. Thus, the if statement can know TotalWorkDuration already
        // be assigned to a randum value or not.

        public SlowWorkerPirateCommand()
        {

        }

        public bool Execute(GameObject pirate, Object productPrefab)
        {
            if (TotalWorkDuration == 50.0f)
            {
                TotalWorkDuration = (Random.value) * 20.0f + 20.0f;
            }
            // This if statement will assigned randum value to the TotalWorkDuration. If the variable 
            // equal to 50.0f. In this file randum the range is 20-40.

            CurrentWork += Time.deltaTime;
            TotalWorkDone += Time.deltaTime;

            if (TotalWorkDone < TotalWorkDuration)
            {
                if(CurrentWork >= PRODUCTION_TIME)
                {
                    var generate_loc = new Vector3(pirate.transform.position.x, pirate.transform.position.y, -1.0f);
                    var product = (GameObject)Instantiate(productPrefab, generate_loc, pirate.transform.rotation);
                    product.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2.0f, 2.0f), 6.0f);
                    CurrentWork = 0.0f;
                    // When Currentwork reach Production time, it means a product should be produce. 
                    // These statement will create a new product and give it a initial velocity. Then,
                    // Currentwork will be reset for next production. Sometimes, the product might behind the
                    // character. Therefore, we get a variable called "generate_loc" and give it a z value
                    // to insure the product will not be cover by character.

                }
                return true;
            }
            return false;
            // The out if statement will check if the worker should get in to exhausted or not.
            // The inner if statement will check should a new product be produced or not.
        }
    }
}
