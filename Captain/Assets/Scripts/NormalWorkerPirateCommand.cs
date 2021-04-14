using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

namespace Captain.Command
{
    public class NormalWorkerPirateCommand : ScriptableObject, IPirateCommand
    {
        private float TotalWorkDuration = 50.0f;
        private float TotalWorkDone = 0.0f;
        private float CurrentWork = 0.0f;
        private const float PRODUCTION_TIME = 4.0f;
        // Random value cannot be assigned in the constructor. Therefore, in here, the TotalWorkDuration
        // has been assigned to a large value. Thus, the if statement can know TotalWorkDuration already
        // be assigned to a randum value or not.

        public NormalWorkerPirateCommand()
        {

        }

        public bool Execute(GameObject pirate, Object productPrefab)
        {

            if (TotalWorkDuration == 50.0f)
            {
                TotalWorkDuration = (Random.value) * 10 + 10;
            }
            // This if statement will assigned randum value to the TotalWorkDuration. If the variable 
            // equal to 50.0f. In this file randum the range is 10-20.

            CurrentWork += Time.deltaTime;
            TotalWorkDone += Time.deltaTime;

            if (TotalWorkDone < TotalWorkDuration)
            {
                if (CurrentWork >= PRODUCTION_TIME)
                {
                    var product = (GameObject)Instantiate(productPrefab, pirate.transform.position, pirate.transform.rotation);
                    var productRigidBody = product.GetComponent<Rigidbody2D>();
                    productRigidBody.velocity = new Vector2(Random.Range(-2.0f, 2.0f), 6.0f);
                    CurrentWork = 0.0f;
                    // When Currentwork reach Production time, it means a product should be produce.
                    // These statement will create a new product and give it a initial velocity. Then,
                    // Currentwork will be reset for next production.

                }
                return true;
            }
            return false;
            // The out if statement will check if the worker should get in to exhausted or not.
            // The inner if statement will check should a new product be produced or not.
        }
    }
}
