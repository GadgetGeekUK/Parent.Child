using Orchard.ContentManagement;
using Orchard.Logging;
using Parent.Child.Services;

namespace Parent.Child.Handlers
{
    public class SimpleEventHandler : ICustomEventHandler
    {
        public ILogger Logger { get; set; }

        public SimpleEventHandler() {
            Logger = NullLogger.Instance;
        }

        public void SomethingHappened(IContent content) {
            Logger.Debug("Simple event handler Content part received: {0}", content.ContentItem.ContentType);
        }
    }
}