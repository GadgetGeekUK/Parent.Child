using Orchard.ContentManagement;

namespace Parent.Child.Models
{
    public class ParentPart : ContentPart {
        private Parent _parent;

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