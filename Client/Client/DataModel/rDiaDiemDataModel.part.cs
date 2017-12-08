using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class rDiaDiemDataModel
    {
        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(Tinh), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        public override string DisplayText
        {
            get { return Tinh; }
        }
    }
}
