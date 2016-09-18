using System.Collections.Generic;
using Orchard;
using Parent.Child.Models;

namespace Parent.Child.Services
{
    public interface IStockService : IDependency {
        Models.Parent Get(string serial);

        long TotalChildPartCount { get; }

        IEnumerable<ChildPart> GetChildrenFor(int parentId, int skipCount = 0, int pageSize = 10);
    }
}
