using Orchard.ContentManagement.Drivers;
using Parent.Child.Models;

namespace Parent.Child.Drivers
{
    public class ParentPartDriver : ContentPartDriver<ParentPart>
    {
        protected override DriverResult Display(ParentPart part, string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_Parent", () => shapeHelper.Parts_Parent());
        }
    }
}