using Orchard.ContentManagement;
using Orchard.Events;

namespace Parent.Child.Services
{
    public interface ICustomEventHandler : IEventHandler {
        void SomethingHappened(IContent content);
    }
}
