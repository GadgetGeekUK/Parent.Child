using System.Linq;
using System.Web.Mvc;
using Orchard;
using Orchard.ContentManagement;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Logging;
using Orchard.Mvc;
using Orchard.Settings;
using Orchard.Themes;
using Orchard.UI.Navigation;
using Parent.Child.Models;
using Parent.Child.Services;

namespace Parent.Child.Controllers
{
    [Themed]
    public class StockController : Controller {
        private readonly IStockService _stockService;

        private readonly IOrchardServices _services;

        private readonly ISiteService _siteService;

        private readonly ICustomEventHandler _eventHandler;

        protected ILogger Logger { get; set; }

        public Localizer T { get; set; }

        public dynamic Shape { get; set; }

        public StockController(IShapeFactory shapeFactory, IStockService stockService, IOrchardServices services, ISiteService siteService, ICustomEventHandler eventHandler) {
            Shape = shapeFactory;
            _stockService = stockService;
            _services = services;
            _siteService = siteService;
            _eventHandler = eventHandler;

            Logger = NullLogger.Instance;
            T = NullLocalizer.Instance;
        }

        public ActionResult Parent(string parentId, PagerParameters pagerParameters) {
            if (string.IsNullOrWhiteSpace(parentId)) {
                return HttpNotFound();
            }

            var stockItem = _stockService.Get(parentId);
            if (stockItem == null) {
                return HttpNotFound();
            }

            dynamic shape = GetStockItemContentShape(stockItem, pagerParameters);

            _eventHandler.SomethingHappened(shape.ContentItem);

            return new ShapeResult(this, shape);
        }

        private dynamic GetStockItemContentShape(Models.Parent parent, PagerParameters pagerParameters) {
            var contentItem = _services.ContentManager.New("Parent");
            var item = contentItem.As<ParentPart>();
            item.Populate(parent);

            dynamic shape = _services.ContentManager.BuildDisplay(item); //calls the driver for the part

            dynamic childItemNavigation = GetChildNavigationShape(parent, "ChildLog");
            shape.Content.Add(childItemNavigation);

            AddChildLogShape(parent, pagerParameters, shape);

            return shape;
        }

        private void AddChildLogShape(Models.Parent parent, PagerParameters pagerParameters, dynamic shape) {
            var childLogList = Shape.List();
            var childLogPager = new Pager(_siteService.GetSiteSettings(), pagerParameters);

            var children = _stockService.GetChildrenFor(parent.Id, childLogPager.GetStartIndex(), childLogPager.PageSize);
            childLogList.AddRange(children.Select(x => _services.ContentManager.BuildDisplay(x, "Detail")));
            shape.Content.Add(Shape.Parts_Parent_Child_List(ContentItems: childLogList));

            var childrenPagerShape = Shape.Pager(childLogPager).TotalItemCount(_stockService.TotalChildPartCount);
            shape.Content.Add(childrenPagerShape);
        }

        private dynamic GetChildNavigationShape(Models.Parent parent, string activeTab) {
            var childNavigation = Shape.Create("ChildLogNavigation");
            childNavigation.Serial = parent.Serial;
            childNavigation.ProductType = parent.Model;
            childNavigation.ActiveTab = activeTab;

            return childNavigation;
        }
    }
}