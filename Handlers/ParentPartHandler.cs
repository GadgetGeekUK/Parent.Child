using Orchard.ContentManagement.Handlers;
using Parent.Child.Services;

namespace Parent.Child.Handlers
{
    public class ParentPartHandler : ContentHandler {
        private readonly IStockService _service;

        public ParentPartHandler(IStockService service) {
            _service = service;
        }

        protected override void Loading(LoadContentContext context) {
            base.Loading(context);
            // Can we load the child parts collection here?
        }

        // How do we use an activating filter here to attach parts to a content type from code
        // As opposed to migrations, parts attached using this filter will neither be displayed in the dashboard,
        // nor will users be able to remove them from types. This is a legitimate way of attaching parts 
        // that should always exist on a given content type.
        // Mentioned in: http://docs.orchardproject.net/en/latest/Documentation/understanding-content-handlers/
    }
}