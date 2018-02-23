﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using engenious;
using OctoAwesome.Basics.EntityComponents;
using OctoAwesome.EntityComponents;
namespace OctoAwesome.Basics.Entities
{
    public class WauziEntity : Entity
    {
        public int JumpTime { get; set; }

        public WauziEntity() : base(true)
        {
            Radius = 2f;
            Height = 1.5f;
            Components.AddComponent(new BodyComponent() { Mass = 50f, Height = 2f, Radius = 1.5f });
            Components.AddComponent(new PositionComponent() { Position = new Coordinate(0, new Index3(0, 0, 200), new Vector3(0, 0, 0)) });
            Components.AddComponent(new GravityComponent());
            Components.AddComponent(new BodyPowerComponent() { Power = 600f, JumpTime = 120 });
            Components.AddComponent(new MoveableComponent());
            Components.AddComponent(new BoxCollisionComponent());
            Components.AddComponent(new ControllerComponent());
            Components.AddComponent(new RenderComponent() { Name = "Wauzi", ModelName = "dog", TextureName = "texdog", BaseZRotation = -90 }, true);
        }

        protected override void OnInitialize(IResourceManager manager)
        {
            Cache = new LocalChunkCache(manager.GlobalChunkCache, true, 2, 1);
        }

        public override void Update(GameTime gameTime)
        {
            BodyPowerComponent body = Components.GetComponent<BodyPowerComponent>();
            ControllerComponent controller = Components.GetComponent<ControllerComponent>();
            controller.MoveInput = new Vector2(0.5f, 0.5f) ;
            
            if (JumpTime <= 0)
            {
                controller.JumpInput = true;
                JumpTime = 10000;
            }
            else
            {
                JumpTime -= gameTime.ElapsedGameTime.Milliseconds;
            }

            if (controller.JumpActive)
            {
                controller.JumpInput = false;
            }
        }
    }
}
