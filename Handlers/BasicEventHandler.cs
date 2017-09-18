using Orchard.ContentManagement;
using Orchard.Logging;
using Parent.Child.Services;

namespace Parent.Child.Handlers
{
    public class BasicEventHandler : ICustomEventHandler
    {
        public ILogger Logger { get; set; }

        public BasicEventHandler() {
            Logger = NullLogger.Instance;
        }

        public void SomethingHappened(IContent content) {
            Logger.Debug("Basic event handler Content part received: {0}", content.ContentItem.ContentType);
        }
    }
}