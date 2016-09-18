using System;
using System.Collections.Generic;
using System.Linq;
using Orchard;
using Orchard.ContentManagement;
using Parent.Child.Models;

namespace Parent.Child.Services
{
    public class FakeStockService : IStockService {
        private readonly IOrchardServices _services;

        public FakeStockService(IOrchardServices services) {
            _services = services;
        }

        private readonly Models.Parent _parent = new Models.Parent {
            Id = 1,
            Model = new Model { Id = 3, Name = "SKU_VARIANT" }
        };

        private readonly ChildRecord _child = new ChildRecord {
            Posted = DateTime.Now.AddDays(-7.0),
            Description = "Some description",
            Fault = false
        };

        public Models.Parent Get(string serial) {
            var result = _parent;
            result.Serial = serial;
            return result;
        }

        public long TotalChildPartCount => 30;

        public IEnumerable<ChildPart> GetChildrenFor(int parentId, int skipCount = 0, int pageSize = 10) {
            var result = new List<ChildRecord>();
            for (int i = 0; i < pageSize; i++) {
                result.Add(_child);
            }

            return result.Select(item => {
                var contentItem = _services.ContentManager.New("Child");
                var part = contentItem.As<ChildPart>();
                part.Populate(item);
                return part;
            }).ToList();
        }
    }
}