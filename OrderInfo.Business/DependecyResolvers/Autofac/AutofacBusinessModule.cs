using Autofac;
using OrderInfo.Business.Abstract;
using OrderInfo.Business.Concrete;
using OrderInfo.DataAccess.Abstract;
using OrderInfo.DataAccess.Concrete;

namespace OrderInfo.Business.DependecyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProuctDal>().As<IProductDal>();

            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>();

            builder.RegisterType<OrderItemManager>().As<IOrderItemService>();
            builder.RegisterType<EfOrderItemDal>().As<IOrderItemDal>();

            builder.RegisterType<CustomerDetailService>().As<ICustomerDetailService>();

            builder.RegisterType<OrderInfoManager>().As<IOrderInfoService>();

        }
    }
}
