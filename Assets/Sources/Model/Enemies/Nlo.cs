using System;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

namespace Asteroids.Model
{
    public class Nlo : Enemy
    {
        private readonly float _speed;
        private Transformable _target;
        private Transformable _ship;
        

        public Nlo(Vector2 position, float speed, Transformable ship) : base(position, 0)
        {
            _speed = speed;
            _ship = ship;
            
        }

        public void SetEnemy(Transformable target)
        {
            _target = target;
        }

        public override void Update(float deltaTime)
        {
            Vector2 nextPosition = Vector2.MoveTowards(Position, _target.Position, _speed * deltaTime);
            MoveTo(nextPosition);
            LookAt(_target.Position);
            if (Position == _target.Position)
                Destroy();
            if (_target.IsAlive == false)
            {
              _target = _ship;
            }
        }

        private void LookAt(Vector2 point)
        {
            Rotate(Vector2.SignedAngle(Quaternion.Euler(0, 0, Rotation) * Vector3.up, (Position - point)));
        }

        
    }
}
