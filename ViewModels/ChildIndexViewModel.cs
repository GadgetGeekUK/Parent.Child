using System.Collections.Generic;
using Parent.Child.Models;

namespace Parent.Child.ViewModels
{
    public class ChildIndexViewModel {
        public IList<ChildPart> Logs { get; set; }

        public dynamic Pager { get; set; }
    }
}