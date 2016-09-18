using Orchard.ContentManagement.Drivers;
using Parent.Child.Models;

namespace Parent.Child.Drivers
{
    public class ChildPartDriver : ContentPartDriver<ChildPart>
    {
        protected override DriverResult Display(ChildPart part, string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_Parent_Child", () => shapeHelper.Parts_Parent_Child());
        }
    }
}