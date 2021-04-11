using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

namespace Captain.Command
{
    public class CharacterJump : ScriptableObject, ICaptainCommand
    {
        private float hight = 5.0f;

        public void Execute(GameObject gameObject)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
            {
                float hight = rigidBody.velocity.y;
                if (hight == 0.0f)
                {
                    rigidBody.velocity = new Vector2(rigidBody.velocity.x, this.hight);
                }
            }
        }
    }
}


