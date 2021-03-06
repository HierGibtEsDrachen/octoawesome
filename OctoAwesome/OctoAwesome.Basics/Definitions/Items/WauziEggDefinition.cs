﻿namespace OctoAwesome.Basics.Definitions.Items
{
    public sealed class WauziEggDefinition : IItemDefinition
    {
        public string Icon
        {
            get
            {
                return "wauziegg";
            }
        }

        public string Name
        {
            get
            {
                return "Wauzi Egg";
            }
        }

        public int StackLimit
        {
            get
            {
                return 1000;
            }
        }

        public float VolumePerUnit
        {
            get
            {
                return 1;
            }
        }

        decimal IInventoryableDefinition.VolumePerUnit => 1;
    }
}
