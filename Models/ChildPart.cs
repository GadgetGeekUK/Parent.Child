using System;
using Orchard.ContentManagement;

namespace Parent.Child.Models
{
    public class ChildPart : ContentPart {
        private ChildRecord _child;

        public DateTime ChildDateTime
        {
            get { return _child.Posted; }
            set { _child.Posted = value; }
        }

        public string Description
        {
            get { return _child.Description; }
            set { _child.Description = value; }
        }

        public bool Fault
        {
            get { return _child.Fault; }
            set { _child.Fault = value; }
        }

        public ChildPart() {
            _child = new ChildRecord();
        }

        public void Populate(ChildRecord child) {
            _child = child;
        }
    }

    // This would be defined in the 3rd party Service
    public class ChildRecord {
        public int Id { get; set; }

        public DateTime Posted { get; set; }

        public string Description { get; set; }

        public bool Fault { get; set; }
    }
}