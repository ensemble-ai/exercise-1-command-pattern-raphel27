using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

namespace Captain.Command
{
    public class FastWorkerPirateCommand : ScriptableObject, IPirateCommand
    {
        private float TotalWorkDuration = 50.0f;
        private float TotalWorkDone = 0.0f;
        private float CurrentWork = 0.0f;
        private const float PRODUCTION_TIME = 2.0f;
        //private bool Exhausted = false;

        public FastWorkerPirateCommand()
        {

        }

        public bool Execute(GameObject pirate, Object productPrefab)
        {
            if (TotalWorkDuration == 50.0f)
            {
                TotalWorkDuration = (Random.value) * 5 + 5;
                //Debug.Log(" Assigned ");
            }

            //Debug.Log(" calling Excute");
            CurrentWork += Time.deltaTime;
            TotalWorkDone += Time.deltaTime;

            if (TotalWorkDone < TotalWorkDuration)
            {
                if (CurrentWork > PRODUCTION_TIME)
                {
                    //Debug.Log(" We reach 8 Second");
                    var product = (GameObject)Instantiate(productPrefab, pirate.transform.position, pirate.transform.rotation);
                    var productRigidBody = product.GetComponent<Rigidbody2D>();
                    productRigidBody.velocity = new Vector2(Random.Range(-1.5f, 1.5f), 5.0f);
                    CurrentWork = 0.0f;
                    //Debug.Log(" return true");

                }
                return true;
            }
            return false;
        }
    }
}