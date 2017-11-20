using Orchard.ContentManagement;
using Orchard.ContentManagement.Utilities;

namespace Parent.Child.Models
{
    public class ParentPart : ContentPart {
        private Parent _parent; // The 3rd party domain object represented by this shape

        #region Trying Lazy Load for Child Part
        internal LazyField<ChildPart> _childPartField = new LazyField<ChildPart>(); // Ahh...this is for NHibernate

        public ChildPart RelatedChildPart
        {
            get { return _childPartField.Value;  }
            set { _childPartField.Value = value; }
        }
        #endregion

        public string Serial
        {
            get { return _parent.Serial; }
            set { _parent.Serial = value; }
        }

        public int ModelId
        {
            get { return _parent.ModelId; }
            set { _parent.ModelId = value; }
        }

        public Model Model
        {
            get { return _parent.Model; }
            set { _parent.Model = value; }
        }

        // Required for the driver
        public ParentPart() {
            _parent = new Parent();
        }

        // Used to hydrate the domain object via the third party service
        public void Populate(Parent parent) {
            _parent = parent;
        }
    }

    // This would be defined in the 3rd Party Service:
    public class Parent {
        public int Id { get; set; }

        public string Serial { get; set; }

        public int ModelId { get; set; }

        public Model Model { get; set; }
    }

    public class Model {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}