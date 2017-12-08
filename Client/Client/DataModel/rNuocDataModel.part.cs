﻿using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class rNuocDataModel
    {
        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(TenNuoc), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        public override string DisplayText
        {
            get { return TenNuoc; }
        }
    }
}
