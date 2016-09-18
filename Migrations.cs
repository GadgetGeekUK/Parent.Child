using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Parent.Child
{
    public class Migrations : DataMigrationImpl
    {
        public int Create() {
            ContentDefinitionManager.AlterTypeDefinition("Parent", cfg => cfg
                .WithPart("AutoroutePart", builder => builder
                    .WithSetting("AutorouteSettings.AllowCustomPattern", "True"))
                .WithPart("ParentPart")
                .Listable()
                .Creatable(false));

            ContentDefinitionManager.AlterPartDefinition("ParentPart", part => part
                .WithDescription("A part that contains detail records."));

            ContentDefinitionManager.AlterTypeDefinition("Child", cfg => cfg
                .WithPart("ChildPart")
                .Listable()
                .Creatable(false));

            return 1;
        }

        public void Uninstall() {
            ContentDefinitionManager.DeleteTypeDefinition("Parent");
        }
    }
}