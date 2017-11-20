using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Parent.Child.Models;

namespace Parent.Child.Drivers
{
    public class ParentPartDriver : ContentPartDriver<ParentPart> {

        private readonly IContentManager _contentManager;

        public ParentPartDriver(IContentManager contentManager) {
            _contentManager = contentManager;
        }

        protected override DriverResult Display(ParentPart part, string displayType, dynamic shapeHelper) {
            // return ContentShape("Parts_Parent", () => shapeHelper.Parts_Parent());

            return Combined(
                ContentShape("Parts_Parent", ()=> shapeHelper.Parts_Parent(
                    Child: _contentManager.BuildDisplay(part.RelatedChildPart, displayType))),
                ContentShape("Parts_Parent_SummaryAdmin", () => shapeHelper.Parts_Parent_SummaryAdmin(
                    Child: _contentManager.BuildDisplay(part.RelatedChildPart, displayType))));
        }
    }
}